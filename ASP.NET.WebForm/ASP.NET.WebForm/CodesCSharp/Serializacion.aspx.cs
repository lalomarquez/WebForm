using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinesObject;
using DAL = DataAccessLayer;
using BAL = BusinessAccessLayer;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;

namespace ASP.NET.WebForm.CodesCSharp
{
    public partial class Serializacion : System.Web.UI.Page
    {
        BO_User User = new BO_User();        
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSerializacion_Click(object sender, EventArgs e)
        {                                        
            User.Name = textName.Text.Trim();
            User.LastName = textLastName.Text.Trim();
            User.Email = textEmail.Text.Trim();
            User.Company = textCompany.Text.Trim();
            User.Date = textDate.Text.Trim();
            User.Status = ddlStatus.Text;
            User.ToString();

            //Binary
            FileStream fsbinary = new FileStream(Server.MapPath("/Files/binary.txt"), FileMode.Create);
            BinaryFormatter formaterbinarty = new BinaryFormatter();
            formaterbinarty.Serialize(fsbinary, User);
            fsbinary.Close();

            //SOAP
            FileStream fssoap = new FileStream(Server.MapPath("/Files/soap.txt"), FileMode.Create);
            SoapFormatter soap = new SoapFormatter();
            soap.Serialize(fssoap, User);
            fssoap.Close();

            //XML            
            FileStream fsxml = new FileStream(Server.MapPath("/Files/fsXML.xml"), FileMode.Create);
            XmlSerializer xml = new XmlSerializer(User.GetType());
            xml.Serialize(fsxml, User);
            fsxml.Close();

            StreamWriter sw = new StreamWriter(Server.MapPath("/Files/swXML.xml"));
            XmlSerializer serializer = new XmlSerializer(typeof(BO_User));
            serializer.Serialize(sw, User);
            sw.Close();

            //JSON
            FileStream file = new FileStream(Server.MapPath("/Files/json1.json"), FileMode.Create);
            DataContractJsonSerializer serializerjson = new DataContractJsonSerializer(typeof(BO_User));
            serializerjson.WriteObject(file, User);
            file.Close();
            
            //JSON.NET
            //string json = JsonConvert.SerializeObject(User, Formatting.Indented);
            //StreamWriter writer = new StreamWriter(Server.MapPath("/Files/json.txt"), true);
            //writer.WriteLine(json);
            //writer.Close();            
        }

        protected void btnDeserializacion_Click(object sender, EventArgs e)
        {
            //Des Binary
            FileStream fs = new FileStream(Server.MapPath("/Files/binary.txt"), FileMode.Open);
            BinaryFormatter formater = new BinaryFormatter();
            BO_User user = (BO_User)formater.Deserialize(fs);
            fs.Close();

            string result = string.Format("Deserializados Binaria:<br>{0}<br>{1}<br>{2}<br>{3}<br>{4}<br>{5}<br>", user.Name, user.LastName, user.Email, user.Company, user.Date, user.Status);
            lblDesBinary.Text = result;

            //Des SOAP
            FileStream fssoap = new FileStream(Server.MapPath("/Files/soap.txt"), FileMode.Open);
            SoapFormatter formatter = new SoapFormatter();
            BO_User uSoap = (BO_User)formatter.Deserialize(fssoap);
            fssoap.Close();

            string rSoap = string.Format("Deserializados Soap:<br>{0}<br>{1}<br>{2}<br>{3}<br>{4}<br>{5}<br>", uSoap.Name, uSoap.LastName, uSoap.Email, uSoap.Company, uSoap.Date, uSoap.Status);
            lblDesSoap.Text = rSoap;

            //Des XML
            FileStream fsxml = new FileStream(Server.MapPath("/Files/fsXML.xml"), FileMode.Open);
            XmlSerializer desxml = new XmlSerializer(typeof(BO_User));
            BO_User uXML = (BO_User)desxml.Deserialize(fsxml);
            fsxml.Close();

            string rXML = string.Format("Deserializados XML:<br>{0}<br>{1}<br>{2}<br>{3}<br>{4}<br>{5}<br>", uXML.Name, uXML.LastName, uXML.Email, uXML.Company, uXML.Date, uXML.Status);
            lblDesXML.Text = rXML;

            //Des JSON
            FileStream fsjson = new FileStream(Server.MapPath("/Files/json1.json"), FileMode.Open);
            DataContractJsonSerializer desjson = new DataContractJsonSerializer(typeof(BO_User));
            BO_User uJson = (BO_User)desjson.ReadObject(fsjson);
            fsjson.Close();

            string rJSON = string.Format("Deserializados JSON:<br>{0}<br>{1}<br>{2}<br>{3}<br>{4}<br>{5}<br>", uJson.Name, uJson.LastName, uJson.Email, uJson.Company, uJson.Date, uJson.Status);
            lblDesJSON.Text = rJSON;

            //Des JSON.NET
            FileStream fsOpen = new FileStream(Server.MapPath("/Files/json.txt"), FileMode.Open);            
            string str_json = @"{
                                  'id_user': 0,
                                  'name': 'eduardo',
                                  'lastname': 'marquez',
                                  'email': 'espinza@gmail.com',
                                  'company': 'diestel',
                                  'date': '31.08.2014',
                                  'status': '1'
                                }
                                ";

            BO_User objJson = JsonConvert.DeserializeObject<BO_User>(str_json);                        
            string jsonNet = string.Format("Deserializados JSON:<br>{0}<br>{1}<br>{2}<br>{3}<br>{4}<br>{5}<br>", objJson.Name, objJson.LastName, objJson.Email, objJson.Company, objJson.Date, objJson.Status);
            lblDesJsoNet.Text = jsonNet;            
        }

    }
}