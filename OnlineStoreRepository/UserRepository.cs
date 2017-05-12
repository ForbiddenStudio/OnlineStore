using System.Data.Entity;
using OnlineStoreDomain;

namespace OnlineStoreRepository
{
    public interface IUserRepository : IBaseRepository<AppUser>
    {
        
    }
    public class UserRepository : BaseRepository<AppUser>, IBaseRepository<AppUser>,IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}