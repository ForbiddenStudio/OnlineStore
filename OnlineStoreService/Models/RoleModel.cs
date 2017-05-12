using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineStoreService.Models
{   
    public class RoleModel : IdentityRole
    {
        public RoleModel() : base() { }

        public RoleModel(string name)
            : base(name)
        { }
    }
}