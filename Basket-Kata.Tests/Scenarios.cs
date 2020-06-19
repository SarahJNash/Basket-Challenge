using Basket_Kata.Core;
using Basket_Kata.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basket_Kata.Tests
{
    [TestClass]
    public class Scenarios
    {
        //Basket 1:
        //1 Hat @ £10.50
        //1 Jumper @ £54.65
        //------------
        //1 x £5.00 Gift Voucher XXX-XXX applied
        //------------
        //Total: £60.15
        [TestMethod]
        public void Basket1()
        {
            var product1 = new Product { Name = "Hat", Price = 10.50M, Category = ProductCategory.Clothing };
            var product2 = new Product { Name = "Jumper", Price = 54.65M, Category = ProductCategory.Clothing };
            var voucher = new GiftVoucher { Name = "XXX-XXX", Value = 5M };

            var basket = new Basket(new GiftVoucherService());
            basket.AddProduct(product1);
            basket.AddProduct(product2);
            basket.AddGiftVoucher(voucher);

            Assert.AreEqual(60.15M, basket.Total);
        }

        //Basket 2:
        //1 Hat @ £25.00
        //1 Jumper @ £26.00
        //------------
        //1 x £5.00 off Head Gear in baskets over £50.00 Offer Voucher YYY-YYY applied
        //------------
        //Total: £51.00
        //Message: “There are no products in your basket applicable to voucher Voucher YYY-YYY.”
        [TestMethod]
        public void Basket2()
        {
            var product1 = new Product { Name = "Hat", Price = 25.00M, Category = ProductCategory.Clothing };
            var product2 = new Product { Name = "Jumper", Price = 26M, Category = ProductCategory.Clothing };
            var voucher = new OfferVoucher { Name = "YYY-YYY", Discount = 5M, Category = ProductCategory.HeadGear, Threshold = 50 };

            var basket = new Basket(new GiftVoucherService());
            basket.AddProduct(product1);
            basket.AddProduct(product2);
            basket.Voucher = voucher;

            Assert.AreEqual(51M, basket.Total);
            Assert.AreEqual("There are no products in your basket applicable to voucher Voucher YYY-YYY.", basket.Message);
        }

        //Basket 3:
        //1 Hat @ £25.00
        //1 Jumper @ £26.00
        //1 Head Light(Head Gear Category of Product) @ £3.50
        //------------
        //1 x £5.00 off Head Gear in baskets over £50.00 Offer Voucher YYY-YYY applied
        //------------
        //Total: £51.00
        [TestMethod]
        public void Basket3()
        {
            var product1 = new Product { Name = "Hat", Price = 25.00M, Category = ProductCategory.Clothing };
            var product2 = new Product { Name = "Jumper", Price = 26M, Category = ProductCategory.Clothing };
            var product3 = new Product { Name = "Head Light", Price = 3.5M, Category = ProductCategory.HeadGear };
            var voucher = new OfferVoucher { Name = "YYY-YYY", Discount = 5M, Category = ProductCategory.HeadGear, Threshold = 50 };

            var basket = new Basket(new GiftVoucherService());
            basket.AddProduct(product1);
            basket.AddProduct(product2);
            basket.AddProduct(product3);
            basket.Voucher = voucher;

            Assert.AreEqual(51M, basket.Total);
            Assert.IsNull(basket.Message);
        }

        //Basket 4:
        //1 Hat @ £25.00
        //1 Jumper @ £26.00
        //------------
        //1 x £5.00 Gift Voucher XXX-XXX applied
        //1 x £5.00 off baskets over £50.00 Offer Voucher YYY-YYY applied
        //------------
        //Total: £41.00
        [TestMethod]
        public void Basket4()
        {
            var product1 = new Product { Name = "Hat", Price = 25.00M, Category = ProductCategory.Clothing };
            var product2 = new Product { Name = "Jumper", Price = 26M, Category = ProductCategory.Clothing };
            var offerVoucher = new OfferVoucher { Name = "YYY-YYY", Discount = 5M, Threshold = 50 };
            var giftVoucher = new GiftVoucher { Name = "XXX-XXX", Value = 5M };

            var basket = new Basket(new GiftVoucherService());
            basket.AddProduct(product1);
            basket.AddProduct(product2);
            basket.Voucher = offerVoucher;
            basket.AddGiftVoucher(giftVoucher);

            Assert.AreEqual(41M, basket.Total);
            Assert.IsNull(basket.Message);
        }


        //Basket 5:
        //1 Hat @ £25.00
        //1 £30 Gift Voucher @ £30.00
        //------------
        //1 x £5.00 off baskets over £50.00 Offer Voucher YYY-YYY applied
        //------------
        //Total: £55.00
        //------------
        //Message: “You have not reached the spend threshold for voucher YYY-YYY.Spend another £25.01 to receive £5.00 discount from your basket total.”
        [TestMethod]
        public void Basket5()
        {
            var product1 = new Product { Name = "Hat", Price = 25.00M, Category = ProductCategory.Clothing };
            var product2 = new Product { Name = "xxx-xxx", Price = 30M, Category = ProductCategory.GiftVoucher };

            var offerVoucher = new OfferVoucher { Name = "YYY-YYY", Discount = 5M, Threshold = 50 };

            var basket = new Basket(new GiftVoucherService());
            basket.AddProduct(product1);
            basket.AddProduct(product2);
            basket.Voucher = offerVoucher;

            Assert.AreEqual(55M, basket.Total);
            Assert.AreEqual("You have not reached the spend threshold for voucher YYY-YYY. Spend another £25.01 to receive £5.00 discount from your basket total.", basket.Message);
        }
    }
}

