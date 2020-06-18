namespace Basket_Kata.Core
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ProductCategory Category {get;set;}
    }
}
