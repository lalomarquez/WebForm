using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET.WebForm
{
    public partial class ConsumingWS : System.Web.UI.Page
    {
        WS.WSBeginnersSoapClient client = new WS.WSBeginnersSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConsumirWS_Click(object sender, EventArgs e)
        {
            lblHello.Text = client.HelloWorld();
            lblFood.Text = client.Food("PAVO");
            lblSum.Text = client.Suma(100, 999.69).ToString();            
        }
    }
}