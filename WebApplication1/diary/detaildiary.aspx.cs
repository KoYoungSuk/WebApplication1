﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.diary
{
    public partial class detaildiary : System.Web.UI.Page
    {
        Global g = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_ID"] != null && Session["LOGIN_ID"].Equals("admin"))
            {
                String title = Request.QueryString["title"];
                try
                {
                    DiaryDAO diarydao = new DiaryDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                    SortedList<String, String> diarylist = diarydao.getDiaryByTitle(title, true);
                    if (diarylist != null)
                    {
                        TitleLabelID.Text = diarylist["title"];
                        ContextLabelID.Text = diarylist["content"];
                        SaveDateLabelID.Text = diarylist["savedate"];
                        ModifyDateLabelID.Text = diarylist["modifydate"];
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
                Response.Redirect("diary");
            }
        }
    }
}