using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.DAL
{
    public partial class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
    
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(80)] //todo: view models constraints = this.contstraints
        public string Name { get; set; }

        public string ImgUrl { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }
}
