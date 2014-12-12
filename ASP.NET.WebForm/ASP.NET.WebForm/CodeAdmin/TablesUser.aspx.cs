using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using DataAccessLayer;
using BusinessAccessLayer;

namespace ASP.NET.WebForm.CodeAdmin
{
    public partial class TablesUser : System.Web.UI.Page
    {
        BAL_User uBAL = new BAL_User();
        SqlDataReader reader;
        SqlCommand cmd;
        SqlDataAdapter adp;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
        string query = "select * from dbo.SCRUD_RegisterUser";
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {            
            #region Fill griview whit Query                                
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand(query, conn);
                    reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        GridViewQuery.DataSource = reader;
                        GridViewQuery.DataBind();
                    }
                    else
                    {
                        GridViewQuery.EmptyDataText = "<b>No records Found</b>";
                        GridViewQuery.DataSource = null;
                        GridViewQuery.DataBind();                        
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Failed: " + ex);
                }
                finally
                {
                    //reader.Close();
                    conn.Close();
                    cmd.Dispose();
                }
            }
            #endregion

            #region Fill gridview with SP                        
            try
            {
                ds = FillGridWithSP();
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GridViewSP.DataSource = ds;
                    GridViewSP.DataBind();
                }
                else
                {
                    GridViewSP.EmptyDataText = "<b>No records Found</b>";
                    GridViewSP.DataSource = null;
                    GridViewSP.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Failed: " + ex);
            }
            finally
            {
                ds.Dispose();
            }
            #endregion

            #region Fill gridview whit Method & SP            
            try
            {
                ds = FillGridWithMethodAndSP();
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GridViewMethodSP.DataSource = ds;
                    GridViewMethodSP.DataBind();
                }
                else
                {
                    GridViewMethodSP.EmptyDataText = "<b>No records Found</b>";
                    GridViewMethodSP.DataSource = null;
                    GridViewMethodSP.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Failed: " + ex);
            }
            finally
            {
                ds.Dispose();
            }
            #endregion                

            #region Four-Tier           
                FillGridWithFourTier();
            #endregion                    
        }
        public DataSet FillGridWithSP()
        {
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("[SP_FetchRegisterUser]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);                
            }
            catch (Exception ex)
            {
                throw new Exception("Upss! Error =( ", ex);
            }
            finally
            {
                ds.Dispose();
                cmd.Dispose();
                conn.Close();
            }
            return ds;
        }
        public DataSet FillGridWithMethodAndSP()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = classConn.GetAllRecords("[SP_FetchRegisterUser]");
            }
            catch (Exception ex)
            {
                Response.Write("Failed: " + ex);
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
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
    }
}