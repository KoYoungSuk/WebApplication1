using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.diary
{
    public partial class diarylist : System.Web.UI.Page
    {
        Global g = new Global();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_ID"].Equals("admin"))
            {
                try
                {
                    DiaryDAO diarydao = new DiaryDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                    int desc = Int32.Parse(Request.QueryString["desc"]);
                    Boolean booldesc = false;
                    if (desc != 0)
                    {
                        booldesc = true;
                    }
                    List<DiaryDTO> totaldiarylist = diarydao.getDiary(booldesc);
                    int diarynumber = diarydao.getDiaryNumber();
                    if (totaldiarylist != null)
                    {
                        Session["totaldiarylist"] = totaldiarylist;
                    }
                    else
                    {
                        g.jsmessage(Response, "Null Error");
                    }
                    DiaryNumber.Text = diarynumber + "";
                }
                catch(Exception ex)
                {
                    g.jsmessage(Response, ex.Message);
                }
            }
            else
            {
                g.jsmessage(Response, "Administrator Only.");
            }
        }
        protected void TitleFound(object sender, EventArgs e)
        {
            String title = TitleID.Text;
            Response.Redirect("detaildiary.aspx?title=" + title);
        }
    }
}