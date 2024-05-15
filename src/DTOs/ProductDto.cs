namespace sda_onsite_2_csharp_backend_teamwork.src.DTOs
{
    public class ProductCreateDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ShortDesc { get; set; }

        public string Image { get; set; }

    }

    public class ProductReadDto
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ShortDesc { get; set; }

        public string Image { get; set; }
    }
    public class ProductUpdateDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ShortDesc { get; set; }
        public string Image { get; set; }
    }
    public class ProductJoinDto
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid InventoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ShortDesc { get; set; }

        public string Image { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }

    }
}