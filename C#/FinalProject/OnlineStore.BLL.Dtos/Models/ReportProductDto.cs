using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BLL.Dtos.Models
{
    public class ReportProductDto
    {
        public string Name { get; set; }
        public string ManafacturerName { get; set; }
        public int SalesCount { get; set; }
        public decimal SalesSum { get; set; }

    }
}
