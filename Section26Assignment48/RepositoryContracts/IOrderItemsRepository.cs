using Entities;

namespace RepositoryContracts
{
    public interface IOrderItemsRepository
    {
        Task<OrderItem> AddOrderItem(OrderItem orderItem);
        Task<List<OrderItem>> GetAllOrderItems();
        Task<List<OrderItem>> GetOrderItemsByOrderId(Guid orderId);
        Task<OrderItem?> GetOrderItemByOrderItemId(Guid orderItemId);
        Task<OrderItem> UpdateOrderItem(OrderItem orderItem);
        Task<bool> DeleteOrderItemByOrderItemId(Guid orderItemId);
    }
}
