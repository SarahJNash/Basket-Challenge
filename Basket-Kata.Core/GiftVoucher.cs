using System.Collections.Generic;

namespace Basket_Kata.Core
{
    public class GiftVoucher : Voucher
    {
        public override VoucherApplyResponse Apply(List<Product> products)
        {
            return new VoucherApplyResponse { IsValid = true, Discount = Discount };
        }
    }
}
