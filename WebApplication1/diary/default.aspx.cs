using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.diary
{
    public partial class _default : System.Web.UI.Page
    {
        Global g = new Global();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["LOGIN_ID"] != null && Session["LOGIN_ID"].Equals("admin"))
            {
                Response.Redirect("diarylist.aspx?desc=0");
            }
        }

        protected void LoginClick(object sender, EventArgs e)
        {
            String id = Request.Form["id"];
            String password = Request.Form["password"];
            Boolean check = false;
            String viewName = null;
            try
            {
                MemberDAO memberdao = new MemberDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);

                SortedList<String, String> memberlist = memberdao.GetMemberListById(id);

                //List<MemberDTO> memberlist = memberdao.GetMemberList();
                if (memberlist != null)
                {
                    /*
                    foreach(MemberDTO memberdto in memberlist)
                    {
                        if (id.Equals("admin")){
                            if(BCrypt.Net.BCrypt.Verify(password, memberdto.Password))
                            {
                                 check = true;
                                 viewName = "diarylist.aspx?desc=0";
                                 break;
                            }
                        }
                    }
                    */
                    String password_db = memberlist["password"];
                    if(BCrypt.Net.BCrypt.Verify(password, password_db))
                    {
                        check = true;
                        viewName = "diarylist.aspx?desc=0";
                    }
                }
                else
                {
                    g.jsmessage(Response, "Null Error");
                }

                if (check)
                {
                    Session["LOGIN_ID"] = id;
                    Session["FIRST_NAME"] = memberlist["firstname"];
                    Session["LAST_NAME"] = memberlist["lastname"];
                    Response.Redirect(viewName);
                }
            }catch(Exception ex)
            {
                g.jsmessage(Response,ex.Message);
            }
        }
    }
}