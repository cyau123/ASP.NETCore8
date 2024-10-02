using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.OrderItems
{
    public interface IOrderItemsGetterService
    {
        Task<List<OrderItemResponse>> GetAllOrderItems();

        Task<List<OrderItemResponse>> GetOrderItemsByOrderId(Guid orderId);
        Task<OrderItemResponse?> GetOrderItemByOrderItemId(Guid orderItemId);

    }
}
