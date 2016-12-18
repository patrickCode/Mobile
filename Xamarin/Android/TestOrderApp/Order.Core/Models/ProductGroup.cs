﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Core.Models
{
    public class ProductGroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath{ get; set; }
        public List<Product> Products { get; set; }
    }
}
