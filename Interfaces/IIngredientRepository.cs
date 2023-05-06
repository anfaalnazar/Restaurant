using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Interfaces
{
    public interface IIngredientRepository
    {
            public void Createingredient(Ingredient model);
        public List<UOM_VM> getallUOM();
        public List<ProductVM> getallproducts();
        public List<IngredientVM> getallingredients();



    }
}
