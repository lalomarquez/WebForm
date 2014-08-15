using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using BO = BussinesObject;
using DAL = DataAccessLayer;
using BAL = BusinessAccessLayer;

namespace ASP.NET.WebForm
{
    /// <summary>
    /// Summary description for WSBeginners
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WSBeginners : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        
        [WebMethod]
        public string Food(string items)
        {
            return "I like to eat: " + items;
        }

        [WebMethod]
        public double Suma(double n1, double n2)
        {
            return n1 + n2;
        }
        [WebMethod]
        public BO.BO_User Usuarios(int ID)
        {
            //SqlConnection conn = DAL.classConn.ReturnConn();
            SqlCommand cmd;
            SqlDataReader reader;
            using (SqlConnection conn = DAL.classConn.ReturnConn())
            {
                try
                {
                    cmd = new SqlCommand("[SP_GetUsersByID]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = ID;
                    BO.BO_User Usuarios = new BO.BO_User();
                    
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //Usuarios.ID_User = Convert.ToInt32(reader["ID_User"]);
                        Usuarios.Name = reader["Name"].ToString();
                        Usuarios.LastName = reader["LastName"].ToString();
                        Usuarios.Email = reader["Email"].ToString();
                        Usuarios.Company = reader["Company"].ToString();
                        Usuarios.Date = reader["Date"].ToString();
                        Usuarios.Status = reader["Status"].ToString();
                    }
                    return Usuarios;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }            
        }
        [WebMethod]
        public string GetCurrentTime(string name)
        {
            return "Hello " + name + Environment.NewLine + "The Current Time is: "
                + DateTime.Now.ToString();
        }
    }
}
