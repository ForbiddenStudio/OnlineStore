using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreDomain;

namespace OnlineStoreRepository
{
    public interface ITypesRepository : IBaseRepository<TypeEntity>
    {
     
    }
    public class TypeRepository : BaseRepository<TypeEntity>,ITypesRepository
    {
        public TypeRepository(DbContext context) : base(context)
        {
        }
    }
}
