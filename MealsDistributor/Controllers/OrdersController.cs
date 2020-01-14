using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.Meals.Abstract;
using Domain.Providers.Meals.Request.Abstract;
using Domain.Providers.Meals.Request.Concrete;
using Domain.Providers.Meals.Response.Abstract;
using Domain.Providers.Orders.Abstract;
using Domain.Providers.Orders.Request.Abstract;
using Domain.Providers.Orders.Request.Concrete;
using Domain.Providers.Orders.Response.Abstract;
using Domain.Providers.Orders.Response.Const;
using Domain.Providers.OrdersPositions.Abstract;
using Domain.Providers.OrdersPositions.Request.Concrete;
using Domain.Providers.OrdersPositions.Response.Abstract;
using Domain.Providers.Restaurants.Abstract;
using Domain.Providers.Restaurants.Request.Concrete;
using Domain.Providers.Users.Abstract;
using Domain.Providers.Users.Request.Concrete;
using Domain.Updater.Order.Abstract;
using Domain.Updater.Order.Request.Concrete;
using Domain.Updater.Order.Response.Abstract;
using Domain.Updater.Order.Response.Const;
using MealsDistributor.Infrastructure.IdFromClaimsExpanding.Abstract;
using MealsDistributor.Infrastructure.ObjectsToModelConverting.Abstract;
using MealsDistributor.Model.ApiModels;
using MealsDistributor.Model.Response.Order;
using Microsoft.AspNetCore.Mvc;

namespace MealsDistributor.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IOrderProvider _orderProvider;
        private readonly IObjectToApiModelConverter _objectToApiModelConverter;
        private readonly IMealProvider _mealProvider;
        private readonly IOrderPositionsProvider _orderPositionsProvider;
        private readonly IOrderUpdater _orderUpdater;
        private readonly IUserIdFromClaimsExpander _userIdFromClaimsExpander;
        private readonly IUserProvider _userProvider;
        private readonly IRestaurantProvider _restaurantProvider;

        public OrdersController(ILogger logger, IOrderProvider orderProvider, IObjectToApiModelConverter objectToApiModelConverter, IMealProvider mealProvider, IOrderPositionsProvider orderPositionsProvider, IOrderUpdater orderUpdater, IUserIdFromClaimsExpander userIdFromClaimsExpander, IUserProvider userProvider)
        {
            _logger = logger;
            _orderProvider = orderProvider;
            _objectToApiModelConverter = objectToApiModelConverter;
            _mealProvider = mealProvider;
            _orderPositionsProvider = orderPositionsProvider;
            _orderUpdater = orderUpdater;
            _userIdFromClaimsExpander = userIdFromClaimsExpander;
            _userProvider = userProvider;
        }

        [HttpGet("order/{id:Guid}")]
        [ProducesResponseType(200, Type = typeof(GetOrderResponseModel))]
        public async Task<ActionResult> GetOrder(Guid id)
        {
            try
            {
                IGetOrderByIdRequest getOrderByIdRequest = new GetOrderByIdRequest(id);
                IGetOrderResponse getOrderResponse = await _orderProvider.GetOrderById(getOrderByIdRequest);

                IGetOrderPositionsResponse getOrderPositionsResponse = await _orderPositionsProvider.GetOrderPositionsByOrderId(new GetOrderPositionsByOrderIdRequest(id));
                
                return getOrderResponse.Result switch
                {
                    OrderProvideResultEnum.Success => (ActionResult) Ok(new GetOrderResponseModel
                    {
                        Order = _objectToApiModelConverter.ConvertOrder(getOrderResponse.Order),
                        Restaurant = _objectToApiModelConverter.ConvertRestaurant(_restaurantProvider.GetRestaurant(new GetRestaurantRequest(getOrderResponse.Order.RestaurantId)).Result.Restaurant),
                        OrderPositions = getOrderPositionsResponse.OrderPositions.Select( x=>
                            new ExtendedOrderPositionApiModel
                            {
                                Id = x.Id,
                                CreationDate = x.CreationDate,
                                MealId = x.MealId,
                                Meal = _objectToApiModelConverter.ConvertMeal(_mealProvider.GetMealById(new GetMealByIdRequest(x.MealId))?.Result?.Meal),
                                UserId = x.UserId,
                                OrderId = x.OrderId,
                                User = _objectToApiModelConverter.ConvertUser(_userProvider.GetUserById(new ProvideUserRequest(x.UserId))?.Result?.User)                           
                            }).ToList(),
                        OrderBoy =_objectToApiModelConverter.ConvertUser(_userProvider.GetUserById( new ProvideUserRequest(getOrderResponse.Order.OrderBoyId)).Result.User)
                    }),
                    OrderProvideResultEnum.NotFound => NotFound(),
                    OrderProvideResultEnum.Exception => StatusCode(500),
                    OrderProvideResultEnum.Forbidden => Forbid(),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }
        }

        [HttpGet("orders")]
        [ProducesResponseType(200, Type = typeof(GetOrdersResponseModel))]
        public async Task<ActionResult> GetOrders()
        {
            try
            {
                IGetOrdersResponse getOrdersResponse = await _orderProvider.GetOrders();
                return getOrdersResponse.Result switch
                {
                    OrderProvideResultEnum.Exception => StatusCode(500),
                    OrderProvideResultEnum.Forbidden => (ActionResult)Forbid(),
                    OrderProvideResultEnum.NotFound => NotFound(),
                    OrderProvideResultEnum.Success => Ok(getOrdersResponse.Order.Select(_objectToApiModelConverter.ConvertOrder)),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }
        }

        //TODO Endpoint mark as ordered order

        [HttpPut("order/{id:Guid}/ordered")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> MarkAsOrdered(Guid id)
        {
            try
            {
                IOrderUpdateResponse orderUpdateResponse = await _orderUpdater.MarkOrderAsOrdered(new OrderUpdateRequest(id,
                    _userIdFromClaimsExpander.ExpandIdFromClaims(HttpContext.User)));
                return orderUpdateResponse.Result switch
                {
                    UpdateOrderResultEnum.Exception => StatusCode(500),
                    UpdateOrderResultEnum.Forbidden => StatusCode(403),
                    UpdateOrderResultEnum.NotFound => StatusCode(404),
                    UpdateOrderResultEnum.Success => Ok(),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }
        }
    }
}
