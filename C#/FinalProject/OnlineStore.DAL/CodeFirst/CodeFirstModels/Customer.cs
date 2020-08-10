using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.DAL
{
    public partial class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        [Index(IsUnique = true)]
        public string Username { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [StringLength(80)]
        public string Email { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(200)]
        public string AuthId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
