using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class modifymemberinfo : System.Web.UI.Page
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
                    Session["BIRTHDAY"] = memberlist["birthday"];
                }
                catch (Exception ex)
                {
                    g.jsmessage(Response, ex.Message);
                }
            }
            else
            {
                g.jsmessage(Response, "Please Login.");
            }
        }
        public void Modify_Click(object sender, EventArgs e)
        {
            String id = Request.Form["id"];
            String password = Request.Form["password"];
            String cpassword = Request.Form["cpassword"];
            String firstname = Request.Form["firstname"];
            String lastname = Request.Form["lastname"];
            String birthday = Request.Form["birthday"];
            if (password.Equals(cpassword))
            {
                try
                {
                    MemberDAO memberdao = new MemberDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                    MemberDTO memberdto = new MemberDTO(id, BCrypt.Net.BCrypt.HashPassword(password), firstname, lastname, birthday, null);
                    int RowUpdated = memberdao.UpdateMember(memberdto);
                    if (RowUpdated == 0)
                    {
                        g.jsmessage(Response, "Unknown Error Message");
                    }
                    else
                    {
                        Session.Clear();
                        Response.Redirect("default.aspx");
                    }

                }
                catch (Exception ex)
                {
                    g.jsmessage(Response, ex.Message);
                }
            }
            else
            {
                g.jsmessage(Response, "Password and Confirmed Password are not same.");
            }
        }
    }
}