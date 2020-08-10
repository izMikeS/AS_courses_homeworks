using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Dtos.Models
{
    public class FullOrderDto
    {
        public HalfOrderDto Order { get; set; }

        public List<FullProductAtOrderDto> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
