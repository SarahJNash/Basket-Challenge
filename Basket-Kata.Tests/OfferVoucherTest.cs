using Basket_Kata.Core;
using Basket_Kata.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basket_Kata.Tests
{
    [TestClass]
    public class OfferVoucherTests
    {
        [TestMethod]
        public void No_offer_vouchers_redeemed()
        {
            var product1 = new Product { Name = "Jumper", Price = 30M, Category = ProductCategory.Clothing };

            var basket = new Basket(new GiftVoucherService());
            basket.AddProduct(product1);

            Assert.AreEqual(30.00M, basket.Total);
            Assert.IsNull(basket.Message);
        }

        [TestMethod]
        public void Voucher_no_category__basket_value_insufficient()
        {
            var product1 = new Product { Name = "Hat", Price = 25.00M, Category = ProductCategory.Clothing };
            var offerVoucher = new OfferVoucher { Name = "YYY-YYY", Discount = 5M, Threshold = 50 };

            var basket = new Basket(new GiftVoucherService());
            basket.AddProduct(product1);
            basket.Voucher = offerVoucher;

            Assert.AreEqual(25M, basket.Total);
            Assert.AreEqual("You have not reached the spend threshold for voucher YYY-YYY. Spend another £25.01 to receive £5.00 discount from your basket total.", basket.Message);
        }

        [TestMethod]
        public void Voucher_no_category__basket_value_sufficient()
        {
            var product1 = new Product { Name = "Coat", Price = 250.00M, Category = ProductCategory.Clothing };
            var offerVoucher = new OfferVoucher { Name = "YYY-YYY", Discount = 20M, Threshold = 50 };

            var basket = new Basket(new GiftVoucherService());
            basket.AddProduct(product1);
            basket.Voucher = offerVoucher;

            Assert.AreEqual(230M, basket.Total);
            Assert.IsNull(basket.Message);
        }

        [TestMethod]
        public void Voucher_no_category__basket_value_equals_threshold()
        {
            var product1 = new Product { Name = "Shirt", Price = 50.00M, Category = ProductCategory.Clothing };
            var offerVoucher = new OfferVoucher { Name = "YYY-YYY", Discount = 5M, Threshold = 50 };

            var basket = new Basket(new GiftVoucherService());
            basket.AddProduct(product1);
            basket.Voucher = offerVoucher;

            Assert.AreEqual(50M, basket.Total);
            Assert.AreEqual("You have not reached the spend threshold for voucher YYY-YYY. Spend another £0.01 to receive £5.00 discount from your basket total.", basket.Message);
        }

        [TestMethod]
        public void Voucher_no_category__basket_value_insufficient_because_of_gift_voucher()
        {
            var product1 = new Product { Name = "Hat", Price = 25.00M, Category = ProductCategory.Clothing };
            var product2 = new Product { Name = "aaa-aaa", Price = 50.00M, Category = ProductCategory.GiftVoucher };
            var offerVoucher = new OfferVoucher { Name = "YYY-YYY", Discount = 5M, Threshold = 50 };

            var basket = new Basket(new GiftVoucherService());
            basket.AddProduct(product1);
            basket.AddProduct(product2);
            basket.Voucher = offerVoucher;

            Assert.AreEqual(75M, basket.Total);
            Assert.AreEqual("You have not reached the spend threshold for voucher YYY-YYY. Spend another £25.01 to receive £5.00 discount from your basket total.", basket.Message);
        }

        [TestMethod]
        public void Voucher_with_category__basket_value_insufficient()
        {
            var product1 = new Product { Name = "Jumper", Price = 30.00M, Category = ProductCategory.Clothing };
            var offerVoucher = new OfferVoucher { Name = "YYY-YYY", Discount = 10M, Threshold = 100, Category = ProductCategory.Clothing };

            var basket = new Basket(new GiftVoucherService());
            basket.AddProduct(product1);
            basket.Voucher = offerVoucher;

            Assert.AreEqual(30M, basket.Total);
            Assert.AreEqual("You have not reached the spend threshold for voucher YYY-YYY. Spend another £70.01 to receive £10.00 discount from your basket total.", basket.Message);
        }

        [TestMethod]
        public void Voucher_with_category__no_products_that_category()
        {
            var product1 = new Product { Name = "Head Light", Price = 3.50M, Category = ProductCategory.HeadGear };
            var offerVoucher = new OfferVoucher { Name = "DDD-DDD", Discount = 10M, Threshold = 100, Category = ProductCategory.Clothing };

            var basket = new Basket(new GiftVoucherService());
            basket.AddProduct(product1);
            basket.Voucher = offerVoucher;

            Assert.AreEqual(3.50M, basket.Total);
            Assert.AreEqual("There are no products in your basket applicable to voucher Voucher DDD-DDD.", basket.Message);
        }

        [TestMethod]
        public void Voucher_with_category__basket_value_sufficient__category_total_greater_than_voucher()
        {
            var product1 = new Product { Name = "Jumper", Price = 30.00M, Category = ProductCategory.Clothing };
            var product2 = new Product { Name = "Handbag", Price = 70.00M, Category = ProductCategory.Other };
            var offerVoucher = new OfferVoucher { Name = "YYY-YYY", Discount = 5M, Threshold = 50, Category = ProductCategory.Clothing };

            var basket = new Basket(new GiftVoucherService());
            basket.AddProduct(product1);
            basket.AddProduct(product2);
            basket.Voucher = offerVoucher;

            Assert.AreEqual(95M, basket.Total);
            Assert.IsNull(basket.Message);
        }

        [TestMethod]
        public void Voucher_with_category__basket_value_sufficient__category_total_less_than_voucher()
        {
            var product1 = new Product { Name = "Jumper", Price = 55.00M, Category = ProductCategory.Clothing };
            var product2 = new Product { Name = "Head Light", Price = 3.50M, Category = ProductCategory.HeadGear };
            var offerVoucher = new OfferVoucher { Name = "YYY-YYY", Discount = 5M, Threshold = 50, Category = ProductCategory.HeadGear };

            var basket = new Basket(new GiftVoucherService());
            basket.AddProduct(product1);
            basket.AddProduct(product2);
            basket.Voucher = offerVoucher;

            Assert.AreEqual(55M, basket.Total);
            Assert.IsNull(basket.Message);
        }

        [TestMethod]
        public void Voucher_with_category__basket_value_insufficient_because_of_gift_voucher()
        {
            var product1 = new Product { Name = "Hat", Price = 25.00M, Category = ProductCategory.Clothing };
            var product2 = new Product { Name = "aaa-aaa", Price = 50.00M, Category = ProductCategory.GiftVoucher };
            var offerVoucher = new OfferVoucher { Name = "YYY-YYY", Discount = 5M, Threshold = 50, Category = ProductCategory.Clothing };

            var basket = new Basket(new GiftVoucherService());
            basket.AddProduct(product1);
            basket.AddProduct(product2);
            basket.Voucher = offerVoucher;

            Assert.AreEqual(75M, basket.Total);
            Assert.AreEqual("You have not reached the spend threshold for voucher YYY-YYY. Spend another £25.01 to receive £5.00 discount from your basket total.", basket.Message);
        }

        [TestMethod]
        public void Voucher_with_category__basket_value_equals_threshold()
        {
            var product1 = new Product { Name = "Shirt", Price = 20.00M, Category = ProductCategory.Clothing };
            var product2 = new Product { Name = "Shirt", Price = 30.00M, Category = ProductCategory.Clothing };
            var offerVoucher = new OfferVoucher { Name = "YYY-YYY", Discount = 5M, Threshold = 50, Category = ProductCategory.Clothing };

            var basket = new Basket(new GiftVoucherService());
            basket.AddProduct(product1);
            basket.AddProduct(product2);
            basket.Voucher = offerVoucher;

            Assert.AreEqual(50M, basket.Total);
            Assert.AreEqual("You have not reached the spend threshold for voucher YYY-YYY. Spend another £0.01 to receive £5.00 discount from your basket total.", basket.Message);
        }
    }
}
