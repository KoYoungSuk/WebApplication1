using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class modifyboard : System.Web.UI.Page
    {
        Global g = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["LOGIN_ID"] != null && Session["LOGIN_ID"].Equals("admin"))
            {
                int serial = Int32.Parse(Request.QueryString["serial"]);
                BoardDAO boarddao = new BoardDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                SortedList<String, String> boardlist = boarddao.getBoardListBySerial(serial, false);
                if (boardlist != null)
                {
                    Session["serial"] = boardlist["serial"];
                    Session["userid"] = boardlist["userid"];
                    Session["title"] = boardlist["title"];
                    Session["content"] = boardlist["content"];
                }
                else
                {
                    g.jsmessage(Response, "Null Error");
                }
            }
            else
            {
                g.jsmessage(Response, "Administrator Only.");
            }
        }

        protected void Modify_Click(object sender, EventArgs e)
        {
            String serial = Request.Form["serial"];
            String title = Request.Form["title"];
            String userid = Request.Form["userid"];
            String content = Request.Form["content"];
            String access = Request.Form["access"];
            String viewName = null;
            try
            {
                BoardDAO boarddao = new BoardDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                BoardDTO boarddto = new BoardDTO(Int32.Parse(serial), title, content, null, DateTime.Now.ToString(), userid, access, 0);
                int RowsUpdated = boarddao.UpdateBoard(boarddto, false);
                if(RowsUpdated == 0)
                {
                    g.jsmessage(Response, "Unknown Error Message"); 
                }
                else
                {
                    viewName = "totalboardlist.aspx";
                }
            }catch(Exception ex)
            {
                g.jsmessage(Response, ex.Message);
            }
            if(viewName != null)
            {
                Response.Redirect(viewName);
            }
        }
    }
}