using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO = BussinesObject;
using System.Data.SqlClient;
using System.Data;


namespace DataAccessLayer
{
    public class DAL_User
    {
            SqlConnection conn = classConn.ReturnConn();
            SqlCommand cmd;
            SqlDataAdapter adp;

            public DataTable SearchDAL(BO.BO_User user)
            {
                DataTable dt = new DataTable();
                try
                {
                    cmd = new SqlCommand("[SP_SearchRegisterUser]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = user.Name;
                    adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);
                    cmd.Dispose();
                }
                catch (Exception ex)
                {                    
                    throw ex;
                }
                finally
                {
                    dt.Dispose();
                }
                return dt;
            }
            public int CreteDAL(BO.BO_User user)
            {                
                int result = 0;                
                try
                {
                    cmd = new SqlCommand("[SP_InsertRegisterUser]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = user.Name;
                    cmd.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = user.LastName;
                    cmd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = user.Email;
                    cmd.Parameters.AddWithValue("@Company", SqlDbType.NVarChar).Value = user.Company;
                    cmd.Parameters.AddWithValue("@Date", SqlDbType.NVarChar).Value = user.Date;
                    cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = user.Status;
                    
                    if (conn.State == ConnectionState.Closed)
                    conn.Open();

                    result = cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    if (result > 0)
                        return result;
                    else
                        return 0;
                }
                catch(Exception ex)
                {
                    throw ex;
                    // Response.Write("Oops! error occured :" + ex.Message.ToString());
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
            public DataSet ReadRecordsDAL()
            {
                DataSet ds = new DataSet();
                try
                {
                    cmd = new SqlCommand("[SP_FetchRegisterUser]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    adp = new SqlDataAdapter(cmd);
                    adp.Fill(ds);
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    ds.Dispose();
                }
                return ds;
            }
            public int UpdateDAL(BO.BO_User user)
            {
                int result = 0;
                try
                {
                    cmd = new SqlCommand("[SP_UpdateRegisterUser]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = user.ID_User;                    
                    cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = user.Name;
                    cmd.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = user.LastName;
                    cmd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = user.Email;
                    cmd.Parameters.AddWithValue("@Company", SqlDbType.NVarChar).Value = user.Company;
                    cmd.Parameters.AddWithValue("@Date", SqlDbType.NVarChar).Value = user.Date;
                    cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = user.Status;

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    result = cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    if (result > 0)
                        return result;
                    else
                        return 0;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }                
            }
            public int DeleteDAL(BO.BO_User user)
            {
                int result = 0;
                try
                {
                    cmd = new SqlCommand("[SP_DeleteRegisterUser]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = user.ID_User;                    

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    result = cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    if (result > 0)
                        return result;
                    else
                        return 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }                
            }

            //[WebMethod]
            //public int DeleteDALAjax(BO.BO_User user)
            //{
            //    int result = 0;
            //    try
            //    {
            //        cmd = new SqlCommand("[SP_DeleteRegisterUser]", conn);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = user.ID_User;

            //        if (conn.State == ConnectionState.Closed)
            //            conn.Open();

            //        result = cmd.ExecuteNonQuery();
            //        cmd.Dispose();

            //        if (result > 0)
            //            return result;
            //        else
            //            return 0;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //    finally
            //    {
            //        if (conn.State != ConnectionState.Closed)
            //        {
            //            conn.Close();
            //            conn.Dispose();
            //        }
            //    }
            
            //}
    }
}
