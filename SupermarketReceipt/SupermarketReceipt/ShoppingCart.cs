using System;
using System.Collections.Generic;

namespace SupermarketReceipt
{
    public class ShoppingCart
    {
        private readonly List<ProductQuantity> _items = new List<ProductQuantity>();
        private readonly Dictionary<Product, double> _productQuantities = new Dictionary<Product, double>();


        public List<ProductQuantity> GetItems()
        {
            return new List<ProductQuantity>(_items);
        }

        public void AddItem(Product product)
        {
            AddItemQuantity(product, 1.0);
        }


        public void AddItemQuantity(Product product, double quantity)
        {
            _items.Add(new ProductQuantity(product, quantity));
            if (_productQuantities.ContainsKey(product))
            {
                var newAmount = _productQuantities[product] + quantity;
                _productQuantities[product] = newAmount;
            }
            else
            {
                _productQuantities.Add(product, quantity);
            }
        }

        public void HandleOffers(Receipt receipt, Dictionary<Product, Offer> offers, ISupermarketCatalog catalog)
        {
            foreach (var product in _productQuantities.Keys)
            {
                if (offers.ContainsKey(product))
                {
                    var offer = offers[product];
                    Discount discount = CalculateOffers(catalog, offer, product);

                    if (discount != null)
                        receipt.AddDiscount(discount);
                }
            }
        }

        public Discount CalculateOffers(ISupermarketCatalog catalog, Offer offer, Product product)
        {
            return offer.OfferType switch
            {
                SpecialOfferType.ThreeForTwo => CalculateThreeForTwo(catalog, offer, product),
                SpecialOfferType.TwoForAmount => CalculateTwoForAmount(catalog, offer, product),
                SpecialOfferType.FiveForAmount => CalculateFiveForAmount(catalog, offer, product),
                SpecialOfferType.TenPercentDiscount => CalculateTenPercentDiscount(catalog, offer, product),
                SpecialOfferType.TwentyPercentDiscount => CalculateTwentyPercentDiscount(catalog, offer, product),
                _ => throw new ArgumentException("Cannot Handle Offers")
            };
        }

        private Discount CalculateTwentyPercentDiscount(ISupermarketCatalog catalog, Offer offer, Product product)
        {
            var quantity = _productQuantities[product];
            var unitPrice = catalog.GetUnitPrice(product);
            return new Discount(product, offer.Argument + "% off", -quantity * unitPrice * offer.Argument / 100.0);
        }

        private Discount CalculateTenPercentDiscount(ISupermarketCatalog catalog, Offer offer, Product product)
        {
            var quantity = _productQuantities[product];
            var unitPrice = catalog.GetUnitPrice(product);
            return new Discount(product, offer.Argument + "% off", -quantity * unitPrice * offer.Argument / 100.0);

        }

        private Discount CalculateFiveForAmount(ISupermarketCatalog catalog, Offer offer, Product product)
        {
            if (_productQuantities[product] < 5)
                return null;

            var quantity = _productQuantities[product];
            var unitPrice = catalog.GetUnitPrice(product);
            var total = offer.Argument * (quantity / 5) + quantity % 5 * unitPrice;
            var discountN = unitPrice * quantity - total;
            var discount = new Discount(product, "5 for " + offer.Argument, -discountN);

            return discount;
        }

        private Discount CalculateTwoForAmount(ISupermarketCatalog catalog, Offer offer, Product product)
        {

            if (_productQuantities[product] < 2)
                return null;

            var quantity = _productQuantities[product];
            var unitPrice = catalog.GetUnitPrice(product);
            var total = offer.Argument * (quantity / 2) + quantity % 2 * unitPrice;
            var discountN = unitPrice * quantity - total;
            var discount = new Discount(product, "2 for " + offer.Argument, -discountN);

            return discount;

        }

        private Discount CalculateThreeForTwo(ISupermarketCatalog catalog, Offer offer, Product product)
        {
            if (_productQuantities[product] < 3)
                return null;

            var quantity = _productQuantities[product];
            var unitPrice = catalog.GetUnitPrice(product);
            var discountAmount = quantity * unitPrice - ((quantity / 3) * 2 * unitPrice + quantity % 3 * unitPrice);

            return new Discount(product, "3 for 2", -discountAmount);

        }
    }
}