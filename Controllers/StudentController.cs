using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class StudentController : Controller
    {
        StudentRepository repo = new StudentRepository();
        //dependancy injection
        private readonly IWebHostEnvironment _webHostEnvironment;
        //_webHostEnvironment is used to get the whole path of the project till the wwwroot
        public StudentController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        private string ProcessUploadedFile(IFormFile photo)
        //IFormFile is an interface used to copy the file into the filestream.
        {
            string uniqueFileName = null;
            
            if (photo != null)
            {
                //in uploadsfolder,we get the whole path which compines the folder "images" where we need to save the images selected from browser.
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                //the uniquefilename is created using Guid(a builtin static class)+"_"+photo.filename(the name of the file from the browser)
                uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentModel model)
        {
            //We get a photo
            if (model.photo != null)
            {
                // If a new photo is uploaded, the existing photo must be
                // deleted. So check if there is an existing photo and delete
                if (model.photopath != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath,
                        "images", model.photopath);
                    System.IO.File.Delete(filePath);
                }
                // Save the new photo in wwwroot/images folder and update
                // PhotoPath property of the employee object
                model.photopath = ProcessUploadedFile(model.photo);
            }
            repo.insertstudent(model);
            return View();
        }
    }
}
