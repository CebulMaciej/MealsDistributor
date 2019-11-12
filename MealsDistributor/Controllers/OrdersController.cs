using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Infrastructure.Logging.Abstract;
using MealsDistributor.Model.Response.Order;
using Microsoft.AspNetCore.Mvc;

namespace MealsDistributor.Controllers
{
    [Route("api")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly ILogger _logger;

        public OrdersController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet("order/{id:int}")]
        [ProducesResponseType(200, Type = typeof(GetOrderResponseModel))]
        public Task<ActionResult> GetOrder(int id)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }

            return null;
        }

        [HttpGet("orders")]
        [ProducesResponseType(200, Type = typeof(GetOrdersResponseModel))]
        public Task<ActionResult> GetOrders()
        {
            try
            {
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }

            return null;
        }
    }
}
