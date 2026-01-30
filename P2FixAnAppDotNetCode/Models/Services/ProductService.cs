using P2FixAnAppDotNetCode.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manages the products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all product from the inventory
        /// </summary>
        public List<Product> GetAllProducts()   //changer le type de Product[] en List<Product>
        {
            // TODO change the return type from array to List<T> and propagate the change
            // throughout the application
            return _productRepository.GetAllProducts();
        }

        /// <summary>
        /// Get a product form the inventory by its id
        /// </summary>
        public Product GetProductById(int id)
        {
            // TODO implement the method
            //return null;
            return _productRepository
                .GetAllProducts()       //on récupère tous les produits
                .FirstOrDefault(p => p.Id == id);   //on cherche le produit avec l'id correspondant
        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered the quantities
        /// </summary>
        public void UpdateProductQuantities(Cart cart)
        {
            // TODO implement the method
            // update product inventory by using _productRepository.UpdateProductStocks() method.
            foreach (var line in cart.Lines)                    //on parcourt chaque ligne du panier
            {
                _productRepository.UpdateProductStocks(  //on met à jour le stock du produit
                    line.Product.Id,                     //on passe l'id du produit
                    line.Quantity                        //on passe la quantité commandée
                );
            }
        }
    }
}
