using OnlineStore.WebPLL.Models.ShortModels;
using System;
using System.Collections.Generic;

namespace OnlineStore.WebPLL.Models.FullModels
{
    public class CategoryFullViewModel
    {
        public CategoryShortViewModel Category { get; set; }
        public List<ProductShortViewModel> Products { get; set; }
    }
}