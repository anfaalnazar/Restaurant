using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class UOMController : Controller
    {
        UOMRepository repo = new UOMRepository();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult getallUOM()
        {
            List<UOM> lstuom = new List<UOM>();
            List<UOM_VM> lstuomvm = new List<UOM_VM>();
            lstuom = repo.lstuom();
            foreach (var item in lstuom)
            {
                lstuomvm.Add(new UOM_VM
                {
                    UOMid = item.UOMid,
                    UOMname = item.UOMname,

                });
            }
            return View(lstuomvm);
        }


        public IActionResult editUOM(int UOMid)
        {
            UOM uomobj = new UOM();
            uomobj = repo.getuombyid(UOMid);
            UOM_VM model = new UOM_VM
            {
                UOMname = uomobj.UOMname

            };
            return View(model);
        }

        [HttpPost]

        public IActionResult Index(UOM_VM model)
        {
            UOM objUOM = new UOM()
            {

                UOMname = model.UOMname

            };
            repo.insertUOM(objUOM);
            return View();

        }

        [HttpPost]
        public IActionResult editUOM(UOM_VM model)
        {
            UOM objUOM = new UOM()
            {
                UOMid= model.UOMid,
                UOMname = model.UOMname

            };
            repo.editUOM(objUOM);
            return View(model);
        }
    }
}
