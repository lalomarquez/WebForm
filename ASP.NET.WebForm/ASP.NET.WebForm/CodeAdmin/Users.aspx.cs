using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using BO = BussinesObject;
using DAL = DataAccessLayer;
using BAL = BusinessAccessLayer;
namespace ASP.NET.WebForm.CodeAdmin
{
    public partial class Users : System.Web.UI.Page
    {
        BAL.BAL_User uBAL = new BAL.BAL_User();
        BO.BO_User User = new BO.BO_User();
        SqlCommand cmd;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);        
        SqlDataReader reader;
        SqlDataAdapter adp;
        string query = string.Empty;
        codeSnippets ms = new codeSnippets();
        int search = 0;
        int create = 0;
        int update = 0;
        int delete = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            panelMsg.Visible = false;

            #region Call whit Method & SP
            //DataSet datos = new DataSet();
            //try
            //{
            //    datos = TodoslsRegistros();
            //    if (datos.Tables.Count > 0 && datos.Tables[0].Rows.Count > 0)
            //    {
            //        GridView4.DataSource = datos;
            //        GridView4.DataBind();
            //    }
            //    else
            //    {
            //        GridView4.EmptyDataText = "No records Found";
            //        GridView4.DataSource = null;
            //        GridView4.DataBind();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ms.MsgBox(ex.ToString(), Page, this);
            //}
            #endregion

            #region Call whit SP
            //DataSet ds = new DataSet();
            //try
            //{
            //    ds = GetAllRecords();
            //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //    {
            //        GridView2.DataSource = ds;
            //        GridView2.DataBind();
            //    }
            //    else
            //    {
            //        GridView2.EmptyDataText = "No records Found";
            //        GridView2.DataSource = null;
            //        GridView2.DataBind();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ms.MsgBox(ex.ToString(), Page, this);
            //}
            #endregion

            #region Call whit query
            //query = "select * from dbo.SCRUD_RegisterUser";
            //if (conn.State == ConnectionState.Closed)
            //{
            //    try
            //    {
            //        conn.Open();

            //        cmd = new SqlCommand(query, conn);
            //        reader = cmd.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            GridView3.DataSource = reader;
            //            GridView3.DataBind();
            //        }
            //        reader.Close();
            //        cmd.Dispose();
            //        conn.Close();
            //    }
            //    catch (SqlException ex)
            //    {
            //        GridView3.EmptyDataText = "<b>No records Found</b>";
            //        GridView3.DataSource = null;
            //        GridView3.DataBind();
            //        Response.Write("Failed: " + ex.Message);                    
            //    }
            //}
            #endregion

            #region Four-Tier
            if (!IsPostBack)
                RecordsGridView();
            else
                RecordsGridView();
            #endregion
        }
        public DataSet GetAllRecords()
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
                //throw new Exception("Upss! Error =( ", ex);
                ms.MsgBox(ex.ToString(), Page, this);
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
        public DataSet TodoslsRegistros()
        {            
            DataSet DS = new DataSet();
            try
            {
                DS = classConn.GetAllRecords("[SP_FetchRegisterUser]");
            }
            catch (Exception ex)
            {
                ms.MsgBox(ex.ToString(), Page, this);
            }
            finally
            {
                DS.Dispose();
            }
            return DS;
        }

        //private void BindGrid()
        //{
        //    GridViewfourTier.DataSource = TodoslsRegistros();
        //    GridViewfourTier.DataBind();
        //}
        
        //GridViewSearch
        private void SearchRecords()
        {
            User.Name = textSearch.Text.Trim();            
            DataTable dt = new DataTable();
            try
            {                
                dt = uBAL.SearchBAL(User);                
                if ( dt.Rows.Count > 0)
                {
                    GridViewSearch.DataSource = dt;
                    GridViewSearch.DataBind();
                }
                else
                {
                    GridViewSearch.EmptyDataText = "No records Found";
                    GridViewSearch.DataSource = null;
                    GridViewSearch.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex);
            }
            finally
            {
                User = null;
                uBAL = null;
            }        
        }            
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchRecords();
        }
        private void RecordsGridView()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = uBAL.ReadBAL();
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GridViewfourTier.DataSource = ds;
                    GridViewfourTier.DataBind();
                }
                else
                {
                    GridViewfourTier.EmptyDataText = "No records Found";
                    GridViewfourTier.DataSource = null;
                    GridViewfourTier.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            User.Name = textName.Text.Trim();
            User.LastName = textApellidos.Text.Trim();
            User.Email = textEmail.Text.Trim();
            User.Company = textCompany.Text.Trim();
            User.Date = textDate.Text.Trim();
            User.Status = "1";                        

            try
            {
                create = uBAL.CreateBAL(User);
                if (create > 0)
                {
                    panelMsg.Visible = true;
                    lblMsg.Text = "New record inserted successfully.";
                    //ms.MsgBox("New record inserted successfully.", Page, this);                    
                    //MessageBox.Show("New record inserted successfully.");
                }
                else
                    lblMsg.Text = "Cannot record inserted.";
            }
            catch (Exception ex)
            {
                Response.Write("Error: "+ ex);                
            }
            finally
            {
                User = null;
                uBAL = null;
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            User.ID_User = Convert.ToInt16(testUID.Text.Trim());
            User.Name = textUName.Text.Trim();
            User.LastName = textULastName.Text.Trim();
            User.Email = textUEmail.Text.Trim();
            User.Company = textUCompany.Text.Trim();
            User.Date = textUDate.Text.Trim();
            User.Status = "1";

            try
            {
                update = uBAL.UpdateBAL(User);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex);
            }
            finally
            {
                User = null;
                uBAL = null;
            }
        }  
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            User.ID_User = Convert.ToInt16(textID.Text.Trim());
            try
            {
                delete = uBAL.DeleteBAL(User);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex);
            }
            finally
            {
                User = null;
                uBAL = null;
            }
        }      
    }
}