namespace Basket_Kata.Data.Entities
{
    public class DBProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DBProductCategory Category { get; set; }
    }
}
