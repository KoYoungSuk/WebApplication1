using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class membermanage : System.Web.UI.Page
    {
        OracleConnection conn = null;
        static Global g = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["LOGIN_ID"] != null && Session["LOGIN_ID"].Equals("admin"))
            {
                try
                {
                    String connstr = g.connectionString(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                    conn = new OracleConnection(connstr);
                    conn.Open();
                    DAO dao = new DAO(conn);
                    DataTable dt = dao.GetTotalList("select * from member", null, false);
                    foreach(DataRow dr in dt.Rows)
                    {
                        dr["password"] = "PASSWORD CENSORED";
                    }
                    TotalMemberGridView.DataSource = dt;
                    TotalMemberGridView.DataBind();
                    conn.Close();
                }
                catch(Exception ex)
                {
                    g.jsmessage(Response, ex.Message);
                }
            }
            else
            {
                g.jsmessage(Response, "Administrator Only.");
            }
        }

        public void DeleteMember_Click(object sender, EventArgs e)
        {
            if(Session["LOGIN_ID"] != null && Session["LOGIN_ID"].Equals("admin"))
            {
                try
                {
                    String delete_id = Request.Form["delete_id"];
                    MemberDAO memberdao = new MemberDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                    int RowDeleted = memberdao.DeleteMember(delete_id);
                    if(RowDeleted == 0)
                    {
                        g.jsmessage(Response, "Unknown Error Message");
                    }
                    else
                    {
                        Response.Redirect("membermanage.aspx");
                    }
                }
                catch(Exception ex)
                {
                    g.jsmessage(Response, ex.Message);
                }
            }
        }
    }
}