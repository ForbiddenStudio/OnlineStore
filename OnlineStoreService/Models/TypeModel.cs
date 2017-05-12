using System.Collections.Generic;
using OnlineStoreDomain;

namespace OnlineStoreService.Models
{
    public class TypeModel : BaseModel
    {
        public string Name { get; set; }
        public List<ProductEntity> ProductEntity { get; set; }
    }
}