using System.Collections.Generic;

namespace OnlineStore.DAL
{
    public partial class Order
    {
        public Order()
        {
            this.ProductAtOrders = new HashSet<ProductAtOrder>();
        }
    
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual ICollection<ProductAtOrder> ProductAtOrders { get; set; }
    }
}
