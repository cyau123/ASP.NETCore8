using ServiceContracts.DTO;

namespace ServiceContracts.OrderItems
{
    public interface IOrderItemsAdderService
    {
        Task<OrderItemResponse> AddOrderItem(OrderItemAddRequest orderItemRequest);

    }
}
