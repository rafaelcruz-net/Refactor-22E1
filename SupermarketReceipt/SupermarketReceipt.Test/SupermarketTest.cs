using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SupermarketReceipt.Test
{
    public class SupermarketTest
    {
        [Fact]
        public void TenPercentDiscount()
        {
            // ARRANGE
            ISupermarketCatalog catalog = new FakeCatalog();
            var toothbrush = new Product("toothbrush", ProductUnit.Each);
            catalog.AddProduct(toothbrush, 0.99);
            var apples = new Product("apples", ProductUnit.Kilo);
            catalog.AddProduct(apples, 1.99);

            var cart = new ShoppingCart();
            cart.AddItemQuantity(apples, 2.5);

            var teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.TenPercentDiscount, toothbrush, 10.0);

            // ACT
            var receipt = teller.ChecksOutArticlesFrom(cart);

            // ASSERT
            Assert.Equal(4.975, receipt.GetTotalPrice());
            Assert.Equal(new List<Discount>(), receipt.GetDiscounts());
            Assert.Single(receipt.GetItems());
            var receiptItem = receipt.GetItems()[0];
            Assert.Equal(apples, receiptItem.Product);
            Assert.Equal(1.99, receiptItem.Price);
            Assert.Equal(2.5 * 1.99, receiptItem.TotalPrice);
            Assert.Equal(2.5, receiptItem.Quantity);
        }

        [Fact]
        public void TwoGetOneForFree()
        {
            ISupermarketCatalog catalog = new FakeCatalog();

            var toothbrush = new Product("toothbrush", ProductUnit.Each);
            catalog.AddProduct(toothbrush, 0.99);

            var cart = new ShoppingCart();
            cart.AddItemQuantity(toothbrush, 2);

            var teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.TwoForAmount, toothbrush, .99);

            var receipt = teller.ChecksOutArticlesFrom(cart);

            Assert.Equal(.99, receipt.GetTotalPrice());
            Assert.True(receipt.GetItems().First().Quantity == 2);

            Assert.Collection(receipt.GetItems(), (e) =>
            {
                Assert.True(e.Product.Name == "toothbrush");
            });

        }

        [Fact]
        public void TwentyPercentDiscount()
        {
            ISupermarketCatalog catalog = new FakeCatalog();

            var apple = new Product("apples", ProductUnit.Kilo);
            catalog.AddProduct(apple, 4);

            var cart = new ShoppingCart();
            cart.AddItemQuantity(apple, 2);

            var teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.TwentyPercentDiscount, apple, 20.0);

            // ACT
            var receipt = teller.ChecksOutArticlesFrom(cart);

            // ASSERT
            Assert.Equal(6.40, receipt.GetTotalPrice());
            Assert.Single(receipt.GetItems());
            var receiptItem = receipt.GetItems()[0];
            Assert.Equal(apple, receiptItem.Product);
            Assert.Equal(4, receiptItem.Price);
            Assert.Equal(2 * 4, receiptItem.TotalPrice);
            Assert.Equal(2, receiptItem.Quantity);

        }


        [Fact]
        public void FiveForAmount()
        {
            ISupermarketCatalog catalog = new FakeCatalog();

            var toothpaste = new Product("toothpaste", ProductUnit.Each);
            catalog.AddProduct(toothpaste, 1.79);

            var cart = new ShoppingCart();
            cart.AddItemQuantity(toothpaste, 5);

            var teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.FiveForAmount, toothpaste, 7.49);

            var receipt = teller.ChecksOutArticlesFrom(cart);

            Assert.Equal(7.49, receipt.GetTotalPrice());
            Assert.Single(receipt.GetItems());

            var receiptItem = receipt.GetItems()[0];

            Assert.Equal(toothpaste, receiptItem.Product);
            Assert.Equal(1.79, receiptItem.Price);
            Assert.Equal(1.79 * 5, receiptItem.TotalPrice);
            Assert.Equal(5, receiptItem.Quantity);

        }


        [Fact]
        public void TwoForAmount()
        {
            ISupermarketCatalog catalog = new FakeCatalog();

            var tomatoes = new Product("box tomatoes", ProductUnit.Each);
            catalog.AddProduct(tomatoes, .99);

            var cart = new ShoppingCart();
            cart.AddItemQuantity(tomatoes, 2);

            var teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.TwoForAmount, tomatoes, 1.38);

            var receipt = teller.ChecksOutArticlesFrom(cart);

            Assert.Equal(1.38, receipt.GetTotalPrice());
            Assert.Single(receipt.GetItems());

            var receiptItem = receipt.GetItems()[0];

            Assert.Equal(tomatoes, receiptItem.Product);
            Assert.Equal(.99, receiptItem.Price);
            Assert.Equal(.99 * 2, receiptItem.TotalPrice);
            Assert.Equal(2, receiptItem.Quantity);

        }

        [Fact]
        public void ThreeForTwo()
        {
            ISupermarketCatalog catalog = new FakeCatalog();

            var toothbrush = new Product("toothbrush", ProductUnit.Each);
            catalog.AddProduct(toothbrush, 0.99);

            var cart = new ShoppingCart();
            cart.AddItemQuantity(toothbrush, 3);

            var teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.ThreeForTwo, toothbrush, .99);

            var receipt = teller.ChecksOutArticlesFrom(cart);

            Assert.Equal(.99 * 2, receipt.GetTotalPrice());
            Assert.True(receipt.GetItems().First().Quantity == 3);

            Assert.Collection(receipt.GetItems(), (e) =>
            {
                Assert.True(e.Product.Name == "toothbrush");
            });

        }

    }
}