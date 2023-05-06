using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant.Interfaces;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngredientRepository _repo;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Createingredient(int productid,string productname)
        
        {
           List<ProductVM> lstpdt = _repo.getallproducts();
            ViewBag.productList = new SelectList(lstpdt, "productid", "productname");

            ViewBag.productname = productname;
            List<UOM_VM> lstuom = _repo.getallUOM();
            ViewBag.UOMList = new SelectList(lstuom, "UOMid", "UOMname");

            return View();
           
        }

        public IngredientController(IIngredientRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Createingredient(Ingredient model)
        {
            _repo.Createingredient(model);
            return View();
        }
    }
}
