using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.product
{
    public partial class _default : System.Web.UI.Page
    {
        Global g = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_ID"] != null && Session["LOGIN_ID"].Equals("admin"))
            {
                Response.Redirect("productlist.aspx?desc=0&columnname=product_no");
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            String id = Request.Form["id"];
            String password = Request.Form["password"];
            Boolean check = false;
            String viewName = null;
            try
            {
                MemberDAO memberdao = new MemberDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                //List<MemberDTO> memberlist = memberdao.GetMemberList();
                SortedList<String, String> memberlist = memberdao.GetMemberListById(id);
                if(memberlist != null)
                {
                    /*
                    foreach (MemberDTO memberdto in memberlist)
                    {
                        if (id.Equals("admin"))
                        {
                            if (BCrypt.Net.BCrypt.Verify(password, memberdto.Password))
                            {
                                check = true;
                                viewName = "productlist.aspx?desc=0&columnname=product_no";
                                break;
                            }
                        }
                        else
                        {
                            check = false;
                        }
                    }
                    */
                    String password_db = memberlist["password"];
                    if(BCrypt.Net.BCrypt.Verify(password, password_db))
                    {
                        check = true;
                        viewName = "productlist.aspx?desc=0&columnname=product_no";
                    }
                }
                else
                {
                    g.jsmessage(Response, "Null Error");
                }
                if (check)
                {
                    Session["LOGIN_ID"] = id;
                    Response.Redirect(viewName);
                }
                else
                {
                    g.jsmessage(Response, "ID and Password are not corrected and This is Administrator Only.");
                }
            }catch(Exception ex)
            {
                g.jsmessage(Response, ex.Message);
            }
        }
    }
}