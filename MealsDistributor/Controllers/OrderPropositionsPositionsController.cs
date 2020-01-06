using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Creators.OrderPropositions.Request.Abstract;
using Domain.Creators.OrderPropositions.Request.Concrete;
using Domain.Creators.OrderPropositions.Response.Abstract;
using Domain.Creators.OrderPropositions.Response.Const;
using Domain.Creators.OrderPropositionsPositions.Abstract;
using Domain.Creators.OrderPropositionsPositions.Request.Abstract;
using Domain.Creators.OrderPropositionsPositions.Request.Concrete;
using Domain.Creators.OrderPropositionsPositions.Response.Abstract;
using Domain.Creators.OrderPropositionsPositions.Response.Const;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.OrderPropositionPositions.Abstract;
using Domain.Providers.OrderPropositionPositions.Request.Abstract;
using Domain.Providers.OrderPropositionPositions.Request.Concrete;
using Domain.Providers.OrderPropositionPositions.Response.Abstract;
using Domain.Providers.OrderPropositionPositions.Response.Const;
using Domain.Providers.OrderPropositions.Request.Abstract;
using Domain.Providers.OrderPropositions.Request.Concrete;
using Domain.Providers.OrderPropositions.Response.Abstract;
using MealsDistributor.Infrastructure.IdFromClaimsExpanding.Abstract;
using MealsDistributor.Model.Request.OrderProposition;
using MealsDistributor.Model.Request.OrderPropositionPosition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealsDistributor.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OrderPropositionsPositionsController : ControllerBase
    {
        private readonly IOrderPropositionsPositionsCreator _orderPropositionsPositionsCreator;
        private readonly IOrderPropositionsPositionsProvider _orderPropositionsPositionsProvider;
        private readonly IUserIdFromClaimsExpander _userIdFromClaimsExpander;
        private readonly ILogger _logger;
        public OrderPropositionsPositionsController(IOrderPropositionsPositionsCreator orderPropositionsPositionsCreator, IOrderPropositionsPositionsProvider orderPropositionsPositionsProvider, ILogger logger, IUserIdFromClaimsExpander userIdFromClaimsExpander)
        {
            _orderPropositionsPositionsCreator = orderPropositionsPositionsCreator;
            _orderPropositionsPositionsProvider = orderPropositionsPositionsProvider;
            _logger = logger;
            _userIdFromClaimsExpander = userIdFromClaimsExpander;
        }

        [HttpGet("orderProposition/{id:Guid}/position")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(IList<OrderProposition>))]
        public async Task<ActionResult> GetOrderPropositionPositionsByOrderPropositionId(Guid id)
        {
            try
            {
                IGetOrderPropositionPositionByOrderPropositionIdRequest request = new GetOrderPropositionPositionByOrderPropositionIdRequest(id);
                IGetOrderPropositionPositionsResponse getOrderPropositionPositionsByOrderPropositionIdResponse = await _orderPropositionsPositionsProvider.GetOrderPropositionPositionsByOrderPropositionId(request);

                return getOrderPropositionPositionsByOrderPropositionIdResponse
                        .GetOrderPropositionPositionsResult switch
                    {
                        GetOrderPropositionPositionsResult.Success => (ActionResult) Ok(
                            getOrderPropositionPositionsByOrderPropositionIdResponse.OrderPropositionPositions),
                        GetOrderPropositionPositionsResult.NotFound => NotFound(),
                        GetOrderPropositionPositionsResult.Exception => StatusCode(500),
                        GetOrderPropositionPositionsResult.Forbidden => Forbid(),
                        _ => throw new ArgumentOutOfRangeException()
                    };
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }

        }

        
        [HttpPost("orderProposition/{orderPropositionId:Guid}/position")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(IList<OrderPropositionPosition>))]
        public async Task<ActionResult> CreateNewOrderPropositionPosition(Guid orderPropositionId, CreateOrderPropositionPositionRequest createOrderPropositionPositionRequest)
        {
            try
            {
                IOrderPropositionPositionCreateRequest createRequest = new OrderPropositionPositionCreateRequest(
                    _userIdFromClaimsExpander.ExpandIdFromClaims(HttpContext.User), createOrderPropositionPositionRequest.MealId,
                    orderPropositionId);
                IOrderPropositionPositionCreateResponse orderPropositionPositionCreateResponse = await _orderPropositionsPositionsCreator.CreateOrderPropositionPosition(createRequest);
                return orderPropositionPositionCreateResponse.Result switch
                {
                    OrderPropositionPositionCreateResultEnum.Success => (ActionResult) Ok(
                        orderPropositionPositionCreateResponse.OrderPropositionPosition),
                    OrderPropositionPositionCreateResultEnum.AlreadyExists => Conflict(),
                    OrderPropositionPositionCreateResultEnum.Exception => StatusCode(500),
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