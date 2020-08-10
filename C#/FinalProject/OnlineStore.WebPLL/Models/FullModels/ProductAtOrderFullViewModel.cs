using OnlineStore.WebPLL.Models.ShortModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.WebPLL.Models.FullModels
{
    public class ProductAtOrderFullViewModel
    {
        public ProductShortViewModel Product { get; set; }
        public int OrderId { get; set; }
        public int Count { get; set; }
    }
}