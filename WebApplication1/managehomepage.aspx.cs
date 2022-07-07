using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class managehomepage : System.Web.UI.Page
    {
        Global g = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_ID"].Equals("admin"))
            {
                LabelSessionID.Text = (string)Session["LOGIN_ID"];
            }
            else
            {
                g.jsmessage(Response, "Administrator Only");
            }
        }
    }
}