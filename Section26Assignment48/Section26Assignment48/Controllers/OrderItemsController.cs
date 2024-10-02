using Microsoft.AspNetCore.Mvc;
using ServiceContracts.DTO;
using ServiceContracts.OrderItems;

namespace Section26Assignment48.Controllers
{
    [ApiController]
    [Route("api/orders/{orderId}/items")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemsGetterService _orderItemsGetterService;
        private readonly IOrderItemsAdderService _orderItemsAdderService;
        private readonly IOrderItemsUpdaterService _orderItemsUpdaterService;
        private readonly IOrderItemsDeleterService _orderItemsDeleterService;
        private readonly ILogger<OrderItemsController> _logger;

        public OrderItemsController(
    IOrderItemsGetterService orderItemsGetterService,
    IOrderItemsAdderService orderItemsAdderService,
    IOrderItemsUpdaterService orderItemsUpdaterService,
    IOrderItemsDeleterService orderItemsDeleterService,
    ILogger<OrderItemsController> logger)
        {
            _orderItemsGetterService = orderItemsGetterService;
            _orderItemsAdderService = orderItemsAdderService;
            _orderItemsUpdaterService = orderItemsUpdaterService;
            _orderItemsDeleterService = orderItemsDeleterService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderItemResponse>>> GetOrderItemsByOrderId(Guid orderId)
        {
            _logger.LogInformation($"Retrieving order items for Order ID: {orderId}...");

            var orderItems = await _orderItemsGetterService.GetOrderItemsByOrderId(orderId);

            _logger.LogInformation($"Order items retrieved successfully for Order ID: {orderId}.");

            return Ok(orderItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemResponse?>> GetOrderItemById(Guid id)
        {
            _logger.LogInformation($"Retrieving order item by Order Item ID: {id}...");

            var orderItem = await _orderItemsGetterService.GetOrderItemByOrderItemId(id);

            if (orderItem == null)
            {
                _logger.LogWarning($"Order item not found for Order Item ID: {id}.");
                return NotFound();
            }

            _logger.LogInformation($"Order item retrieved successfully. Order Item ID: {id}.");

            return Ok(orderItem);
        }

        [HttpPost]
        public async Task<ActionResult<OrderItemResponse>> AddOrderItem(Guid orderId, OrderItemAddRequest orderItemRequest)
        {
            _logger.LogInformation($"Adding order item for Order ID: {orderId}...");

            var addedOrderItem = await _orderItemsAdderService.AddOrderItem(orderItemRequest);

            _logger.LogInformation($"Order item added successfully. Order Item ID: {addedOrderItem.OrderItemId}.");

            return CreatedAtAction(nameof(GetOrderItemById), new { id = addedOrderItem.OrderItemId }, addedOrderItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderItemResponse>> UpdateOrderItem(Guid id, OrderItemUpdateRequest orderItemRequest)
        {
            if (id != orderItemRequest.OrderItemId)
            {
                _logger.LogWarning($"Invalid Order Item ID in the request: {orderItemRequest.OrderItemId}.");
                return BadRequest();
            }

            _logger.LogInformation($"Updating order item. Order Item ID: {id}...");

            var updatedOrderItem = await _orderItemsUpdaterService.UpdateOrderItem(orderItemRequest);

            _logger.LogInformation($"Order item updated successfully. Order Item ID: {updatedOrderItem.OrderItemId}.");

            return Ok(updatedOrderItem);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrderItem(Guid orderId, Guid id)
        {
            _logger.LogInformation($"Deleting order item. Order Item ID: {id}...");

            var isDeleted = await _orderItemsDeleterService.DeleteOrderItemByOrderItemId(id);

            if (!isDeleted)
            {
                _logger.LogWarning($"Order item not found for deletion. Order Item ID: {id}.");
                return NotFound();
            }

            _logger.LogInformation($"Order item deleted successfully. Order Item ID: {id}.");

            return NoContent();
        }

    }
}
