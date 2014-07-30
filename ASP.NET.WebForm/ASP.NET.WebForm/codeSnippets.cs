using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET.WebForm
{
    public class codeSnippets
    {
        public void MsgBox(String msg, Page pg, Object obj)
        {
            //string s = "<SCRIPT language='javascript'>alert('" + msg.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            string s = "<script language='javascript'>alert('" + msg + "'); </script>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
        public void ClearTextBox(ControlCollection ctrls)
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
    }
}