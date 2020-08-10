using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.DAL
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            this.Products = new HashSet<Product>();
        }
    
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public string ImgUrl { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }
}
