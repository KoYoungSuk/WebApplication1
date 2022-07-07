using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class signup : System.Web.UI.Page
    {
        Global g = new Global();
        protected void Signup_Click(object sender, EventArgs e)
        {
            try
            {
                String id = Request.Form["id_signup"];
                String password = Request.Form["password_signup"];
                String cpassword = Request.Form["cpassword_signup"];
                String firstname = Request.Form["firstname_signup"];
                String lastname = Request.Form["lastname_signup"];
                String birthday = Request.Form["birthday_signup"];
                if (password.Equals(cpassword))
                {
                    MemberDAO memberdao = new MemberDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                    MemberDTO memberdto = new MemberDTO(id, BCrypt.Net.BCrypt.HashPassword(password), firstname, lastname, birthday, DateTime.Now.ToString());
                    int rowInserted = memberdao.insertMember(memberdto);
                    if (rowInserted == 0)
                    {
                        g.jsmessage(Response, "Unknown Error Message");
                    }
                    else
                    {
                        Response.Redirect("default.aspx");
                    }
                }
                else
                {
                    g.jsmessage(Response, "Password and Confirmed Password are not same.");
                }
            }
            catch (Exception ex)
            {
                g.jsmessage(Response, ex.Message);
            }
        }
        protected void Page_Load(object sender, EventArgs e) { }
    }
}