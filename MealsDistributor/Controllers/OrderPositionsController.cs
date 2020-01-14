using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.Meals.Abstract;
using Domain.Providers.Meals.Request.Concrete;
using Domain.Providers.OrdersPositions.Abstract;
using Domain.Providers.OrdersPositions.Request.Abstract;
using Domain.Providers.OrdersPositions.Request.Concrete;
using Domain.Providers.OrdersPositions.Response.Abstract;
using Domain.Providers.OrdersPositions.Response.Const;
using Domain.Providers.Users.Abstract;
using Domain.Providers.Users.Request.Concrete;
using MealsDistributor.Infrastructure.IdFromClaimsExpanding.Abstract;
using MealsDistributor.Infrastructure.ObjectsToModelConverting.Abstract;
using MealsDistributor.Model.ApiModels;
using MealsDistributor.Model.Request.OrderPosition;
using MealsDistributor.Model.Response.OrderPosition;
using MealsDistributor.Model.Response.OrderPropositionPosition;
using Microsoft.AspNetCore.Mvc;

namespace MealsDistributor.Controllers
{
    [Route("api")]
    [ApiController]
    public class OrderPositionsController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IOrderPositionsProvider _orderPositionsProvider;
        private readonly IUserIdFromClaimsExpander _userIdFromClaimsExpander;
        private readonly IObjectToApiModelConverter _objectToApiModelConverter;
        private readonly IUserProvider _userProvider;
        private readonly IMealProvider _mealProvider;

        public OrderPositionsController(ILogger logger, IOrderPositionsProvider orderPositionsProvider, IUserIdFromClaimsExpander userIdFromClaimsExpander, IObjectToApiModelConverter objectToApiModelConverter, IUserProvider userProvider,IMealProvider mealProvider)
        {
            _logger = logger;
            _orderPositionsProvider = orderPositionsProvider;
            _userIdFromClaimsExpander = userIdFromClaimsExpander;
            _objectToApiModelConverter = objectToApiModelConverter;
            _userProvider = userProvider;
            _mealProvider = mealProvider;
        }

        [HttpGet("order/{id:Guid}/order-positions")]
        [ProducesResponseType(200, Type = typeof(GetExtendedOrderPositionsResponseModel))]
        public async Task<ActionResult> GetOrderPosition(Guid id)
        {
            try
            {
                IGetOrderPositionsByOrderIdRequest getOrderPositionsByOrderIdRequest = new GetOrderPositionsByOrderIdRequest(id);
                IGetOrderPositionsResponse getOrderPositionsResponse = await _orderPositionsProvider.GetOrderPositionsByOrderId(getOrderPositionsByOrderIdRequest);
                return PrepareResponseAfterGetOrderPositions(getOrderPositionsResponse);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }

        }

        [HttpGet("order-positions")]
        [ProducesResponseType(200, Type = typeof(GetExtendedOrderPositionsResponseModel))]
        public async Task<ActionResult> GetOrderPositions()
        {
            try
            {
                IGetOrderPositionsByUserIdRequest getOrderPositionsByUserIdRequest = new GetOrderPositionsByUserIdRequest(_userIdFromClaimsExpander.ExpandIdFromClaims(HttpContext.User));
                IGetOrderPositionsResponse getOrderPositionsResponse = await _orderPositionsProvider.GetOrderPositionsByUserId(getOrderPositionsByUserIdRequest);
                return PrepareResponseAfterGetOrderPositions(getOrderPositionsResponse);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }
        }

        private ActionResult PrepareResponseAfterGetOrderPositions(IGetOrderPositionsResponse getOrderPositionsResponse)
        {
            return getOrderPositionsResponse.OrderPositionProvideResult switch
            {
                OrderPositionProvideResult.Success => (ActionResult) Ok(new
                GetExtendedOrderPositionsResponseModel
                {
                    OrderPositions = getOrderPositionsResponse.OrderPositions.Select( x=>
                        new ExtendedOrderPositionApiModel
                        {
                            CreationDate = x.CreationDate,
                            UserId = x.UserId,
                            Id = x.Id,
                            Meal = _objectToApiModelConverter.ConvertMeal(_mealProvider.GetMealById(new GetMealByIdRequest(x.MealId)).Result.Meal),
                            MealId = x.MealId,
                            OrderId = x.OrderId,
                            User = _objectToApiModelConverter.ConvertUser(_userProvider.GetUserById(new ProvideUserRequest(x.UserId)).Result.User)
                        }).ToList()//_objectToApiModelConverter.ConvertOrderPosition).ToList()
                }),
                OrderPositionProvideResult.NotFound => NotFound(),
                OrderPositionProvideResult.Exception => StatusCode(500),
                OrderPositionProvideResult.Forbidden => Forbid(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

    }
}
