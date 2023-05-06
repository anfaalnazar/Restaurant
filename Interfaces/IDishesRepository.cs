using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Restaurant.Interfaces
{
    public interface IDishesRepository
    {
        public void createdishes(dishes model);
        public void editdishes(dishes model);
        public List<Category> lstcategory();
        public List<dishes> lstdishes();
        public dishes getdishesbyid(int dishid);
    }
}
