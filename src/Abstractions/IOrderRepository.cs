using sda_onsite_2_csharp_backend_teamwork.src.Entities;

namespace sda_onsite_2_csharp_backend_teamwork.src.Abstractions
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> FindAll();
        public Order? FindOne(Guid orderId);
        public Order CreateOne(Order order);
        public Order? DeleteOne(Guid orderId);


    }
}