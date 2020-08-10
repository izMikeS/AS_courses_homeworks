using System;
using System.Linq;

namespace FirstSubtask
{
    public class UserManager
    {
        private FileManager<User> usersFile;
        private readonly string userName;
        private readonly string pass;
        private readonly Rights rights;

        public UserManager(string userName, string pass, string userFilePath, Rights rights = default)
        {
            usersFile = new FileManager<User>(userFilePath);
            this.userName = userName;
            this.pass = pass;
            this.rights = rights;
        }

        public User Login()
        {
            return usersFile.Load()
                           .FirstOrDefault(u => u.Name == userName
                                                && u.HashedPassword == Hasher.GetMd5Hash(pass));
        }

        public void Register()
        {
            User[] users = usersFile.Load();

            if (users.FirstOrDefault(p => p.Name == userName) != null)
                throw new ArgumentException("A user with the same name already exists.", nameof(userName));

            User registeredUser = rights == Rights.Default ?
             (User)new DefaultUser(userName, Hasher.GetMd5Hash(pass), new Cart(), FilePaths.PRODUCTS) :
             (User)new Admin(userName, Hasher.GetMd5Hash(pass));
            usersFile.AddOrUpdate(registeredUser);
        }
    }
}
