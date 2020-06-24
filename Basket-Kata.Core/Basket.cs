using Basket_Kata.Core.Services;
using Basket_Kata.Core.Services.ProductService;
using System.Collections.Generic;
using System.Linq;

namespace Basket_Kata.Core
{
    public class Basket
    {
        private readonly List<Product> Products = new List<Product>();
        private readonly List<GiftVoucher> GiftVouchers = new List<GiftVoucher>();
        private IGiftVoucherService _giftVoucherService;
        private IProductService _productService;

        public Basket(IGiftVoucherService giftVoucherService, IProductService productService)
        {
            _giftVoucherService = giftVoucherService;
            _productService = productService;
        }

        private Voucher _voucher;
        public Voucher Voucher
        {
            get { return _voucher; }
            set
            {
                _voucher = value;
                CalculateTotal();
            }
        }

        public decimal Total { get; private set; }
        public string Message { get; private set; }

        public void AddProduct(int productId)
        {
            var product = _productService.Get(productId);
            Products.Add(product);
            CalculateTotal();
        }

        public void AddGiftVoucher(GiftVoucher voucher)
        {
            GiftVouchers.Add(voucher);
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            var goodsTotal = Products.Sum(p => p.Price);

            if (Voucher != null)
            {
                var result = Voucher.Apply(Products);
                if (result.IsValid)
                {
                    goodsTotal -= result.Discount;
                }
                else
                {
                    Message = result.Message;
                }

            }

            if (GiftVouchers != null && GiftVouchers.Count() > 0)
            {
                var response = _giftVoucherService.Validate(Products);
                Message = response.Message;

                if (response.IsValid)
                {
                    var giftTotal = GiftVouchers.Sum(g => g.Value);

                    if (goodsTotal < giftTotal)
                    {
                        var remaining = (giftTotal - goodsTotal).ToString("0.00");
                        goodsTotal = 0;
                        Message = $"You still have £{remaining} left on the gift voucher";
                    }
                    else
                    {
                        goodsTotal -= giftTotal;
                    }
                }
            }

            Total = goodsTotal;
        }
    }
}
