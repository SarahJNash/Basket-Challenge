using Basket_Kata.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Basket_Kata.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<DBProduct> Products = new List<DBProduct> {
            new  DBProduct { Id = 1, Name = "Hat", Price = 25.00M, Category = DBProductCategory.Clothing },
            new  DBProduct { Id = 2, Name = "Hat", Price = 10.50M, Category = DBProductCategory.Clothing },

            new  DBProduct { Id = 3, Name = "Suit", Price = 250M, Category = DBProductCategory.Clothing },

            new  DBProduct { Id = 4, Name = "Jumper", Price = 26M, Category =  DBProductCategory.Clothing },
            new  DBProduct { Id = 5, Name = "Jumper", Price = 54.65M, Category =  DBProductCategory.Clothing },
            new  DBProduct { Id = 6, Name = "Jumper", Price = 30M, Category = DBProductCategory.Clothing },
            new  DBProduct { Id = 7, Name = "Jumper", Price = 55.00M, Category =  DBProductCategory.Clothing },

            new  DBProduct { Id = 8, Name = "Handbag", Price = 70.00M, Category =  DBProductCategory.Other },

            new  DBProduct { Id = 9, Name = "Head Light", Price = 3.5M, Category =  DBProductCategory.HeadGear },

            new  DBProduct { Id = 10, Name = "ggg-ggg", Price = 20M, Category =  DBProductCategory.GiftVoucher },
            new  DBProduct { Id = 10, Name = "ggg-ggg", Price = 20M, Category =  DBProductCategory.GiftVoucher },
            new  DBProduct { Id = 11, Name = "aaa-aaa", Price = 50.00M, Category =  DBProductCategory.GiftVoucher },
            new  DBProduct { Id = 12, Name = "xxx-xxx", Price = 30M, Category = DBProductCategory.GiftVoucher },

            new  DBProduct { Id = 13, Name = "Shirt", Price = 20.00M, Category =  DBProductCategory.Clothing },
            new  DBProduct { Id = 14, Name = "Shirt", Price = 30.00M, Category =  DBProductCategory.Clothing },
            new  DBProduct { Id = 15, Name = "Shirt", Price = 50.00M, Category =  DBProductCategory.Clothing },
            new  DBProduct { Id = 16, Name = "Coat", Price = 250.00M, Category =  DBProductCategory.Clothing }
        };

        public IEnumerable<DBProduct> GetAll()
        {
            return Products;
        }

        public DBProduct Get(int productId)
        {
            return Products.FirstOrDefault(p => p.Id == productId);
        }
    }
}
