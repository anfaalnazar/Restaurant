using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant.Interfaces;
using Restaurant.Models;
using Restaurant.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class DishesController : Controller
    {
        private readonly IDishesRepository _repo;
        CategoryRepository catrepo = new CategoryRepository();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult createdishes(int categoryid,string categoryname)
        {
            List<Category> lstcat = _repo.lstcategory();
            ViewBag.categoryList = new SelectList(lstcat, "categoryid", "categoryname");
            return View();
        }
        public DishesController(IDishesRepository repo)
        {
            _repo = repo;
        }
        public IActionResult getalldishes()
        {
            List<dishes> lstdishes = new List<dishes>();
            List<dishesVM> lstdishesvm = new List<dishesVM>();
            lstdishes = _repo.lstdishes();
            foreach (var item in lstdishes)
            {
                lstdishesvm.Add(new dishesVM
                {
                    dishid = item.dishid,
                    dishname = item.dishname,
                    dishcolor=item.dishcolor,
                    dishtype=item.dishtype,
                    categoryid = item.categoryid,
                    categoryname = catrepo.getcategorybyid(item.categoryid).categoryname
                   
                });
            }
            return View(lstdishesvm);
        }


        public IActionResult editdishes(int dishid)
        {

            dishes dishobj = new dishes();
            dishobj = _repo.getdishesbyid(dishid);
            dishesVM model = new dishesVM
            {
                
                dishname = dishobj.dishname,
                dishcolor = dishobj.dishcolor,
                dishtype = dishobj.dishtype,
                categoryid = dishobj.categoryid

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult createdishes(dishesVM model)
        {
            dishes objdish = new dishes()
            {

                dishname = model.dishname,
                dishcolor = model.dishcolor,
                dishtype = model.dishtype,
                categoryid = model.categoryid

            };
            _repo.createdishes(objdish);
            return View();

        }

        [HttpPost]
        public IActionResult editdishes(dishes model)

        {
            dishes objdish = new dishes()
            {
                dishid = model.dishid,
                dishname = model.dishname,
                dishcolor = model.dishcolor,
                dishtype = model.dishtype,
                categoryid = model.categoryid

            };
            _repo.editdishes(objdish);
            return View(model);
        }


    }
}
