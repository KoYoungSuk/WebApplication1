using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class deletememberinfo : System.Web.UI.Page
    {
        Global g = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_ID"] != null)
            {
                try
                {
                    String id = (String)Session["LOGIN_ID"];
                    MemberDAO memberdao = new MemberDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                    SortedList<String, String> memberlist = memberdao.GetMemberListById(id);
                    Session["FULL_NAME"] = (String)Session["FIRST_NAME"] + Session["LAST_NAME"];
                    BirthdayLabelID_Delete.Text = memberlist["birthday"];
                    JoinDateLabelID_Delete.Text = memberlist["joindate"];
                }
                catch (Exception ex)
                {
                    g.jsmessage(Response, ex.Message);
                }
            }
            else
            {
                g.jsmessage(Response, "Please Login");
            }
        }

        public void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                String id = (string)Session["LOGIN_ID"];
                MemberDAO memberdao = new MemberDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                int RowDeleted = memberdao.DeleteMember(id);
                if (RowDeleted == 0)
                {
                    g.jsmessage(Response, "Unknown Error Message");
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("default.aspx");
                }
            }catch(Exception ex)
            {
                g.jsmessage(Response, ex.Message);
            }
        }
    }
}