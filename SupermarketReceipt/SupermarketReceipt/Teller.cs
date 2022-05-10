using System.Collections.Generic;

namespace SupermarketReceipt
{
    public class Teller
    {
        private readonly ISupermarketCatalog _catalog;
        private readonly Dictionary<Product, Offer> _offers = new Dictionary<Product, Offer>();

        public Teller(ISupermarketCatalog catalog)
        {
            _catalog = catalog;
        }

        public void AddSpecialOffer(SpecialOfferType offerType, Product product, double argument)
        {
            _offers[product] = new Offer(offerType, product, argument);
        }

        public Receipt ChecksOutArticlesFrom(ShoppingCart theCart)
        {
            var receipt = new Receipt();
            var productQuantities = theCart.GetItems();

            CalculateTotalPrice(receipt, productQuantities);

            theCart.HandleOffers(receipt, _offers, _catalog);

            return receipt;
        }

        private void CalculateTotalPrice(Receipt receipt, List<ProductQuantity> productQuantities)
        {
            foreach (var pq in productQuantities)
            {
                var unitPrice = _catalog.GetUnitPrice(pq.Product);
                var price = pq.GetPrice(unitPrice);
                receipt.AddProduct(pq.Product, pq.Quantity, unitPrice, price);
            }
        }
    }
}