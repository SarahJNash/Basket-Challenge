using System.Collections.Generic;
using System.Linq;

namespace Basket_Kata.Core
{
    public class OfferVoucher : Voucher
    {

        public ProductCategory? Category { get; set; }
        public decimal Threshold { get; set; }

        public override VoucherApplyResponse Apply(List<Product> products)
        {
            var discount = Discount;
            if (Category != null)
            {
                var categoryProducts = products.Where(p => p.Category == Category);
                if (categoryProducts == null || categoryProducts.Count() == 0)
                {
                    return new VoucherApplyResponse { IsValid = false, Message = $"There are no products in your basket applicable to voucher Voucher {Name}.", Discount = 0 };
                }

                var categoryTotal = categoryProducts.Sum(p => p.Price);
                discount = categoryTotal < Discount ? categoryTotal : Discount;
            }

            var itemTotal = products.Where(x => x.Category != ProductCategory.GiftVoucher).Sum(p => p.Price);

            if (itemTotal > Threshold)
            {
                return new VoucherApplyResponse { IsValid = true, Discount = discount };
            }

            var remaining = Threshold - itemTotal + 0.01M; // +0.01 to take you over the threashold 
            return new VoucherApplyResponse
            {
                IsValid = false,
                Message = $"You have not reached the spend threshold for voucher {Name}. Spend another £{remaining.ToString("#.00")} to receive £{Discount.ToString("#.00")} discount from your basket total.",
                Discount = 0
            };
        }
    }
}
