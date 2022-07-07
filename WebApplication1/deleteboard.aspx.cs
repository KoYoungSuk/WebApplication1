
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class deleteboard : System.Web.UI.Page
    {
        int serial;
        Global g = new Global();
        BoardDAO boarddao;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_ID"] != null && Session["LOGIN_ID"].Equals("admin"))
            {
                boarddao = new BoardDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                try
                {
                    serial = Int32.Parse(Request.QueryString["serial"]);
                    SortedList<String, String> boardlist = boarddao.getBoardListBySerial(serial, false);
                    boardlist["content"] = boardlist["content"].Replace("\r\n", "<br>"); //줄바꿈을 HTML로 바꾼다. 
                    boardlist["content"] = boardlist["content"].Replace("\n", "<br>");  //줄바꿈을 HTML로 바꾼다. 
                    if (boardlist != null)
                    {
                        UserIDLabel.Text = boardlist["userid"];
                        SerialLabel.Text = boardlist["serial"];
                        TitleLabel.Text = boardlist["title"];
                        ContextLabel.Text = boardlist["content"];
                        SaveDateLabel.Text = boardlist["savedate"];
                        ModifyDateLabel.Text = boardlist["modifydate"];
                        AccessLabel.Text = boardlist["access"];
                        ClicksLabel.Text = boardlist["clicks"];
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
        protected void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                boarddao = new BoardDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                int RowsDeleted = boarddao.DeleteBoard(serial);
                if(RowsDeleted == 0)
                {
                    g.jsmessage(Response, "Unknown Error Message");
                }
                else
                {
                    Response.Redirect("totalboardlist.aspx");
                }
            }catch(Exception ex)
            {
                g.jsmessage(Response, ex.Message);
            }
        }
    }
}