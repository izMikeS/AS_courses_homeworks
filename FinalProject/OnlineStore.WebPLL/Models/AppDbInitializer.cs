using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace OnlineStore.WebPLL.Models
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var adminRole = new IdentityRole { Name = RolesConstants.ADMIN };
            var employeeRole = new IdentityRole { Name = RolesConstants.EMPLOYEE };
            var customerRole = new IdentityRole { Name = RolesConstants.CUSTOMER };

            roleManager.Create(adminRole);
            roleManager.Create(employeeRole);
            roleManager.Create(customerRole);


            base.Seed(context);
        }
    }
}