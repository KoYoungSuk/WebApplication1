using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.diary
{
    public partial class modifydiary : System.Web.UI.Page
    {
        Global g = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["LOGIN_ID"] != null && Session["LOGIN_ID"].Equals("admin"))
            {
                String title = Request.QueryString["title"];
                try
                {
                    DiaryDAO diarydao = new DiaryDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                    SortedList<String, String> detaildiarylist = diarydao.getDiaryByTitle(title, false);
                    if (detaildiarylist != null)
                    {
                        Session["TITLE_DIARY"] = detaildiarylist["title"];
                        Session["CONTEXT_DIARY"] = detaildiarylist["content"];
                    }
                    else
                    {
                        g.jsmessage(Response, "Null Error");
                    }
                }
                catch (Exception ex)
                {
                    g.jsmessage(Response, ex.Message);
                }
            }
            else
            {
                g.jsmessage(Response, "Administrator Only.");
            }
        }
        protected void ModifyClick(object sender, EventArgs e)
        {
            String title = Request.Form["title"];
            String Context = Request.Form["context"];
            try
            {
                DiaryDTO diarydto = new DiaryDTO(title, Context, null, DateTime.Now.ToString());
                DiaryDAO diarydao = new DiaryDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                int rowUpdated = diarydao.updateDiary(diarydto);
                if(rowUpdated == 1)
                {
                    Response.Redirect("diarylist.aspx?desc=0");
                }
                else
                {
                    g.jsmessage(Response, "Unknown Error Message");
                }
            }catch(Exception ex)
            {
                g.jsmessage(Response, ex.Message);
            }
        }
    }
}