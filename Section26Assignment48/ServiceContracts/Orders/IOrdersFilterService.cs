using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Order
{
    public interface IOrdersFilterService
    {
        Task<List<OrderResponse>> GetFilteredOrders(string searchBy, string? searchString);

    }
}
