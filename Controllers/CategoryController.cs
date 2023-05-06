using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Restaurant.Models;
using Restaurant.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class CategoryController : Controller
    {
         
        CategoryRepository repo = new CategoryRepository();
        private readonly IConfiguration _config;

        public IActionResult Index()
        {
            return View();
        }

        public CategoryController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult getallcategories(int ? CurrentPage)
        {
            
            List<Category> lstcategory = new List<Category>();
            List<CategoryVM> lstcategoriesvm = new List<CategoryVM>();
            lstcategory = repo.lstcategory();
            var pageSize =Convert.ToInt32( _config.GetSection("CustomValue:pageSize").Value);
            foreach (var item in lstcategory)
            {
                lstcategoriesvm.Add(new CategoryVM
                {
                    categoryid = item.categoryid,
                    categoryname = item.categoryname,
                    
                });
            }
          int TotalPages=  (int)Math.Ceiling(decimal.Divide(lstcategory.Count, pageSize));
            ViewBag.TotalPages = TotalPages;
            ViewBag.CurrentPage = CurrentPage ==null ? 0: CurrentPage ;
            int ctpage = CurrentPage == null ? 0 : CurrentPage.Value;
          var newlist=  lstcategoriesvm.OrderBy(d => d.categoryid).Skip((ctpage - 1) * pageSize).Take(pageSize).ToList();
            return View(newlist);
        }
            
       

        public IActionResult editcategory(int categoryid)
        {
          
            Category categoryobj = new Category();
            categoryobj = repo.getcategorybyid(categoryid);
            CategoryVM model = new CategoryVM
            {
                categoryname = categoryobj.categoryname

            };
            return View(model);
        }

        [HttpPost]

        public IActionResult Index(CategoryVM model)
        {
            Category objcat = new Category()
            {

                categoryname = model.categoryname

            };
            repo.insertcategory(objcat);
            return View();

        }

        [HttpPost]
        public IActionResult editcategory(CategoryVM model)
        
        {
            Category objcat = new Category()
            {
                categoryid = model.categoryid,
                categoryname = model.categoryname

            };
            repo.editcategory(objcat);
            return View(model);
        }

    }
    
}
