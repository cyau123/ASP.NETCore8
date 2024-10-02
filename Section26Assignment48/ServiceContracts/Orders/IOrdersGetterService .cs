using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Order
{
    public interface IOrdersGetterService
    {
        Task<List<OrderResponse>> GetAllOrders();
        Task<OrderResponse?> GetOrderByOrderId(Guid orderId);

    }
}
