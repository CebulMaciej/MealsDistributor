using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.OrdersPositions.Abstract;
using Domain.Providers.OrdersPositions.Request.Abstract;
using Domain.Providers.OrdersPositions.Request.Concrete;
using Domain.Providers.OrdersPositions.Response.Abstract;
using Domain.Providers.OrdersPositions.Response.Const;
using MealsDistributor.Infrastructure.IdFromClaimsExpanding.Abstract;
using MealsDistributor.Model.Request.OrderPosition;
using MealsDistributor.Model.Response.OrderPosition;
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

        public OrderPositionsController(ILogger logger, IOrderPositionsProvider orderPositionsProvider, IUserIdFromClaimsExpander userIdFromClaimsExpander)
        {
            _logger = logger;
            _orderPositionsProvider = orderPositionsProvider;
            _userIdFromClaimsExpander = userIdFromClaimsExpander;
        }

        [HttpGet("/order/{id:Guid}/order-position")]
        [ProducesResponseType(200, Type = typeof(GetOrderPositionResponseModel))]
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
        [ProducesResponseType(200, Type = typeof(GetOrderPositionsResponseModel))]
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
                OrderPositionProvideResult.Success => (ActionResult) Ok(getOrderPositionsResponse.OrderPositions),
                OrderPositionProvideResult.NotFound => NotFound(),
                OrderPositionProvideResult.Exception => StatusCode(500),
                OrderPositionProvideResult.Forbidden => Forbid(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

    }
}
