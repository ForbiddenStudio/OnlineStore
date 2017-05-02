using OnlineStoreDomain;

namespace OnlineStoreService.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
      
        public decimal Price { get; set; }
       
        public double Volume { get; set; }
       
        public int TypeEntityId { get; set; }

        public  TypeEntity TypeEntity { get; set; }

    }
}