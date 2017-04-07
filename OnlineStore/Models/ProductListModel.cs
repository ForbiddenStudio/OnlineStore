using System.Collections.Generic;
using OnlineStoreDomain;

namespace OnlineStore.Models
{
    public class ProductListModel
    {
        public IEnumerable<ProductEntity> Product { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}