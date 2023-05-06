using Microsoft.AspNetCore.Mvc;
using Restaurant.Interfaces;
using Restaurant.Models;
using Restaurant.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class FlowerController : Controller
    {//step:4 inject Iflowerrepository in FLOWERCONTROLLER CONSTRUCTOR
        private readonly IFlowerRepository _repo;
       // FlowerRepository repo = new FlowerRepository();
        public IActionResult Index()
        {
            return View();
        }
        public FlowerController(IFlowerRepository repo)//constructor injection
        {
            _repo = repo;
        }

        public IActionResult CreateFlower(flower model)
        {
            _repo.CreateFlower(model);
            return View();
        }
    }
}
