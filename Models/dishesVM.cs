using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class dishesVM
    {
        public int dishid { get; set; }
        public string dishname { get; set; }
        public string dishcolor { get; set; }
        public string dishtype { get; set; }
        public int categoryid { get; set; }
        public string categoryname { get; set; }
    }
}
