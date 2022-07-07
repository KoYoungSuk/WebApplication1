using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.diary
{
    public partial class Diary : System.Web.UI.MasterPage
    {
        protected void Logout(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("default.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}