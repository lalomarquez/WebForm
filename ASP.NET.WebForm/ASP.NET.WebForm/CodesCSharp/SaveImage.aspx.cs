using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET.WebForm.CodesCSharp
{
    public partial class SaveImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {            
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
            SqlCommand cmd;            

            if (FileUpload1.HasFile)
            {
                string pathName = "UploadImages/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                
                try
                {                    
                    cmd = new SqlCommand("[SP_SaveImage]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ImageURL", SqlDbType.NVarChar).Value = pathName;
                    cmd.Parameters.AddWithValue("@Fecha", SqlDbType.SmallDateTime).Value = System.DateTime.Now;

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    int insert = cmd.ExecuteNonQuery();

                    if (insert > 0)
                    {
                        FileUpload1.SaveAs(Server.MapPath("~/UploadImages/" + FileUpload1.FileName));
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('File save Successful..!! ');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Error..!! ');", true);
                    }        
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
            else            
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Please select a file to upload ');", true);                        
        }
    }
}