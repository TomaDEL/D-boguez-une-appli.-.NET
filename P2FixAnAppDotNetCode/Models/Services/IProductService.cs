using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();     //Product[] à changer en List<Product>
        Product GetProductById(int id);
        void UpdateProductQuantities(Cart cart);
    }
}
