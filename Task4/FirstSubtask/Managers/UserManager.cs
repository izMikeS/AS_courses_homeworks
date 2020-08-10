using FirstSubtask.Models;
using System;
using System.Linq;

namespace FirstSubtask.Managers
{
    public class UserManager : FileManager<User>
    {
        private readonly string _userName;
        private readonly string _pass;
        private readonly Rights _rights;

        public UserManager(string userName, string pass, string userFilePath, Rights rights = default)
                        : base(userFilePath)

        {
            _userName = userName;
            _pass = pass;
            _rights = rights;
        }

        public User Login()
        {
            return Load()
                           .FirstOrDefault(u => u.Name == _userName
                                                && u.HashedPassword == Hasher.GetMd5Hash(_pass));
        }

        public void Register()
        {
            var users = Load();

            if (users.Any(p => p.Name == _userName))
            {
                throw new ArgumentException("A user with the same name already exists.", nameof(_userName));
            }

            User registeredUser = _rights == Rights.Default ?
             new DefaultUser(_userName, Hasher.GetMd5Hash(_pass), new Cart(), FilePaths.PRODUCTS) :
             (User)new Admin(_userName, Hasher.GetMd5Hash(_pass));
            AddOrUpdate(registeredUser);
        }
    }
}
