using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    public class ProductRepository
    {
        string ConnectionString = @"Server=LAPTOP-8R2JSJSS\SQLEXPRESS01; Initial Catalog=Restaurant; Integrated Security=SSPI;TrustServerCertificate=True;";


        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            return con;
        }

        public void insertproduct(Product model)
        {
//            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_INSERTPRODUCT";
            SqlParameter[] myparams = new SqlParameter[9];
            myparams[0] = new SqlParameter("@productname", System.Data.SqlDbType.VarChar,50);
            myparams[0].Value = model.productname;
            cmd.Parameters.Add(myparams[0]);
            myparams[1] = new SqlParameter("@categoryid", System.Data.SqlDbType.Int);
            myparams[1].Value = model.categoryid;
            cmd.Parameters.Add(myparams[1]);
            myparams[2] = new SqlParameter("@minqnty", System.Data.SqlDbType.Int);
            myparams[2].Value = model.minqnty;
            cmd.Parameters.Add(myparams[2]);
            myparams[3] = new SqlParameter("@maxqnty", System.Data.SqlDbType.Int);
            myparams[3].Value = model.maxqnty;
            cmd.Parameters.Add(myparams[3]);
            myparams[4] = new SqlParameter("@UOMid", System.Data.SqlDbType.Int);
            myparams[4].Value = model.UOMid;
            cmd.Parameters.Add(myparams[4]);
            myparams[5] = new SqlParameter("@israw", System.Data.SqlDbType.Char);
            myparams[5].Value = model.israw;
            cmd.Parameters.Add(myparams[5]);
            myparams[6] = new SqlParameter("@makequantity", System.Data.SqlDbType.Int);
            myparams[6].Value = model.makequantity;
            cmd.Parameters.Add(myparams[6]);
            myparams[7] = new SqlParameter("@makeuom", System.Data.SqlDbType.Int);
            myparams[7].Value = model.makeuom;
            cmd.Parameters.Add(myparams[7]);
            myparams[8] = new SqlParameter("@reorderlevel", System.Data.SqlDbType.Int);
            myparams[8].Value = model.reorderlevel;
            cmd.Parameters.Add(myparams[8]);

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        public List<CategoryVM> lstcategory(int categoryid)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_GETSINGLEORALLCATEGORY";

            CategoryVM model = new CategoryVM();

            List<CategoryVM> lstcategory = new List<CategoryVM>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    cmd.Parameters.Add(new SqlParameter("@categoryid", SqlDbType.Int));
                    cmd.Parameters[0].Value = categoryid;
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {

                        while (rd.Read())
                        {
                            model.categoryid = Convert.ToInt32(rd["categoryid"]);
                            model.categoryname = rd["categoryname"].ToString();
                            lstcategory.Add(model);
                            model = new CategoryVM();


                        }

                    }

                }
                return lstcategory;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return lstcategory;
        }
        public List<UOM_VM> lstUOM(int UOMid)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_GETSINGLEORALLUOM";

            UOM_VM model = new UOM_VM();

            List<UOM_VM> lstuom = new List<UOM_VM>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    cmd.Parameters.Add(new SqlParameter("@UOMid", SqlDbType.Int));
                    cmd.Parameters[0].Value = UOMid;
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
        public List<Product> listproducts()
        {

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_GETALLPRODUCTS";

            Product model = new Product();

            List<Product> lstproducts = new List<Product>();
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
                            model.reorderlevel= Convert.ToInt32(rd["reorderlevel"]);
                            model.makequantity = Convert.ToInt32(rd["makequantity"]);
                            model.makeuom = Convert.ToInt32(rd["makeuom"]);
                            lstproducts.Add(model);
                            model = new Product();


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
        public Product getproductbyid(int productid)
        {

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_GETSINGLEPRODUCT";

            Product model = new Product();

            List<ProductVM> lstproducts = new List<ProductVM>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    cmd.Parameters.Add(new SqlParameter("@productid", SqlDbType.Int));
                    cmd.Parameters[0].Value = productid;
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
                            
                           


                        }
                    }
                }
                return model;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return model;
        }

    }
}
