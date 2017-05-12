namespace OnlineStoreDomain
{
    public class CartEntity: BaseEntity
    {
       // public int Id { get; set; }
        public int Quantity { get; set; }
        public ProductEntity ProductEntity { get; set; }
    }
}