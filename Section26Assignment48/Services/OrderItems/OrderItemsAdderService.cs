using Microsoft.Extensions.Logging;
using RepositoryContracts;
using ServiceContracts.DTO;
using ServiceContracts.OrderItems;

namespace OrderManagement.Services
{
    /// <summary>
    /// Service class for adding order items.
    /// </summary>
    public class OrderItemsAdderService : IOrderItemsAdderService
    {
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly ILogger<OrderItemsAdderService> _logger;

        public OrderItemsAdderService(IOrderItemsRepository orderItemsRepository, ILogger<OrderItemsAdderService> logger)
        {
            _orderItemsRepository = orderItemsRepository;
            _logger = logger;
        }


        /// <inheritdoc/>
        public async Task<OrderItemResponse> AddOrderItem(OrderItemAddRequest orderItemRequest)
        {
            _logger.LogInformation("Adding order item...");

            // Convert the request DTO to an OrderItem entity
            var orderItem = orderItemRequest.ToOrderItem();

            // Generate a new OrderItemId
            orderItem.OrderItemId = Guid.NewGuid();

            // Add the order item to the repository
            var addedOrderItem = await _orderItemsRepository.AddOrderItem(orderItem);

            _logger.LogInformation($"Order item added successfully. Order Item ID: {addedOrderItem.OrderItemId}.");

            // Convert the added order item to a response DTO
            return addedOrderItem.ToOrderItemResponse();
        }
    }
}