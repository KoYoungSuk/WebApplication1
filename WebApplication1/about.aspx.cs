using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class about : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global g = new Global();
            if (Session["LOGIN_ID"] != null)
            {
                OSID.Text = g.checkOSVer();
            }
        }
    }
}