using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Creators.OrderPropositions.Abstract;
using Domain.Creators.OrderPropositions.Request.Abstract;
using Domain.Creators.OrderPropositions.Request.Concrete;
using Domain.Creators.OrderPropositions.Response.Abstract;
using Domain.Creators.OrderPropositions.Response.Const;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Infrastructure.OrderPropositionRealizing.Abstract;
using Domain.Infrastructure.OrderPropositionRealizing.Request.Abstract;
using Domain.Infrastructure.OrderPropositionRealizing.Request.Concrete;
using Domain.Infrastructure.OrderPropositionRealizing.Response;
using Domain.Infrastructure.OrderPropositionRealizing.Response.Abstract;
using Domain.Providers.Meals.Abstract;
using Domain.Providers.Meals.Request.Concrete;
using Domain.Providers.OrderPropositionPositions.Abstract;
using Domain.Providers.OrderPropositionPositions.Request.Concrete;
using Domain.Providers.OrderPropositionPositions.Response.Abstract;
using Domain.Providers.OrderPropositions.Abstract;
using Domain.Providers.OrderPropositions.Request.Abstract;
using Domain.Providers.OrderPropositions.Request.Concrete;
using Domain.Providers.OrderPropositions.Response.Abstract;
using Domain.Providers.OrderPropositions.Response.Const;
using Domain.Providers.Restaurants.Abstract;
using Domain.Providers.Restaurants.Request.Concrete;
using Domain.Providers.Users.Abstract;
using Domain.Providers.Users.Request.Concrete;
using Domain.Providers.Users.Response.Abstract;
using MealsDistributor.Infrastructure.IdFromClaimsExpanding.Abstract;
using MealsDistributor.Infrastructure.ObjectsToModelConverting.Abstract;
using MealsDistributor.Model.ApiModels;
using MealsDistributor.Model.Request.OrderProposition;
using MealsDistributor.Model.Response.OrderProposition;
using MealsDistributor.Model.Response.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MealsDistributor.Controllers
{
    [Route("api")]
    [ApiController]
    public class OrderPropositionController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserIdFromClaimsExpander _userIdFromClaimsExpander;
        private readonly IOrderPropositionsProvider _orderPropositionsProvider;
        private readonly IOrderPropositionsCreator _orderPropositionsCreator;
        private readonly IOrderPropositionRealizator _orderPropositionRealizator;
        private readonly IObjectToApiModelConverter _objectToApiModelConverter;
        private readonly IOrderPropositionsPositionsProvider _orderPropositionsPositionsProvider;
        private readonly IMealProvider _mealProvider;
        private readonly IRestaurantProvider _restaurantProvider;
        private readonly IUserProvider _userProvider;

        // TODO w  calym kontrolerze ogarnij zwracane obiekty - obiekty maja zawierać dopiero elementy - done
        public OrderPropositionController(ILogger logger, IUserIdFromClaimsExpander userIdFromClaimsExpander, IOrderPropositionsProvider orderPropositionsProvider, IOrderPropositionsCreator orderPropositionsCreator, IOrderPropositionRealizator orderPropositionRealizator, IObjectToApiModelConverter objectToApiModelConverter, IOrderPropositionsPositionsProvider orderPropositionsPositionsProvider, IMealProvider mealProvider, IRestaurantProvider restaurantProvider,IUserProvider userProvider)
        {
            _logger = logger;
            _userIdFromClaimsExpander = userIdFromClaimsExpander;
            _orderPropositionsProvider = orderPropositionsProvider;
            _orderPropositionsCreator = orderPropositionsCreator;
            _orderPropositionRealizator = orderPropositionRealizator;
            _objectToApiModelConverter = objectToApiModelConverter;
            _orderPropositionsPositionsProvider = orderPropositionsPositionsProvider;
            _mealProvider = mealProvider;
            _restaurantProvider = restaurantProvider;
            _userProvider = userProvider;
        }

        [HttpGet("order-propositions/participated")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(GetOrderPropositionsResponseModel))]
        public async Task<ActionResult> GetOrderPropositionInWhichUserTakePart()
        {
            try
            {
                Guid loggedInUserId = _userIdFromClaimsExpander.ExpandIdFromClaims(HttpContext.User);

                IGetOrderPropositionsInWhichUserTakePartsRequest getOrderPropositionsInWhichUserTakePartsRequest = 
                    new GetOrderPropositionsInWhichUserTakePartsRequest(loggedInUserId);

                IGetOrderPropositionsResponse getOrderPropositionsResponse =
                    await _orderPropositionsProvider.GetOrderPropositionsInWhichUserTakeParts(
                        getOrderPropositionsInWhichUserTakePartsRequest);

                return PrepareResponseAfterGetOrderPropositions(getOrderPropositionsResponse);

            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }

        }

        [HttpGet("order-proposition/{id:Guid}")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(GetOrderPropositionResponse))]
        public async Task<ActionResult> GetOrderPropositionById(Guid id)
        {
            try
            {
                Guid loggedInUserId = _userIdFromClaimsExpander.ExpandIdFromClaims(HttpContext.User);


                IGetOrderPropositionResponse response =
                    await _orderPropositionsProvider.GetOrderPropositionById(new GetOrderPropositionByIdRequest(id));

                IGetOrderPropositionPositionsResponse getOrderPropositionPositionsResponse = await _orderPropositionsPositionsProvider.GetOrderPropositionPositionsByOrderPropositionId(
                    new GetOrderPropositionPositionByOrderPropositionIdRequest(id));

                switch (response.Result)
                {
                    case OrderPropositionsProvideResultEnum.Success:
                        return Ok(new GetOrderPropositionResponse
                        {
                            Creator = _objectToApiModelConverter.ConvertUser(_userProvider.GetUserById(new ProvideUserRequest(response.OrderProposition.CreatorID)).Result.User),
                            Restaurant = _objectToApiModelConverter.ConvertRestaurant(_restaurantProvider.GetRestaurant(new GetRestaurantRequest(response.OrderProposition.RestaurantId)).Result.Restaurant),
                            
                            OrderProposition = _objectToApiModelConverter.ConvertOrderProposition(response.OrderProposition),
                            Positions = getOrderPropositionPositionsResponse.OrderPropositionPositions.Select(x => new ExtendedOrderPropositionPositionApiModel
                            {
                                MealId = x.MealId,
                                Id = x.Id,
                                CreationDate = x.CreationDate,
                                Meal = _objectToApiModelConverter.ConvertMeal(_mealProvider.GetMealById(new GetMealByIdRequest(x.MealId)).Result.Meal),
                                OrderPropositionId = x.OrderPropositionId,
                                UserId = x.UserId,
                                User = _objectToApiModelConverter.ConvertUser(_userProvider.GetUserById(new ProvideUserRequest(x.UserId)).Result.User)
                            }).ToList()
                        });
                    case OrderPropositionsProvideResultEnum.NotFound:
                        return StatusCode(404);
                    case OrderPropositionsProvideResultEnum.Exception:
                        return StatusCode(500);
                    case OrderPropositionsProvideResultEnum.Forbidden:
                        return StatusCode(403);
                    default:
                        throw new ArgumentOutOfRangeException();
                };

            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }

        }

        [HttpGet("order-propositions/available")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(GetOrderPropositionsResponseModel))]
        public async Task<ActionResult> GetActualAvailableOrderPropositions()
        {
            try
            {


                IGetOrderPropositionsResponse getOrderPropositionsResponse =
                    await _orderPropositionsProvider.GetActualOrderPropositions();

                return PrepareResponseAfterGetOrderPropositions(getOrderPropositionsResponse);

            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }

        }
        [HttpPost("order-proposition")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(OrderPropositionApiModel))]
        public async Task<ActionResult> CreateNewOrderProposition(CreateOrderPropositionRequestModel request)
        {
            try
            {
                Guid loggedInUserId = _userIdFromClaimsExpander.ExpandIdFromClaims(HttpContext.User);

                IOrderPropositionCreationRequest orderPropositionCreationRequest = new OrderPropositionCreationRequest(loggedInUserId, request.RestaurantId, request.OrderingTime);

                IOrderPropositionCreationResponse orderPropositionCreationResponse = await _orderPropositionsCreator.CreateOrderProposition(orderPropositionCreationRequest);

                return orderPropositionCreationResponse.Result switch
                {
                    OrderPropositionCreationResultEnum.Success => (ActionResult) Ok(
                        _objectToApiModelConverter.ConvertOrderProposition(orderPropositionCreationResponse.OrderProposition)),
                    OrderPropositionCreationResultEnum.AlreadyExists => Conflict(),
                    OrderPropositionCreationResultEnum.Exception => StatusCode(500),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }

        }

        [HttpPost("order-proposition/{id:Guid}/realize")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(Order))]
        public async Task<ActionResult> ConvertPropositionToOrder(Guid id)
        {
            try
            {
                Guid loggedInUserId = _userIdFromClaimsExpander.ExpandIdFromClaims(HttpContext.User);

                IRealizeOrderPropositionRequest realizeOrderPropositionRequest = new RealizeOrderPropositionRequest(id,loggedInUserId);
                IRealizeOrderPropositionResponse realizeOrderPropositionResponse = await _orderPropositionRealizator.RealizeOrderProposition(realizeOrderPropositionRequest);
                return realizeOrderPropositionResponse.Result switch
                {
                    RealizeOrderPropositionResult.Exception => (ActionResult) StatusCode(500),
                    RealizeOrderPropositionResult.Forbidden => Forbid(),
                    RealizeOrderPropositionResult.NotFound => NotFound(),
                    RealizeOrderPropositionResult.Success => Ok(_objectToApiModelConverter.ConvertOrder(realizeOrderPropositionResponse.Order)),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }

        }

        //TODO operations to reject orderProposition and block - moze wcale?

        private ActionResult PrepareResponseAfterGetOrderPropositions(IGetOrderPropositionsResponse getOrderPropositionsResponse)
        {
            switch (getOrderPropositionsResponse.Result)
            {
                case OrderPropositionsProvideResultEnum.Success:
                    return Ok(new GetOrderPropositionsResponseModel
                    {

                        OrderPropositions =
                     getOrderPropositionsResponse.OrderPropositions.Select(_objectToApiModelConverter.ConvertOrderProposition).ToList()
                    });
                case OrderPropositionsProvideResultEnum.NotFound:
                    return NotFound();
                case OrderPropositionsProvideResultEnum.Exception:
                    return StatusCode(500);
                case OrderPropositionsProvideResultEnum.Forbidden:
                    return Forbid();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}