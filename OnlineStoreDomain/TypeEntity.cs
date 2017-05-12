using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreDomain
{
    public class TypeEntity: BaseEntity
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<ProductEntity> ProductEntity { get; set; }
    }
}