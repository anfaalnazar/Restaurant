using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class IngredientVM
    {
        public int ingredientid { get; set; }
        public int productid { get; set; }
        public int rawmaterialid { get; set; }
        public int quantity { get; set; }
        public int UOMid { get; set; }
    }
}
