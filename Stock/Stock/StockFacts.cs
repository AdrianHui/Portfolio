using System;
using Xunit;

namespace Stock.Facts
{
    public class StockFacts
    {
        [Fact]
        public void AddProductShouldAddANewProductToTheList()
        {
            var stock = new Stock<IProduct>();
            var apples = new Product("apples", 50, 0.2m);
            stock.AddProduct(apples);
            Assert.Contains(apples, stock);
        }

        [Fact]
        public void AddProductShouldIncreaseProductQuantityIfProductAlreadyExists()
        {
            var stock = new Stock<IProduct>();
            var apples = new Product("apples", 50, 0.2m);
            stock.AddProduct(apples);
            stock.AddProduct(new Product("apples", 20, 0.2m));
            Assert.True(stock.CheckQuantity(apples) == 70);
        }

        [Fact]
        public void SellProductShouldThrowAnExceptionIfQuantitySoldIsGreaterThanQuantityOnStock()
        {
            var stock = new Stock<IProduct>();
            var pears = new Product("pears", 50, 0.4m);
            stock.AddProduct(pears);
            Assert.Throws<InvalidOperationException>(()
                => stock.SellProduct(new Product("pears", 60, 0.4m)));
        }

        [Fact]
        public void SellProductShouldThrowAnExceptionIfProductIsNotOnStock()
        {
            var stock = new Stock<IProduct>();
            Assert.Throws<InvalidOperationException>(() => stock.SellProduct(new Product("pears", 60, 0.4m)));
        }

        [Fact]
        public void SellProductShouldRemoveSoldQuantityFromStock()
        {
            var stock = new Stock<IProduct>();
            var apples = new Product("apples", 50, 0.2m);
            stock.AddProduct(apples);
            stock.SellProduct(new Product("apples", 41, 0.2m));
            Assert.True(stock.CheckQuantity(apples) == 9);
        }

        [Fact]
        public void SellProductShouldRemoveTheProductFromStockIfWholeQuantityIsSold()
        {
            var stock = new Stock<IProduct>();
            var apples = new Product("apples", 50, 0.2m);
            stock.AddProduct(apples);
            stock.SellProduct(new Product("apples", 50, 0.2m));
            Assert.DoesNotContain(apples, stock);
        }

        [Fact]
        public void CheckQuantityShouldReturnNumberOfQuantityOnStockForGivenProduct()
        {
            var stock = new Stock<IProduct>();
            var apples = new Product("apples", 50, 0.2m);
            stock.AddProduct(apples);
            Assert.True(stock.CheckQuantity(apples) == apples.Quantity);
        }

        [Fact]
        public void CheckQuantityShouldThrowAnExceptionIfProductIsNotOnStock()
        {
            var stock = new Stock<IProduct>();
            var apples = new Product("apples", 50, 0.2m);
            Assert.Throws<InvalidOperationException>(() => stock.CheckQuantity(apples));
        }

        [Fact]
        public void IfStockIsLowerThanAnyLimitStockShouldCallBackTheAction()
        {
            var stock = new Stock<IProduct>();
            stock.AddProduct(new Product("apples", 50, 0.2m));
            stock.AddProduct(new Product("pears", 30, 0.3m));
            bool wasCallbackCalled = false;
            stock.Notify += x => wasCallbackCalled = true;
            stock.SellProduct(new Product("apples", 42, 0.2m));
            Assert.True(wasCallbackCalled);
        }

        [Fact]
        public void IfStockIsLowerThanAnyLimitShouldCallBackTheActionAndIncludeCorrectProductAndRemainingQuantity()
        {
            var stock = new Stock<IProduct>();
            stock.AddProduct(new Product("apples", 50, 0.2m));
            stock.AddProduct(new Product("pears", 30, 0.3m));
            IProduct lowStockProduct = null;
            stock.Notify += x => lowStockProduct = x;
            stock.SellProduct(new Product("apples", 49, 0.2m));
            Assert.True(lowStockProduct.Name == "apples" && lowStockProduct.Quantity == 1);
        }

        [Fact]
        public void IfStockIsLowerThanOneLimitButDoesntCrossAnotherLimitShouldNotCallbackTheAction()
        {
            var stock = new Stock<IProduct>();
            stock.AddProduct(new Product("apples", 9, 0.2m));
            stock.AddProduct(new Product("pears", 30, 0.3m));
            bool wasCallbackCalled = false;
            stock.Notify += x => wasCallbackCalled = true;
            stock.SellProduct(new Product("apples", 2, 0.2m));
            Assert.False(wasCallbackCalled);
        }
    }
}