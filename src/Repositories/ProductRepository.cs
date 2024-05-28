using Microsoft.EntityFrameworkCore;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;
using sda_onsite_2_csharp_backend_teamwork.src.Databases;
using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
namespace sda_onsite_2_csharp_backend_teamwork.src.Repositories

{
    public class ProductRepository : IProductRepository
    {
        private DbSet<Product> _products;
        private DbSet<Inventory> _inventories;
        private DatabaseContext _databaseContext;
        


        public ProductRepository(DatabaseContext databaseContext)
        {
            _products = databaseContext.Products;
            _inventories = databaseContext.Inventories;
            _databaseContext = databaseContext;
        }
        public Product CreateOne(Product product)
        {
            _products.Add(product);
            _databaseContext.SaveChanges();
            return product;
        }
        public bool? DeleteOne(Product product)
        {
            _products.Remove(product!);
            _databaseContext.SaveChanges();
            return true;
        }
        public IEnumerable<ProductJoinDto> FindAll(int limit, int offset)
        {
            var products = from product in _products
                           join inventory in _inventories on product.Id equals inventory.ProductId
                           select new ProductJoinDto
                           {
                               Id = product.Id,
                               CategoryId = product.CategoryId,
                               InventoryId = inventory.Id,
                               Name = product.Name,
                               Description = product.Description,
                               Image = product.Image,
                               Price = inventory.Price,
                               Quantity = inventory.Quantity,
                               Size = inventory.Size,
                               Color = inventory.Color
                           };
            if (limit == 0 & offset == 0)
            {
                return products;
            }
            return products.Skip(offset).Take(limit);
        }
        public Product? FindOne(Guid productId)
        {
            var findProduct = _products.Find(productId);
            return findProduct;
        }
        public IEnumerable<Product> Search()
        {
            return _products;
        }
        public Product UpdateOne(Product UpdateProduct)
        {
            _databaseContext.Products.Update(UpdateProduct);
            _databaseContext.SaveChanges();

            return UpdateProduct;
        }
        // public IEnumerable<ProductJoinDto> JoinProduct()
        // {

        //     var invGroups = from product in _products
        //                     join inventory in _inventories on product.Id equals inventory.ProductId
        //                     select new ProductJoinDto
        //                     {
        //                         Id = product.Id,
        //                         CategoryId = product.CategoryId,
        //                         Name = product.Name,
        //                         Description = product.Description,
        //                         Image = product.Image,
        //                         Price = inventory.Price,
        //                         Quantity = inventory.Quantity
        //                     };
        //     foreach (var item in invGroups)
        //     {
        //         Console.WriteLine($"===={item.Name}");
        //     }
        //     return invGroups;
        // }
    }
}

