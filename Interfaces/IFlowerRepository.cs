using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Interfaces
{//step1-create interface
   public interface IFlowerRepository
    {
        public void CreateFlower(flower model);
        public void EditFlower(flower model);
    }
}
