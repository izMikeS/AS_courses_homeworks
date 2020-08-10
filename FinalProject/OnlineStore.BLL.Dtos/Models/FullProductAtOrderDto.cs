using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Dtos.Models
{
    public class FullProductAtOrderDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public ProductDto Product { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
