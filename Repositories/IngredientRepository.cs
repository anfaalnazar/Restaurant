using Microsoft.Extensions.Configuration;
using Restaurant.Interfaces;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly IConfiguration _config;
        //step:3 inject Iconfiguration 
        public IngredientRepository(IConfiguration config)
        {
            _config = config;
        }

        private SqlConnection GetConnection()
        {
            string connectionstring = _config.GetConnectionString("Rest");
            return new SqlConnection(connectionstring);
        }


        public void Createingredient(Ingredient model)
        {
            throw new NotImplementedException();
        }

        public List<ProductVM> getallproducts()
        {

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_GETALLPRODUCTS";

            ProductVM model = new ProductVM();

            List<ProductVM> lstproducts = new List<ProductVM>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {

                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {

                        while (rd.Read())
                        {
                            model.productid = Convert.ToInt32(rd["productid"]);
                            model.productname = rd["productname"].ToString();
                            model.categoryid = Convert.ToInt32(rd["categoryid"]);
                            model.minqnty = Convert.ToInt32(rd["minqnty"]);
                            model.maxqnty = Convert.ToInt32(rd["maxqnty"]);
                            model.UOMid = Convert.ToInt32(rd["UOMid"]);
                            model.israw = Convert.ToChar(rd["israw"]);
                            model.reorderlevel = Convert.ToInt32(rd["reorderlevel"]);
                            model.makequantity = Convert.ToInt32(rd["makequantity"]);
                            model.makeuom = Convert.ToInt32(rd["makeuom"]);
                            lstproducts.Add(model);
                            model = new ProductVM();


                        }
                    }
                }
                return lstproducts;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return lstproducts;
        }
        public List<UOM_VM> getallUOM()
        {

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_GETALLUOM";

            UOM_VM model = new UOM_VM();

            List<UOM_VM> lstuom = new List<UOM_VM>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {

                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            model.UOMid = Convert.ToInt32(rd["UOMid"]);
                            model.UOMname = rd["UOMname"].ToString();
                            lstuom.Add(model);
                            model = new UOM_VM();
                        }


                    }
                }
                return lstuom;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return lstuom;
        }

        public List<IngredientVM> getallingredients()
        {
            throw new NotImplementedException();
        }
    }
}


