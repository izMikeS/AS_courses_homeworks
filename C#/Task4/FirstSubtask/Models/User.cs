using System;
using System.Xml.Serialization;

namespace FirstSubtask.Models
{
    [XmlInclude(typeof(DefaultUser))]
    [XmlInclude(typeof(Admin))]
    public abstract class User : IContract
    {
        protected string _userName;
        protected string _hashedPassword;

        public User() { }
        public User(string userName, string hashedPass)
        {
            Name = userName;
            HashedPassword = hashedPass;
        }

        public string Name
        {
            get => _userName;
            set => _userName = value ??
            throw new ArgumentNullException(nameof(_userName), "The value cannot be null");
        }

        public string HashedPassword
        {
            get => _hashedPassword;
            set => _hashedPassword = value ??
            throw new ArgumentNullException(nameof(_hashedPassword), "The value cannot be null");
        }

    }
}