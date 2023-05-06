using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Product
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public int categoryid { get; set; }
        public int minqnty { get; set; }
        public int maxqnty { get; set; }
        public int UOMid { get; set; }
        public char israw { get; set; }
        public int reorderlevel { get; set; }
        public int makequantity { get; set; }
        public int makeuom { get; set; }
        public int IsActive { get; set; }

    }
}
