using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant.Models;
using Restaurant.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository repo = new ProductRepository();
        CategoryRepository catrepo = new CategoryRepository();
        UOMRepository uomrepo = new UOMRepository();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult createproduct()
        {
            
                List<CategoryVM> lstcat = repo.lstcategory(0);
                ViewBag.categoryList = new SelectList(lstcat, "categoryid", "categoryname");
            
            
                 List<UOM_VM> lstuom = repo.lstUOM(0);
                 ViewBag.UOMList = new SelectList(lstuom, "UOMid", "UOMname");
            
            return View();
        }
        public IActionResult getallproducts()
        {
            List<Product> lstproducts = new List<Product>();
            List<ProductVM> lstproductsvm = new List<ProductVM>();
            lstproducts = repo.listproducts();
            foreach (var item in lstproducts)
            {
                lstproductsvm.Add(new ProductVM
                {
                    productid=item.productid,
                    productname=item.productname,
                    categoryid=item.categoryid,
                    categoryname =catrepo.getcategorybyid(item.categoryid).categoryname,
                    minqnty =item.minqnty,
                    maxqnty=item.maxqnty,
                    UOMid=item.UOMid,
                    UOMname=uomrepo.getuombyid(item.UOMid).UOMname,
                    israw=item.israw,
                    reorderlevel=item.reorderlevel,
                    makequantity=item.makequantity,
                    makeuom=item.makeuom

                    
                });
            }
            return View(lstproductsvm);
        }

        public IActionResult editproduct(int productid)
        {
            Product productobj = new Product();
            productobj = repo.getproductbyid(productid);
            ProductVM model = new ProductVM
            {
                 productname=productobj.productname,
               // categoryname = productobj.categoryname),
                minqnty = productobj.minqnty,
                maxqnty = productobj.maxqnty,
                UOMid = productobj.UOMid,
                israw = productobj.israw,
                reorderlevel = productobj.reorderlevel,
                makequantity = productobj.makequantity,
                makeuom = productobj.makeuom

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult createproduct(ProductVM model)
        {

            //object initializer syntax
            Product objproduct = new Product()
            {
                productname = model.productname,
                categoryid = model.categoryid,
                minqnty = model.minqnty,
                maxqnty = model.maxqnty,
                UOMid = model.UOMid,
                israw = model.israw,
                reorderlevel = model.reorderlevel,
                makequantity = model.makequantity,
                makeuom = model.makeuom
               
            };
            repo.insertproduct(objproduct);
            return View();
        }

    }
}
