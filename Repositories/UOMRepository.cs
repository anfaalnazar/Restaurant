using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    public class UOMRepository
    {
        string ConnectionString = @"Server=LAPTOP-8R2JSJSS\SQLEXPRESS01; Initial Catalog=Restaurant; Integrated Security=SSPI;TrustServerCertificate=True;";


        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            return con;
        }
        public void insertUOM(UOM model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_INSERTUOM]";
            SqlParameter[] myparams = new SqlParameter[1];
            myparams[0] = new SqlParameter("@UOMname", System.Data.SqlDbType.VarChar, 50);
            myparams[0].Value = model.UOMname;
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
        public List<UOM> lstuom()
        {

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_GETALLUOM";

            UOM model = new UOM();

            List<UOM> lstuom = new List<UOM>();
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
                            model = new UOM();
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

        public UOM getuombyid(int UOMid)

        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_GETSINGLEUOM";

            UOM model = new UOM();

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
        public void editUOM(UOM model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_EDITUOM]";
            SqlParameter[] myparams = new SqlParameter[2];
            myparams[0] = new SqlParameter("@UOMid", System.Data.SqlDbType.Int);
            myparams[0].Value = model.UOMid;
            cmd.Parameters.Add(myparams[0]);
            myparams[1] = new SqlParameter("@UOMname", System.Data.SqlDbType.VarChar, 50);
            myparams[1].Value = model.UOMname;
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