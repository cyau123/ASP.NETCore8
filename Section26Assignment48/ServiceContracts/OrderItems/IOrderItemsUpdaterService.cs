using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.OrderItems
{
    public interface IOrderItemsUpdaterService
    {
        Task<OrderItemResponse> UpdateOrderItem(OrderItemUpdateRequest orderItemRequest);

    }
}
