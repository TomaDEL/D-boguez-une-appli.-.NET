using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        private List<CartLine> _cartLines = new List<CartLine>(); //_cartLines = une liste attaché à l'objet "Cart" conservée en mémoire
        /// <summary>
        /// Read-only property for display only
        /// </summary>
        public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList() //retourne une liste vide
        {
            //return new List<CartLine>(); On vient corriger cette ligne
                        return _cartLines;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity) //vide donc pas d'ajout possible
        {
            // TODO implement the method
            List<CartLine> cartLines = GetCartLineList(); //on récupère la liste des cartlines

            CartLine line = cartLines
                .FirstOrDefault(l => l.Product.Id == product.Id); //on cherche si le produit est déjà dans le panier

            if (line == null) //si le produit n'est pas dans le panier
                {
                cartLines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else //si le produit est déjà dans le panier
            {
                line.Quantity += quantity; //on incrémente la quantité
            }
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()       //retourne toujours 0.0
        {
            // TODO implement the method
            //return 0.0;
            return GetCartLineList()                       //on récupère la liste des cartlines
                .Sum(l => l.Product.Price * l.Quantity);   //on calcule la somme des prix * quantités
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()     //retourne toujours 0.0
        {
            // TODO implement the method
           //return 0.0;
           int totalQuantity = GetCartLineList().Sum(l => l.Quantity); //on calcule la somme des quantités

            if (totalQuantity == 0)     //si la somme des quantités est égale à 0
                return 0;

            return GetTotalValue() / totalQuantity; //on retourne la valeur totale divisée par la somme des quantités
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)  //retourne null donc ne trouve jamais le produit
        {
            // TODO implement the method
            //return null;
            return GetCartLineList()                                //on récupère la liste des cartlines
                .FirstOrDefault(l => l.Product.Id == productId)     //on cherche la cartline avec le produit correspondant
                ?.Product;                                          //si on trouve la cartline, on retourne le produit, sinon on retourne null
        }

        /// <summary>
        /// Get a specific cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
