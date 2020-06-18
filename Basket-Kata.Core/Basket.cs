using System.Collections.Generic;
using System.Linq;

namespace Basket_Kata.Core
{
    public class Basket
    {
        private readonly List<Product> Products = new List<Product>();
        private readonly List<Voucher> Vouchers = new List<Voucher>();

        public decimal Total { get; private set; }
        public string Message { get; private set; }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            CalculateTotal();
        }

        public void AddVoucher(Voucher voucher)
        {
            Vouchers.Add(voucher);
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            var goodsTotal = Products.Sum(p => p.Price);

            foreach (var v in Vouchers)
            {
                var response = v.Apply(Products);
                if (response.IsValid)
                {
                    goodsTotal -= response.Discount;
                }
                else
                {
                    Message = response.Message;
                }
            }

            Total = goodsTotal;
        }
    }
}
