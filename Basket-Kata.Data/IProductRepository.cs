using Basket_Kata.Data.Models;
using System.Collections.Generic;

namespace Basket_Kata.Data
{
    public interface IProductRepository
    {
       IEnumerable<Product> GetAll();
    }
}
