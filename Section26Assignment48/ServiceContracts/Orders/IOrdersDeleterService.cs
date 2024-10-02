using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.Order
{
    public interface IOrdersDeleterService
    {
        Task<bool> DeleteOrderByOrderId(Guid orderId);

    }
}
