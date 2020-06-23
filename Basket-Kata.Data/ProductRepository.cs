using Basket_Kata.Data.Models;
using System;
using System.Collections.Generic;

namespace Basket_Kata.Data
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAll()
        {
            var product1 = new Product { Id = 1, Name = "Hat", Price = 25.00M, Category = ProductCategory.Clothing };
            var product2 = new Product { Id = 2, Name = "Hat", Price = 10.50M, Category = ProductCategory.Clothing };

            var product3 = new Product { Id = 3, Name = "Suit", Price = 250M, Category = ProductCategory.Clothing };

            var product4 = new Product { Id = 4, Name = "Jumper", Price = 26M, Category = ProductCategory.Clothing };
            var product5 = new Product { Id = 5, Name = "Jumper", Price = 54.65M, Category = ProductCategory.Clothing };
            var product6 = new Product { Id = 6, Name = "Jumper", Price = 30M, Category = ProductCategory.Clothing };
            var product7 = new Product { Id = 7, Name = "Jumper", Price = 55.00M, Category = ProductCategory.Clothing };

            var product8 = new Product { Id = 8, Name = "Handbag", Price = 70.00M, Category = ProductCategory.Other };

            var product9 = new Product { Id = 9, Name = "Head Light", Price = 3.5M, Category = ProductCategory.HeadGear };

            var product10 = new Product { Id = 10, Name = "ggg-ggg", Price = 20M, Category = ProductCategory.GiftVoucher };
            var product11 = new Product { Id = 11, Name = "aaa-aaa", Price = 50.00M, Category = ProductCategory.GiftVoucher };
            var product12 = new Product { Id = 12, Name = "xxx-xxx", Price = 30M, Category = ProductCategory.GiftVoucher };


            var product13 = new Product { Id = 13, Name = "Shirt", Price = 20.00M, Category = ProductCategory.Clothing };
            var product14 = new Product { Id = 14, Name = "Shirt", Price = 30.00M, Category = ProductCategory.Clothing };
            var product15 = new Product { Id = 15, Name = "Shirt", Price = 50.00M, Category = ProductCategory.Clothing };

            var product16 = new Product { Id = 16, Name = "Coat", Price = 250.00M, Category = ProductCategory.Clothing };

            return new List<Product> { product1, product2, product3, product4, product5, product6, product7, product8,
                product9, product10, product11, product12, product13, product14, product15, product16 };
        }
    }
}
