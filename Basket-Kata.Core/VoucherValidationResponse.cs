namespace Basket_Kata.Core
{
    public class VoucherApplyResponse
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public decimal Discount { get; set; }
    }
}
