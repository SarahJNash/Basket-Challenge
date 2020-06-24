using Basket_Kata.Data.Entities;
using System.Collections.Generic;

namespace Basket_Kata.Data
{
    public interface IProductRepository
    {
        IEnumerable<DBProduct> GetAll();
        DBProduct Get(int productId);
    }
}
