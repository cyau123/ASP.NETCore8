using Microsoft.Extensions.Logging;
using RepositoryContracts;
using ServiceContracts.OrderItems;

namespace OrderManagement.Services
{
    /// <summary>
    /// Service class for deleting order items.
    /// </summary>
    public class OrderItemsDeleterService : IOrderItemsDeleterService
    {
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly ILogger<OrderItemsDeleterService> _logger;

        public OrderItemsDeleterService(IOrderItemsRepository orderItemsRepository, ILogger<OrderItemsDeleterService> logger)
        {
            _orderItemsRepository = orderItemsRepository;
            _logger = logger;
        }


        /// <inheritdoc />
        public async Task<bool> DeleteOrderItemByOrderItemId(Guid orderItemId)
        {
            _logger.LogInformation($"Deleting order item with ID: {orderItemId}...");

            // Delete the order item by its Order Item ID
            var isDeleted = await _orderItemsRepository.DeleteOrderItemByOrderItemId(orderItemId);

            if (isDeleted)
            {
                _logger.LogInformation($"Order item deleted successfully. ID: {orderItemId}.");
            }
            else
            {
                _logger.LogWarning($"Order item not found for deletion. ID: {orderItemId}.");
            }

            return isDeleted;
        }
    }
}