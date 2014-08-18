using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using BussinesObject;
using DataAccessLayer;
using BusinessAccessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ASP.NET.WebForm.CodeAdmin
{
    public partial class insertDataJquery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateNew_Click(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string SaveData(string contactName, string contactNo)
        {
            string status = "";            
            int insert = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [ContactInfo] (ContactName,ContactNo) values(@ContactName,@ContactNo)", con);
            cmd.Parameters.AddWithValue("@ContactName", contactName);
            cmd.Parameters.AddWithValue("@ContactNo", contactNo);
            insert = cmd.ExecuteNonQuery();
            if (insert  > 0)
            {
                status = "success";
            }
            con.Close();
            return status;
        }
    }
}