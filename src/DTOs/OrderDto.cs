using sda_onsite_2_csharp_backend_teamwork.src.Entities;

namespace sda_onsite_2_csharp_backend_teamwork.src.DTOs
{
    public class CheckoutDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
    }
    public class OrderReadDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; } // Foreign key
        public DateTime Date { get; set; } = DateTime.Now;
        public string? Status { get; set; }
        public List<OrderItem>? OrderItem { get; set; } // Navigation Property
    }
}