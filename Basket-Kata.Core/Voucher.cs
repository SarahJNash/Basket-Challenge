using System.Collections.Generic;

namespace Basket_Kata.Core
{
    public abstract class Voucher
    {
        public string Name { get; set; }
        public decimal Discount { get; set; }
        public abstract VoucherApplyResponse Apply(List<Product> products);
    }
}
