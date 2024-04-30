using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;

namespace sda_onsite_2_csharp_backend_teamwork.src.Controllers
{
    public class OrderItemController : CustomBaseController
    {
        private IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public DbSet<OrderItem> FindAll()
        {
            return _orderItemService.FindAll();
        }

        [HttpGet("{orderItemId}")]
        public OrderItem? FindOne(Guid orderItemId)
        {
            return _orderItemService.FindOne(orderItemId);
        }

        [HttpPost]
        public OrderItem CreateOne([FromBody] OrderItem NewOrderItem)
        {
            return _orderItemService.CreateOne(NewOrderItem);
        }

        [HttpDelete("{orderItemId}")]
        public OrderItem? DeleteOne(Guid orderItemId)
        {
            return _orderItemService.DeleteOne(orderItemId);
        }

        [HttpPatch("{orderItemId}")]
        public OrderItem? UpdateOne(Guid orderItemId, [FromBody] OrderItem item)
        {
            return _orderItemService.UpdateOne(orderItemId, item);
        }
    }
}