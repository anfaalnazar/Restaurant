using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class StudentModel
    {
        public int studentid { get; set; }
        public string studentname { get; set; }
        public IFormFile photo { get; set; }
        //IFormFile is an interface used to copy the file into the filestream.
        public string photopath { get; set; }

    }
}
