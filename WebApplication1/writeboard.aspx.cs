using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class writeboard : System.Web.UI.Page
    {
        Global g = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Session["LOGIN_ID"].Equals("admin"))
            {
                g.jsmessage(Response, "Administrator Only.");
            }
        }
        public void Post_Board_Click(object sender, EventArgs e)
        {
            String title = Request.Form["title"];
            String content = Request.Form["content"];
            String id = Request.Form["id"];
            String access = Request.Form["access"];
            String viewName = null;
            try
            {
                BoardDAO boarddao = new BoardDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                int serial = boarddao.getMaxBoardNumber() + 1;
                //count는 0, 수정 날짜는 일단 null로 줌.(오라클 데이터베이스 트리거 설정으로 물론 들어갈꺼임) 
                BoardDTO boarddto = new BoardDTO(serial, title, content, DateTime.Now.ToString(), null, id, access, 0);
                int RowsInserted = boarddao.insertBoard(boarddto);    
                if(RowsInserted == 0)
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