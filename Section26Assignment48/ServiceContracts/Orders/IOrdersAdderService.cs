using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Order
{
    public interface IOrdersAdderService
    {
        Task<OrderResponse> AddOrder(OrderAddRequest orderRequest);

    }
}
