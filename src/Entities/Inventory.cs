using System.ComponentModel.DataAnnotations;

namespace sda_onsite_2_csharp_backend_teamwork.src.Entities
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; } // Foreign key
        public int Price { get; set; }

        public int Quantity { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public List<OrderItem>? OrderItem { get; set; } // Navigation Property
    }
}