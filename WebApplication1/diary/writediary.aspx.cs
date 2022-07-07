using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.diary
{
    public partial class writediary : System.Web.UI.Page
    {
        Global g = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session["LOGIN_ID"].Equals("admin"))
            {
                g.jsmessage(Response, "Administrator Only.");
            }
        }
        protected void WriteClick(object sender, EventArgs e)
        {
            String title = Request.Form["title"];
            String context = Request.Form["context"];
            try
            {
                DiaryDTO diarydto = new DiaryDTO(title, context, DateTime.Now.ToString(), null);
                DiaryDAO diarydao = new DiaryDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                int rowInserted = diarydao.insertDiary(diarydto);
                if(rowInserted == 0)
                {
                    g.jsmessage(Response, "Unknown Error Message");
                }
                else
                {
                    Response.Redirect("diarylist.aspx?desc=0");
                }
            }catch(Exception ex)
            {
                g.jsmessage(Response, ex.Message);
            }
        }
    }
}