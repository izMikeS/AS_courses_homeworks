using System;
using System.Xml.Serialization;

namespace FirstSubtask
{
    [XmlInclude(typeof(DefaultUser))]
    [XmlInclude(typeof(Admin))]
    public abstract class User : IContract
    {
        protected string userName;
        protected string hashedPassword;

        public string Name
        {
            get => userName;
            set => userName = value ??
            throw new ArgumentNullException(nameof(userName), "The value cannot be null");
        }
        public string HashedPassword
        {
            get => hashedPassword;
            set => hashedPassword = value ??
            throw new ArgumentNullException(nameof(hashedPassword), "The value cannot be null");
        }
        public User() {}
        public User(string userName, string hashedPass)
        {
            Name = userName;
            HashedPassword = hashedPass;
        }
    }
}