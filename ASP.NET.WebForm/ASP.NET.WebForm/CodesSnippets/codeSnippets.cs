using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET.WebForm
{
    public class codeSnippets
    {
        public static void MsgBox(String msg, Page pg, Object obj)
        {
            //string s = "<SCRIPT language='javascript'>alert('" + msg.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            string s = "<script language='javascript'>alert('" + msg + "'); </script>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
            //other form
            //Response.Write("Failed: "+ex);
            //Response.Write(@"<script language='javascript'>alert('Update is successful.')</script>");
        }
        public static void ClearTextBox(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = string.Empty;
                }
                else if (ctrl is RadioButtonList)
                {
                    ((RadioButtonList)ctrl).ClearSelection();
                }
                ClearTextBox(ctrl.Controls);
            }
        }
        public static Boolean esNumero(string cadena)
        {            
            Regex regex = new Regex(@"^[0-9]+$");
            return regex.IsMatch(cadena);
        }
        private static bool esDecimal(string cadena)
        {
            Regex regex = new Regex(@"^[0-9]{1,9}([\.\,][0-9]{1,3})?$");
            return regex.IsMatch(cadena);
        }
        public static Boolean esLetra(string cadena)
        {
            Regex regex = new Regex(@"^[A-Za-z]+$");
            return regex.IsMatch(cadena);
        }
        public static Boolean esAlfanumerico(string cadena)
        {
            Regex expresion = new Regex(@"^\w+$");
            return expresion.IsMatch(cadena);
        }
        public static Boolean esCorreo(string cadena)
        {            
            Regex regex = new Regex(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$");            
            return regex.IsMatch(cadena);
            // Resultado: 
            //       Valid: david.jones@proseware.com 
            //       Valid: d.j@server1.proseware.com 
            //       Valid: jones@ms1.proseware.com 
            //       Invalid: j.@server1.proseware.com 
            //       Invalid: j@proseware.com9 
            //       Valid: js#internal@proseware.com 
            //       Valid: j_9@[129.126.118.1] 
            //       Invalid: j..s@proseware.com 
            //       Invalid: js*@proseware.com 
            //       Invalid: js@proseware..com 
            //       Invalid: js@proseware.com9 
            //       Valid: j.s@server1.proseware.com
        }
        private static bool esUrl(string cadena)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9\-\.]+\.(com|org|net|mil|edu|COM|ORG|NET|MIL|EDU)$");
            return regex.IsMatch(cadena);
        }   
        public static string onlyletras(string cadena)
        {
            Regex expresion = new Regex("^[A-Za-z]+$");
            expresion.IsMatch(cadena);

            if (expresion.IsMatch(cadena) == true)
            {
                return cadena;
            }
            else
            {
                return "solo se aceptan letras";
            }                       
        }
    }
}