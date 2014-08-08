using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VBDigitVer.DigitVer;
using System.Windows.Forms;

namespace ASP.NET.WebForm.VB
{
    public partial class DB10Digit : System.Web.UI.Page
    {
        classDigitVer DV = new classDigitVer();
        protected void Page_Load(object sender, EventArgs e)
        {
            DivDB10.Visible = false;
        }

        protected void btnDB10_Click(object sender, EventArgs e)
        {            
            lblDB10.Text = Convert.ToString(DV.GetDB10Digit(textDB.Text.Trim()));
            if (lblDB10.Text != "")
            {
                DivDB10.Visible = true;
            }                
        }
    }
}