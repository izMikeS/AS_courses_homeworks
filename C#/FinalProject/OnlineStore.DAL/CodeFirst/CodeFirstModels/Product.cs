using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.DAL
{
    public partial class Product
    {
        public Product()
        {
            this.ProductAtOrders = new HashSet<ProductAtOrder>();
        }
    
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }


        public virtual Category Category { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<ProductAtOrder> ProductAtOrders { get; set; }
    }
}
