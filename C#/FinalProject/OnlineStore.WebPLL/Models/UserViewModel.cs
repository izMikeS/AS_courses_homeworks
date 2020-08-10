using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel;

namespace OnlineStore.WebPLL.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public ICollection<IdentityUserRole> Roles { get; set; }
    }
}