﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinesObject;
using DataAccessLayer;
using BusinessAccessLayer;
using System.Data;
using Newtonsoft.Json;

namespace ASP.NET.WebForm.CodeAdmin
{
    public partial class UserAjax : System.Web.UI.Page
    {
        BO_User User = new BO_User();
        BAL_User uBAL = new BAL_User();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            FillGridWithFourTier();
            divMsg.Visible = false;
            //BindColumnToGridview();
        }        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            User.Name = textSearch.Text.Trim();
            
            WSBeginners ws = new WSBeginners();
            string str_Json = ws.ShowAllRecords(User.Name);
            

            //dt.Columns.AddRange(new DataColumn[] { new DataColumn("Name"), new DataColumn("Age") });

            //GridviewJson.DataSource = DeserializarJson(str_Json);
            //GridviewJson.DataBind();

            //try
            //{
            //    dt = uBAL.SearchBAL(User);
            //    if (dt.Rows.Count > 0)
            //    {
            //        GridviewSearch.DataSource = dt;
            //        GridviewSearch.DataBind();
            //    }
            //    else
            //    {
            //        GridviewSearch.EmptyDataText = "<b>No existen registros!</b>";
            //        GridviewSearch.DataSource = null;
            //        GridviewSearch.DataBind();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("Error: " + ex);
            //}
            //finally
            //{
            //    User = null;
            //    uBAL = null;
            //    codeSnippets.ClearTextBox(Page.Controls);
            //}        
        }
        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            int create = 0;
            User.Name = textName.Text.Trim();
            User.LastName = textLastName.Text.Trim();
            User.Email = textEmail.Text.Trim();
            User.Company = textCompany.Text.Trim();
            User.Date = textDate.Text.Trim();            
            User.Status = ddlStatus.Text;
            //User.Status = textStatus.Text.Trim();
            try
            {
                create = uBAL.CreateBAL(User);
                if (create > 0)
                {                    
                    codeSnippets.ClearTextBox(Page.Controls);
                    //Response.Write(@"<script language='javascript'>alert('New record inserted successfully')</script>");
                    divMsg.Visible = true;
                    lblMsg.Text = "<b>Usuario ingresado correctamente!!</b>";
                }
                else
                    Response.Write(@"<script language='javascript'>alert('Cannot record inserted.')</script>");                                    
            }
            catch (Exception ex)
            {
                Response.Write("Upss!!! " + ex);
            }
            finally
            {
                User = null;
                uBAL = null;
            }
        }




        private void FillGridWithFourTier()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = uBAL.ReadBAL();
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GridViewFourTier.DataSource = ds;
                    GridViewFourTier.DataBind();
                }
                else
                {
                    GridViewFourTier.EmptyDataText = "<b>No records Found</b>";
                    GridViewFourTier.DataSource = null;
                    GridViewFourTier.DataBind();
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
        public DataTable DeserializarJson(string json)
        { 
            DataTable dt = new DataTable();
            dt = JsonConvert.DeserializeObject<DataTable>(json);
            return dt;
        }

        //private void BindColumnToGridview()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("ID");
        //    dt.Columns.Add("Nombre");
        //    dt.Columns.Add("Apellido");
        //    dt.Columns.Add("Correo");
        //    dt.Columns.Add("Compañia");
        //    dt.Columns.Add("Fecha");
        //    dt.Columns.Add("Estatus");
        //    dt.Rows.Add();
        //    GridviewJson.DataSource = dt;
        //    GridviewJson.DataBind();
        //    GridviewJson.Rows[0].Visible = false;
        //}
    }
}