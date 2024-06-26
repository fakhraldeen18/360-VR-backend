using AutoMapper;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;

namespace sda_onsite_2_csharp_backend_teamwork.src.Services
{
    public class OrderServices : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IInventoryService _inventoryService;
        private IOrderItemService _orderItemService;
        private IProductService _productService;
        private IMapper _mapper;
        private IConfiguration _config;


        public OrderServices(IOrderRepository orderRepository, IConfiguration config, IInventoryService inventoryService, IOrderItemService orderItemService, IProductService productService, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _config = config;
            _inventoryService = inventoryService;
            _orderItemService = orderItemService;
            _productService = productService;
            _mapper = mapper;
        }

        public IEnumerable<OrderReadDto> FindAll()
        { 
            var orders =_orderRepository.FindAll();
            var readerOrder = orders.Select((order)=> _mapper.Map<OrderReadDto>(order));
            return readerOrder;
        }

        public Order? FindOne(Guid orderId)
        {
            Order? order = _orderRepository.FindOne(orderId);
            return order;
        }
        public OrderReadDto CreateOne(List<CheckoutDto> checkoutOrder, string userId)
        {
            Console.WriteLine($"USER ID = {userId}");
            Order order = new();
            order.UserId = new Guid(userId);
            _orderRepository.CreateOne(order);

            foreach (var checkedItem in checkoutOrder)
            {
                var inventory = _inventoryService.FindAll().FirstOrDefault(inv => inv.ProductId == checkedItem.ProductId && inv.Color == checkedItem.Color && inv.Size == checkedItem.Size);
                if (inventory is null)
                {
                    order.Status = "Failed";
                    _orderRepository.DeleteOne(order.Id);
                    continue;
                }
                if (checkedItem.Quantity >= inventory.Quantity)
                {
                    order.Status = "Failed";
                    _orderRepository.DeleteOne(order.Id);
                    continue;
                }
                OrderItemCreateDto orderItem = new()
                {
                    OrderId = order.Id,
                    InventoryId = inventory.Id,
                    Quantity = checkedItem.Quantity,
                    TotalPrice = checkedItem.Quantity * inventory.Price
                };
                order.Status = "Succeed";
                _orderItemService.CreateOne(orderItem);
            }
            return _mapper.Map<OrderReadDto>(order);
        }

        public Order? DeleteOne(Guid OrderId)
        {
            var deleteOrder = _orderRepository.FindOne(OrderId);
            if (deleteOrder == null) return null;
            return _orderRepository.DeleteOne(OrderId);
        }
    }
}