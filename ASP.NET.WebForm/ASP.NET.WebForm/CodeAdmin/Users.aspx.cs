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
using BussinesObject;
using DAL = DataAccessLayer;
using BAL = BusinessAccessLayer;


namespace ASP.NET.WebForm.CodeAdmin
{
    public partial class Users : System.Web.UI.Page
    {
        BAL.BAL_User uBAL = new BAL.BAL_User();
        BO_User User = new BO_User();        
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);        
        string query = string.Empty;
        codeSnippets ms = new codeSnippets();
        int search = 0;
        int create = 0;
        int update = 0;
        int delete = 0;
        codeSnippets clear = new codeSnippets();
        protected void Page_Load(object sender, EventArgs e)
        {
            panelMsg.Visible = false;
            //divUpdate.Visible = false;

            #region Four-Tier
            if (!IsPostBack)
                RecordsGridView();
            //else
            //    RecordsGridView();
            #endregion
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
                throw ex;                
            }
            finally
            {
                DS.Dispose();
            }
            return DS;
        }
        private void SearchRecords()
        {
            DataTable dt = new DataTable();

            if (codeSnippets.esLetra(textSearch.Text.Trim()) == true)
            {
                User.Name = textSearch.Text.Trim();
                try
                {
                    dt = uBAL.SearchBAL(User);
                    if (dt.Rows.Count > 0)
                    {
                        GridViewSearch.DataSource = dt;
                        GridViewSearch.DataBind();
                    }
                    else
                    {
                        GridViewSearch.EmptyDataText = "<b>No existen registros!</b>";
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
                    codeSnippets.ClearTextBox(Page.Controls);
                }        
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('El campo solo acepta caracteres alfabeticos')</script>");
                codeSnippets.ClearTextBox(Page.Controls);                
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
            if (codeSnippets.esAlfanumerico(textName.Text.Trim()) == true)
            {
                User.Name = textName.Text.Trim();
                if (codeSnippets.esAlfanumerico(textApellidos.Text.Trim()) == true)
                {
                    User.LastName = textApellidos.Text.Trim();
                    if (codeSnippets.esCorreo(textEmail.Text.Trim()) == true)
                    {
                        User.Email = textEmail.Text.Trim();
                        if (codeSnippets.esAlfanumerico(textCompany.Text.Trim()) == true)
                        {
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
                                    codeSnippets.ClearTextBox(Page.Controls);                
                                }
                                else
                                    lblMsg.Text = "Cannot record inserted.";
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
                        else
                        {
                            Response.Write(@"<script language='javascript'>alert('Ingresa el nombre de la Compañia')</script>");                            
                        }
                    }
                    else
                    {
                        Response.Write(@"<script language='javascript'>alert('Ingresa el Correo')</script>");
                        //codeSnippets.ClearTextBox(Page.Controls);                
                    }
                }
                else 
                {
                    Response.Write(@"<script language='javascript'>alert('Ingresa los Apellidos')</script>");
                    //codeSnippets.ClearTextBox(Page.Controls);                
                }
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('Ingresa tu Nombre')</script>");
                //codeSnippets.ClearTextBox(Page.Controls);                
            }                     
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DataSet ds = TodoslsRegistros();
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{


            //    textUName.Text = dr["Name"].ToString();
            //    textULastName.Text = dr["LastName"].ToString();
            //    textUEmail.Text = dr["Email"].ToString();
            //    textUCompany.Text = dr["Company"].ToString();
            //    textUDate.Text = dr["Date"].ToString();
            //}            
            
            User.ID_User = Convert.ToInt16(testUID.Text.Trim());
            User.Name = textUName.Text.Trim();
            User.LastName = textULastName.Text.Trim();
            User.Email = textUEmail.Text.Trim();
            User.Company = textUCompany.Text.Trim();
            User.Date = textUDate.Text.Trim();
            User.Status = "1";
            
            if (testUID.Text.Trim() != "")
            {
                //divUpdate.Visible = true;
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
            //clear.ClearTextBox(Page.Controls);
        }  
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //Validations from Code Behind 
            if (codeSnippets.esNumero(textID.Text.Trim()) == true)
            {                
            User.ID_User = Convert.ToInt16(textID.Text.Trim());
            try
            {                                               
                DialogResult dr = MessageBox.Show("Are you sure you want to delete?", "Delete!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    delete = uBAL.DeleteBAL(User);
                    if (delete > 0)                    
                        codeSnippets.ClearTextBox(Page.Controls);                    
                    else                    
                        //Response.Write(@"<script language='javascript'>alert('Ingresa el ID correcto')</script>");                        
                        MessageBox.Show("Ese ID no existe, ingresa el ID correcto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);                    
                }
                else                
                    codeSnippets.ClearTextBox(Page.Controls);                
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
            else            
                //Response.Write(@"<script language='javascript'>alert('El campo solo acepta Numeros')</script>");
                MessageBox.Show("Ingresa solo datos Numericos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
            
            //Ajax            
        }                
    }
}