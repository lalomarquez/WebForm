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
using System.Configuration;
using Newtonsoft.Json;
using System.Web.Script.Services;
using System.Text;

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
        BO.BO_User User = new BO.BO_User();

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

        [WebMethod(Description = "Insert Data to DB")]
        public string SaveData(string Name, string LastName, string Email, string Company, string Date, string Status)
        {
            string status = string.Empty;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
            SqlCommand cmd;
            
            if (codeSnippets.esNombre(Name.Trim()) == true)
            {
                if (codeSnippets.esNombre(LastName.Trim()) == true)
                {
                    if (codeSnippets.esCorreo(Email.Trim()) == true)
                    {
                        if (codeSnippets.esAlfanumerico(Company.Trim()) == true)
                        {
                            if (codeSnippets.esFecha(Date.Trim()) == true)
                            {
                                if (codeSnippets.esUnNumero(Status.Trim()) == true)
                                {
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
                                else {
                                    System.Windows.Forms.MessageBox.Show("Plis, ingresa un Estatus valido");
                                    return status = "failed";
                                }
                            }
                            else {
                                System.Windows.Forms.MessageBox.Show("Plis, ingresa una Fecha valida(dd/mm/yyyy,dd-mm-yyyy o dd.mm.yyyy)");
                                return status = "failed";
                            }
                        }
                        else{
                            System.Windows.Forms.MessageBox.Show("Plis, ingresa una Empresa valida");
                            return status = "failed";
                        }
                    }
                    else {
                        System.Windows.Forms.MessageBox.Show("Plis, ingresa un Correo valido");
                        return status = "failed";
                    }
                }
                else {
                    System.Windows.Forms.MessageBox.Show("Plis, ingresa un Apellido valido");
                    return status = "failed";
                }
            }
            else{
                System.Windows.Forms.MessageBox.Show("Plis, ingresa un Nombre valido");
                return status = "failed";
            }
                
        }

        [WebMethod]
        public string ShowAllRecords(string Nombre)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataTable dt = new DataTable();
            string json = string.Empty;

            try
            {
                cmd = new SqlCommand("[SP_SearchRegisterUser]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = Nombre;
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                //foreach (DataRow row in dt.Rows)
                //{                    
                //    BO.BO_User User = new BO.BO_User();
                //    User.Name = row["Name"].ToString();
                //    User.LastName = row["LastName"].ToString();   
                //}

                cmd.Dispose();
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                return json = JsonConvert.SerializeObject(dt, Formatting.Indented);
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
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public static List<BO.BO_User> GetCompanies()
        //{
        //    System.Threading.Thread.Sleep(5000);
        //    List<BO.BO_User> allCompany = new List<BO.BO_User>();


        //    using (MyDatabaseEntities dc = new MyDatabaseEntities())
        //    {
        //        allCompany = dc.TopCompanies.ToList();
        //    }
        //    return allCompany;
        //}


    }
}
