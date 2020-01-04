using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Providers.Orders.Request.Abstract;
using Domain.Providers.Orders.Response.Abstract;

namespace Domain.Providers.Orders.Abstract
{
    public interface IOrderProvider
    {
        Task<IGetOrderResponse> GetOrderById(IGetOrderByIdRequest request);
        Task<IGetOrdersResponse> GetOrders();
    }
}
