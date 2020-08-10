using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace OnlineStore.WebPLL.IdentityServices
{
    public class UserService
    {
        public void Delete(string customerId)
        {
            using (var context = new IdentityDbContext())
            {
                context.Users.Remove(context.Users.Single(u => u.Id == customerId));
                context.SaveChanges();
            }
        }
    }
}