using System.Data.Entity;
using OnlineStoreDomain;

namespace OnlineStoreRepository
{
    public interface IRoleRepository : IBaseRepository<AppRole>
    {
        
    }

    public class RoleRepository : BaseRepository<AppRole>, IBaseRepository<AppRole>, IRoleRepository
    {
        public RoleRepository(DbContext context) : base(context)
        {
        }
    }
                
}