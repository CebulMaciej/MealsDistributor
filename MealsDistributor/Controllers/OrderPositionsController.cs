using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Infrastructure.Logging.Abstract;
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

        public OrderPositionsController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet("order-position/{id:int}")]
        [ProducesResponseType(200, Type = typeof(GetOrderPositionResponseModel))]
        public Task<ActionResult> GetOrderPosition(int id)
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

        [HttpGet("order-positions")]
        [ProducesResponseType(200, Type = typeof(GetOrderPositionsResponseModel))]
        public Task<ActionResult> GetOrderPositions()
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

        [HttpPost("order-position")]
        [ProducesResponseType(200)]
        public Task<ActionResult> AddOrderPosition(AddOrderPositionRequestModel requestModel)
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

        [HttpDelete("order-position/{id:int}")]
        [ProducesResponseType(200)]
        public Task<ActionResult> DeleteOrderPosition(int id)
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
