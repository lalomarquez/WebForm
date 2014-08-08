using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Web.UI;
using System.Web;

namespace DataAccessLayer
{
    public class classConn
    {
        public static SqlConnection ReturnConn()
        {            
            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
            if (Conn.State == ConnectionState.Closed)
            {
                try
                {
                    Conn.Open();
                }
                catch (SqlException ex)
                {                                        
                    switch (ex.Number)
                    {
                        case 4060:
                            MessageBox.Show("Cannot open database.\nThe login failed.");
                            break;
                        case 26:
                            MessageBox.Show("Error: 26");
                            break;
                        default:
                            MessageBox.Show("Other Error");
                            break;
                    }
                }                
            }
            return Conn;
        }
        public static SqlCommand CreateCmd(string procName, SqlParameter[] prams, SqlConnection Conn)
        {
            SqlConnection SqlConn = Conn;

            //if (SqlConn.State.Equals(ConnectionState.Closed))
            if (SqlConn.State == (ConnectionState.Closed))
            {
                SqlConn.Open();
            }
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = SqlConn;
            Cmd.CommandText = procName;
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                {
                    if (parameter != null)
                    {
                        Cmd.Parameters.Add(parameter);
                    }
                }
            }
            return Cmd;
        }
        public static SqlCommand CreateCmd(string procName, SqlParameter[] prams)
        {
            SqlConnection Conn = ReturnConn();
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = Conn;
            Cmd.CommandText = procName;
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                {
                    if (parameter != null)
                    {
                        Cmd.Parameters.Add(parameter);
                    }
                }
            }
            return Cmd;
        }
        public static SqlCommand CreateCmd(string procName, SqlConnection Conn)
        {
            SqlConnection SqlConn = Conn;
            if (SqlConn.State.Equals(ConnectionState.Closed))
            {
                SqlConn.Open();
            }
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = SqlConn;
            Cmd.CommandText = procName;
            return Cmd;
        }
        public static SqlCommand CreateCmd(string procName)
        {
            SqlConnection Conn = ReturnConn();
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = Conn;
            Cmd.CommandText = procName;
            return Cmd;
        }
        public static DataSet GetAllRecords(string NameSP)
        {
            SqlConnection Conn = ReturnConn();
            SqlCommand Cmd = CreateCmd(NameSP, Conn);
            SqlDataAdapter Dtr = new SqlDataAdapter();
            DataSet Ds = new DataSet();
            Dtr.SelectCommand = Cmd;
            Dtr.Fill(Ds);
            Cmd.Dispose();
            //DataTable Dt = Ds.Tables[0];
            Conn.Close();

            return Ds;
        }
        public static SqlDataReader RunProcGetReader(string procName, SqlParameter[] prams)
        {
            SqlCommand Cmd = CreateCmd(procName, prams);
            SqlDataReader Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return Dr;
        }        
        public static SqlDataReader RunProcGetReader(string procName, SqlParameter[] prams, SqlConnection Conn)
        {
            SqlCommand Cmd = CreateCmd(procName, prams, Conn);
            SqlDataReader Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return Dr;
        }        
        public static SqlDataReader RunProcGetReader(string procName, SqlConnection Conn)
        {
            SqlCommand Cmd = CreateCmd(procName, Conn);
            SqlDataReader Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return Dr;
        }        
        public static SqlDataReader RunProcGetReader(string procName)
        {
            SqlCommand Cmd = CreateCmd(procName);
            SqlDataReader Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return Dr;
        }
        public static int RunExecute(string procName)
        {
            SqlConnection Conn = ReturnConn();
            SqlCommand Cmd = CreateCmd(procName, Conn);
            int intResult = Cmd.ExecuteNonQuery();
            Conn.Close();
            return intResult;
        }        
        public static int RunExecute(string procName, SqlParameter[] prams)
        {
            SqlConnection Conn = ReturnConn();
            SqlCommand Cmd = CreateCmd(procName, prams, Conn);
            int intResult = Cmd.ExecuteNonQuery();
            Conn.Close();
            return intResult;
        }
        public static int RunExecuteScalar(string procName)
        {
            SqlConnection Conn = ReturnConn();
            SqlCommand Cmd = CreateCmd(procName, Conn);
            int intResult = Convert.ToInt32(Cmd.ExecuteScalar());
            Conn.Close();
            return intResult;
        }
        public static int RunExecuteScalar(string procName, SqlParameter[] prams)
        {
            SqlConnection Conn = ReturnConn();
            SqlCommand Cmd = CreateCmd(procName, prams, Conn);
            int intResult = Convert.ToInt32(Cmd.ExecuteScalar());
            Conn.Close();
            return intResult;
        } 
        
        //Insert-Update-Delete
        public static int RunExecuteNonQuery(string NameSP)
        {
            int result = 0;
            SqlConnection Conn = ReturnConn();
            try
            {                
                SqlCommand Cmd = CreateCmd(NameSP, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = "bla";//Reg_User_ent.Prop_Name;
                Cmd.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = "bla";//Reg_User_ent.Prop_LastName;
                Cmd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = "bla";//Reg_User_ent.Prop_Email;
                Cmd.Parameters.AddWithValue("@Company", SqlDbType.NVarChar).Value = "bla";//Reg_User_ent.Prop_Company;
                Cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = "bla";//Reg_User_ent.Fecha;
                Cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = "bla";//Reg_User_ent.Fecha;

                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                result = Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }  
            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }
    }
}
