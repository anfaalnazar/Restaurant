using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    public class CategoryRepository
    {
        string ConnectionString = @"Server=LAPTOP-8R2JSJSS\SQLEXPRESS01; Initial Catalog=Restaurant; Integrated Security=SSPI;TrustServerCertificate=True;";


        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            return con;
        }
        public void insertcategory(Category model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_INSERTCATEGORY]";
            SqlParameter[] myparams = new SqlParameter[1];
            myparams[0] = new SqlParameter("@categoryname", System.Data.SqlDbType.VarChar, 50);
            myparams[0].Value = model.categoryname;
            cmd.Parameters.Add(myparams[0]);
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

        public Category getcategorybyid(int categoryid)

        { 
           SqlCommand cmd = new SqlCommand();

           cmd.CommandType = CommandType.StoredProcedure;

           cmd.CommandText = "SP_GETSINGLECATEGORY";

         Category model = new Category();

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
        public void editcategory(Category model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_EDITCATEGORY]";
            SqlParameter[] myparams = new SqlParameter[2];
            myparams[0] = new SqlParameter("@categoryid", System.Data.SqlDbType.Int);
            myparams[0].Value = model.categoryid;
            cmd.Parameters.Add(myparams[0]);
            myparams[1] = new SqlParameter("@categoryname", System.Data.SqlDbType.VarChar, 50);
            myparams[1].Value = model.categoryname;
            cmd.Parameters.Add(myparams[1]);
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
    }
}
