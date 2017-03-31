namespace OnlineStoreDomain
{
    public class CartEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public ProductEntity ProductEntity { get; set; }
    }
}