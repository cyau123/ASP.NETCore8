using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryContracts;

namespace Repositories
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<OrderItemsRepository> _logger;

        public OrderItemsRepository(ApplicationDbContext db, ILogger<OrderItemsRepository> logger)
        {
            _db = db;
            _logger = logger;
        }
        public async Task<OrderItem> AddOrderItem(OrderItem orderItem)
        {
            _logger.LogInformation("Adding order item to the database...");
            _db.OrderItems.Add(orderItem);
            await _db.SaveChangesAsync();
            _logger.LogInformation("Order item with ID {OrderItemId} added to the database.", orderItem.OrderItemId);
            return orderItem;
        }

        public async Task<bool> DeleteOrderItemByOrderItemId(Guid orderItemId)
        {
            _logger.LogInformation("Deleting order item from the database...");

            // Find the order item with the specified ID
            var orderItem = await _db.OrderItems.FindAsync(orderItemId);
            if (orderItem == null)
            {
                _logger.LogWarning($"Order item not found with ID: {orderItemId}.");
                return false;
            }

            // Remove the order item from the database context
            _db.OrderItems.Remove(orderItem);

            // Save the changes to the database
            await _db.SaveChangesAsync();

            _logger.LogInformation("Order item with ID {OrderItemId} deleted from the database.", orderItemId);

            return true;
        }

        public async Task<List<OrderItem>> GetAllOrderItems()
        {
            _logger.LogInformation("Retrieving all order items...");

            // Retrieve all order items from the database and order them by OrderId
            var orderItems = await _db.OrderItems.OrderBy(temp => temp.OrderId).ToListAsync();

            _logger.LogInformation($"Retrieved {orderItems.Count} order items successfully.");

            return orderItems;
        }

        public Task<List<OrderItem>> GetOrderItemsByOrderId(Guid orderId)
        {
            var orderItems = _db.OrderItems.Where(oi => oi.OrderId == orderId).ToListAsync();
            return orderItems;
        }

        public async Task<OrderItem?> GetOrderItemByOrderItemId(Guid orderItemId)
        {
            _logger.LogInformation("Retrieving order item by OrderItemId...");

            // Retrieve an order item based on its OrderItemId
            var orderItem = await _db.OrderItems.FindAsync(orderItemId);

            if (orderItem == null)
            {
                _logger.LogWarning($"Order item not found with ID: {orderItemId}.");
            }
            else
            {
                _logger.LogInformation("Order item retrieved successfully.");
            }

            return orderItem;
        }

        public async Task<OrderItem> UpdateOrderItem(OrderItem orderItem)
        {
            _logger.LogInformation("Updating order item in the database...");

            // Find the existing order item in the database
            var existingOrderItem = await _db.OrderItems.FindAsync(orderItem.OrderItemId);
            if (existingOrderItem == null)
            {
                throw new ArgumentException($"Order item with ID {orderItem.OrderItemId} does not exist.");
            }

            // Update the properties of the existing order item with the new values
            existingOrderItem.OrderId = orderItem.OrderId;
            existingOrderItem.ProductName = orderItem.ProductName;
            existingOrderItem.Quantity = orderItem.Quantity;
            existingOrderItem.UnitPrice = orderItem.UnitPrice;
            existingOrderItem.TotalPrice = orderItem.TotalPrice;

            // Save the changes to the database
            await _db.SaveChangesAsync();

            _logger.LogInformation("Order item with ID {OrderItemId} updated in the database.", orderItem.OrderItemId);

            return existingOrderItem;
        }
    }
}
