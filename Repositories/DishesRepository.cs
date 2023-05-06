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
    
        public class DishesRepository : IDishesRepository
        {

            private readonly IConfiguration _config;

            public DishesRepository(IConfiguration config)
            {
                _config = config;
            }

            private SqlConnection GetConnection()
            {
                string connectionstring = _config.GetConnectionString("Rest");
                return new SqlConnection(connectionstring);
            }

            public void createdishes(dishes model)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[SP_INSERTDISHES]";
                SqlParameter[] myparams = new SqlParameter[4];
                myparams[0] = new SqlParameter("@dishname", System.Data.SqlDbType.VarChar, 50);
                myparams[0].Value = model.dishname;
                cmd.Parameters.Add(myparams[0]);
                myparams[1] = new SqlParameter("@dishcolor", System.Data.SqlDbType.VarChar, 50);
                myparams[1].Value = model.dishname;
                cmd.Parameters.Add(myparams[1]);
                myparams[2] = new SqlParameter("@dishtype", System.Data.SqlDbType.VarChar, 50);
                myparams[2].Value = model.dishtype;
                cmd.Parameters.Add(myparams[2]);
                myparams[3] = new SqlParameter("@categoryid", System.Data.SqlDbType.Int);
                myparams[3].Value = model.categoryid;
                cmd.Parameters.Add(myparams[3]);
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
         public List<Category> lstcategory()
        {

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_GETALLCATEGORIES";

            Category model = new Category();

            List<Category> lstcategory = new List<Category>();
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
                            model.categoryid = Convert.ToInt32(rd["categoryid"]);
                            model.categoryname = rd["categoryname"].ToString();
                            lstcategory.Add(model);
                            model = new Category();
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

        public void editdishes(dishes model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_EDITDISHES]";
            SqlParameter[] myparams = new SqlParameter[4];
            myparams[0] = new SqlParameter("@dishname", System.Data.SqlDbType.VarChar, 50);
            myparams[0].Value = model.dishname;
            cmd.Parameters.Add(myparams[0]);
            myparams[1] = new SqlParameter("@dishcolor", System.Data.SqlDbType.VarChar, 50);
            myparams[1].Value = model.dishname;
            cmd.Parameters.Add(myparams[1]);
            myparams[2] = new SqlParameter("@dishtype", System.Data.SqlDbType.VarChar, 50);
            myparams[2].Value = model.dishtype;
            cmd.Parameters.Add(myparams[2]);
            myparams[3] = new SqlParameter("@categoryid", System.Data.SqlDbType.Int);
            myparams[3].Value = model.categoryid;
            cmd.Parameters.Add(myparams[3]);
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

        public List<dishes> lstdishes()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_GETALLDISHES";

            dishes model = new dishes();

            List<dishes> lstdishes = new List<dishes>();
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
                            model.dishid = Convert.ToInt32(rd["dishid"]);
                            model.dishname = rd["dishname"].ToString();
                            model.dishcolor = rd["dishcolor"].ToString();
                            model.dishtype = rd["dishtype"].ToString();
                            model.categoryid = Convert.ToInt32(rd["category"]);
                           
                            lstdishes.Add(model);
                            model = new dishes();


                        }
                    }
                }
                return lstdishes;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                
            }
            return lstdishes;
        }

        public dishes getdishesbyid(int dishid)

        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_GETSINGLEDISH";

            dishes model = new dishes();

            List<dishesVM> lstcategory = new List<dishesVM>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    cmd.Parameters.Add(new SqlParameter("@dishid", SqlDbType.Int));
                    cmd.Parameters[0].Value = dishid;
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {

                        while (rd.Read())
                        {
                            model.dishid = Convert.ToInt32(rd["dishid"]);
                            model.dishname = rd["dishname"].ToString();
                            model.dishcolor = rd["dishcolor"].ToString();
                            model.dishtype = rd["dishtype"].ToString();
                            model.categoryid = Convert.ToInt32(rd["category"]);
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


