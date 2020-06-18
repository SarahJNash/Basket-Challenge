using System;

namespace Basket_Kata.Core
{
    public class VoucherApplyResponse
    {
        public Boolean IsValid { get; set; }
        public string Message { get; set; }

        public decimal Discount { get; set; }
    }
}