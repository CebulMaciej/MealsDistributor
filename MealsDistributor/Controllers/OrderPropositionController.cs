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
using Domain.Providers.OrderPropositions.Abstract;
using Domain.Providers.OrderPropositions.Request.Abstract;
using Domain.Providers.OrderPropositions.Request.Concrete;
using Domain.Providers.OrderPropositions.Response.Abstract;
using Domain.Providers.OrderPropositions.Response.Const;
using Domain.Providers.Users.Request.Concrete;
using Domain.Providers.Users.Response.Abstract;
using MealsDistributor.Infrastructure.IdFromClaimsExpanding.Abstract;
using MealsDistributor.Model.Request.OrderProposition;
using MealsDistributor.Model.Response.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealsDistributor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderPropositionController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserIdFromClaimsExpander _userIdFromClaimsExpander;
        private readonly IOrderPropositionsProvider _orderPropositionsProvider;
        private readonly IOrderPropositionsCreator _orderPropositionsCreator;
        private readonly IOrderPropositionRealizator _orderPropositionRealizator;

        public OrderPropositionController(ILogger logger, IUserIdFromClaimsExpander userIdFromClaimsExpander, IOrderPropositionsProvider orderPropositionsProvider, IOrderPropositionsCreator orderPropositionsCreator, IOrderPropositionRealizator orderPropositionRealizator)
        {
            _logger = logger;
            _userIdFromClaimsExpander = userIdFromClaimsExpander;
            _orderPropositionsProvider = orderPropositionsProvider;
            _orderPropositionsCreator = orderPropositionsCreator;
            _orderPropositionRealizator = orderPropositionRealizator;
        }

        [HttpGet("currentOrderPropositionsTakingPart")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(IList<OrderProposition>))]
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

        [HttpGet("actualAvailableOrderPropositions")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(IList<OrderProposition>))]
        public async Task<ActionResult> GetActualAvailableOrderPropositions()
        {
            try
            {
                Guid loggedInUserId = _userIdFromClaimsExpander.ExpandIdFromClaims(HttpContext.User);


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
        [HttpPost]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(IList<OrderProposition>))]
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
                        orderPropositionCreationResponse.OrderProposition),
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

        [HttpPost("{id:Guid}/realize")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(IList<OrderProposition>))]
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
                    RealizeOrderPropositionResult.Success => Ok(realizeOrderPropositionResponse.Order),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }

        }

        //TODO operations to reject orderProposition and block

        private ActionResult PrepareResponseAfterGetOrderPropositions(IGetOrderPropositionsResponse getOrderPropositionsResponse)
        {
            switch (getOrderPropositionsResponse.Result)
            {
                case OrderPropositionsProvideResultEnum.Success:
                    return Ok(getOrderPropositionsResponse.OrderPropositions);
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