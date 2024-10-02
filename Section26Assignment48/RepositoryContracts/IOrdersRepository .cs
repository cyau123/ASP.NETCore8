using Entities;
using System.Linq.Expressions;

namespace RepositoryContracts
{
    public interface IOrdersRepository
    {
        Task<Order> AddOrder(Order order);
        Task<bool> DeleteOrderByOrderId(Guid orderId);
        Task<List<Order>> GetAllOrders();
        Task<Order?> GetOrderByOrderId(Guid orderId);
        Task<Order> UpdateOrder(Order order);

        Task<List<Order>> GetFilteredOrders(Expression<Func<Order, bool>> predicate);
    }
}
