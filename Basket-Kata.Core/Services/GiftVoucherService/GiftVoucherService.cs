using System.Collections.Generic;

namespace Basket_Kata.Core.Services
{
    public class GiftVoucherService : IGiftVoucherService
    {
        public GiftVoucherValidationResponse Validate(List<Product> products)
        {
            if (products.Exists(p => p.Category == ProductCategory.GiftVoucher))
            {
                return new GiftVoucherValidationResponse { IsValid = false, Message = "Gift vouchers can only be redeemed against non gift voucher products." };
            }

            return new GiftVoucherValidationResponse { IsValid = true };
        }
    }
}
