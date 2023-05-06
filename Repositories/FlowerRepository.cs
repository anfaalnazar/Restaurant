using Microsoft.Extensions.Configuration;
using Restaurant.Interfaces;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{//step:2 implement IFlowerRepository Interface
    public class FlowerRepository:IFlowerRepository
    {
        private readonly IConfiguration _config;
        //step:3 inject Iconfiguration 
        public FlowerRepository(IConfiguration config)//constructor injection
        {
            _config = config;
        }

        private SqlConnection GetConnection()
        {
            string connectionstring = _config.GetConnectionString("Rest");
            return new SqlConnection(connectionstring);
        }

        public void CreateFlower(flower model)
        {

        }

        public void EditFlower(flower model)
        {
            throw new NotImplementedException();
        }
    }
}
