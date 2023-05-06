using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    public class StudentRepository
    {
        string ConnectionString = @"Server=LAPTOP-8R2JSJSS\SQLEXPRESS01; Initial Catalog=Restaurant; Integrated Security=SSPI;TrustServerCertificate=True;";


        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            return con;
        }
        public void insertstudent(StudentModel model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_INSERTSTUDENT]";
            SqlParameter[] myparams = new SqlParameter[2];
            myparams[0] = new SqlParameter("@studentname", System.Data.SqlDbType.NVarChar, 50);
            myparams[0].Value = model.studentname;
            cmd.Parameters.Add(myparams[0]);
            myparams[1] = new SqlParameter("@photopath", System.Data.SqlDbType.NVarChar, 100);
            myparams[1].Value = model.photopath;
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
