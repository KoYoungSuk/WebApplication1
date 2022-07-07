using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.dbmanager
{
    public partial class _default : System.Web.UI.Page
    {
        OracleConnection conn = null;
        Global g = new Global();
        protected void Page_Load(object sender, EventArgs e){ }
        public void DBLogin_Click(object sender, EventArgs e)
        {
            String url = Request.Form["dburl"];
            String id = Request.Form["dbid"];
            String pw = Request.Form["dbpw"];
            String mode = Request.Form["mode"];
            String[] temparrurl = url.Split('/');
            String sid = temparrurl[1];
            String[] temparrurl2 = temparrurl[0].Split(':');
            String port = temparrurl2[1];
            String viewName = null;
            try
            {
                String connstr = g.connectionString(temparrurl2[0], port, sid, id, pw);
                conn = new OracleConnection(connstr);
                conn.Open();
                Session["DB_TIME"] = DateTime.Now.ToString();
                Session["DB_ID"] = id;
                Session["DB_CONNECTION"] = conn; 
                Session["DB_URL"] = url;
                if (mode.Equals("professional")){
                    viewName = "professional.aspx";
                }
                else
                {
                    viewName = "easy.aspx";
                }
                Response.Redirect(viewName);
            }catch(Exception ex)
            {
                g.jsmessage(Response, ex.Message);
            }
        }
    }

}
