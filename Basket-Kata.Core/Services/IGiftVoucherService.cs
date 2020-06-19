using System.Collections.Generic;

namespace Basket_Kata.Core.Services
{
    public interface IGiftVoucherService
    {
        GiftVoucherValidationResponse Validate(List<Product> products);
    }
}
