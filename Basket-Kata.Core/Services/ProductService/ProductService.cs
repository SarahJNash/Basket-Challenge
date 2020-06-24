using Basket_Kata.Data;
using Basket_Kata.Data.Entities;
using System.Collections.Generic;

namespace Basket_Kata.Core.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Get(int productId)
        {
            var product = _productRepository.Get(productId);
            //i could use something like automapper here, but find the complexity that often ends up in the mappers (which aren't easy to understand) 
            //negates the benefit's just for the sake of a few mins typing everything.
            if (product == null)
            {
                throw new KeyNotFoundException("Product Id could not be found");
            }
            return Map(product);
        }

        private Product Map(DBProduct product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = (ProductCategory)product.Category
            };
        }
    }
}
