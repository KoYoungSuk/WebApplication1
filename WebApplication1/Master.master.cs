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

    public partial class MyBlog : System.Web.UI.MasterPage
    {
        Global g = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_ID"] != null)
            {
                Session["FULL_NAME"] = (string)Session["FIRST_NAME"] + (string)Session["LAST_NAME"];
            }
        }
        protected void Signout_Click(object sender, EventArgs e)
        {
            if(Session["LOGIN_ID"] != null)
            {
                Session.Clear();
                Response.Redirect("default.aspx");
            }
            else
            {
                g.jsmessage(Response, "Please Login");
            }
        }
        protected void Login_Click(object sender, EventArgs e)
        {
            String id = Request.Form["login_id"];
            String pw = Request.Form["login_password"];
            try
            {
                MemberDAO memberdao = new MemberDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                List<MemberDTO> memberlist = memberdao.GetMemberList();
                Boolean logincheck = false;
                foreach(MemberDTO memberdto in memberlist)
                {
                    if (id.Equals(memberdto.Id))
                    {
                        if(BCrypt.Net.BCrypt.Verify(pw, memberdto.Password))
                        {
                            Session["LOGIN_ID"] = id;
                            Session["FIRST_NAME"] = memberdto.Firstname;
                            Session["LAST_NAME"] = memberdto.Lastname;
                            logincheck = true;
                            break;
                        }
                    }
                }
                if (logincheck)
                {
                    Response.Redirect("default.aspx");
                }
                else
                {
                    g.jsmessage(Response, "Id or Password is not confirmed.");
                }
            }
            catch (Exception ex)
            {
                g.jsmessage(Response, ex.Message);
            }
        }

    }
}