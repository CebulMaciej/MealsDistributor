using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.Orders.Abstract;
using Domain.Providers.Orders.Request.Abstract;
using Domain.Providers.Orders.Request.Concrete;
using Domain.Providers.Orders.Response.Abstract;
using Domain.Providers.Orders.Response.Const;
using MealsDistributor.Model.Response.Order;
using Microsoft.AspNetCore.Mvc;

namespace MealsDistributor.Controllers
{
    [Route("api")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IOrderProvider _orderProvider;

        public OrdersController(ILogger logger, IOrderProvider orderProvider)
        {
            _logger = logger;
            _orderProvider = orderProvider;
        }

        [HttpGet("order/{id:Guid}")]
        [ProducesResponseType(200, Type = typeof(GetOrderResponseModel))]
        public async Task<ActionResult> GetOrder(Guid id)
        {
            try
            {
                IGetOrderByIdRequest getOrderByIdRequest = new GetOrderByIdRequest(id);
                IGetOrderResponse getOrderResponse = await _orderProvider.GetOrderById(getOrderByIdRequest);
                return getOrderResponse.Result switch
                {
                    OrderProvideResultEnum.Success => (ActionResult) Ok(getOrderResponse.Order),
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
                    OrderProvideResultEnum.Success => Ok(getOrdersResponse.Order),
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
