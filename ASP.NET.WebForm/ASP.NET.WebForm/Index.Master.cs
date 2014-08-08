using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET.WebForm
{
    public partial class Index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void linkSendEmail_Click(object sender, EventArgs e)
        {
            Server.Transfer("/CodesCSharp/SendEmailPDF.aspx");
        }

        protected void linkConsumingWS_Click(object sender, EventArgs e)
        {
            Server.Transfer("/CodesWS/ConsumingWS.aspx");
        }
        protected void linkDB10_Click(object sender, EventArgs e)
        {
            Server.Transfer("/CodesVB/DB10Digit.aspx");
        }
        protected void linkUsers_Click(object sender, EventArgs e)
        {
            Server.Transfer("/CodeAdmin/Users.aspx");
        }
    }
}