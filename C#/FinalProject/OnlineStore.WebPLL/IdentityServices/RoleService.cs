using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace OnlineStore.WebPLL.IdentityServices
{
    public class RoleService
    {
        public void GrantRole(string roleName, string customerId, bool @override = false)
        {
            using (var context = new IdentityDbContext())
            {
                var user = context.Users.Single(u => u.Id == customerId);
                var role = new IdentityUserRole
                {
                    RoleId = context.Roles.Single(r => r.Name == roleName).Id,
                    UserId = user.Id
                };

                if (@override)
                {
                    user.Roles.Clear();
                }

                if (!user.Roles.Any(r => r.UserId == user.Id
                 && r.RoleId == role.RoleId))
                {
                    user.Roles.Add(role);
                }

                context.SaveChanges();
            }
        }

    }
}