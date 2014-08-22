using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using BussinesObject;
using DataAccessLayer;
using BusinessAccessLayer;

namespace ASP.NET.WebForm.CodeAdmin
{
    public partial class insertDataJquery : System.Web.UI.Page
    {    
        protected void Page_Load(object sender, EventArgs e)
        {            
        }        

        [WebMethod]
        public static string SaveData(string Name, string LastName, string Email, string Company, string Date, string Status)
        {
            string status = string.Empty;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
            SqlCommand cmd;    

            try
            {
                cmd = new SqlCommand("[SP_InsertRegisterUser]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = Name;
                cmd.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = LastName;
                cmd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = Email;
                cmd.Parameters.AddWithValue("@Company", SqlDbType.NVarChar).Value = Company;
                cmd.Parameters.AddWithValue("@Date", SqlDbType.NVarChar).Value = Date;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = Status;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                int insert = cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (insert > 0)
                    status = "success";
                else
                    status = "failed";

                return status;
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
    }
}