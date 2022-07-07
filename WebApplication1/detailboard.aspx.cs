using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class detailboard : System.Web.UI.Page
    {
        Global g = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Previous Board Session Delete 
            Session.Remove("BOARDLIST_SERIAL");
            Session.Remove("BOARDLIST_SERIAL_FIRSTROW");
            Session.Remove("Boolaccess");
            //Previous Board Session Delete
            Boolean boolaccess = false;
            String access_current = "anonymous"; //현재 접근 모드 
            if (Session["LOGIN_ID"] != null)
            {
                if (Session["LOGIN_ID"].Equals("admin"))
                {
                    access_current = "admin";
                }
                else
                {
                    access_current = "member";
                }
            }
            else
            {
                access_current = "anonymous";
            }
            try
            {
                BoardDAO boarddao = new BoardDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                int serial = Int32.Parse(Request.QueryString["serial"]);
                SortedList<String, String> boardlist = boarddao.getBoardListBySerial(serial, true); //clickbool이 true이면 조회수를 올리도록 한다. 
                if(boardlist != null)
                {
                    String access = boardlist["access"]; //게시물에 있는 접근 모드
                    boardlist["content"] = boardlist["content"].Replace("\r\n", "<br>"); //줄바꿈을 HTML로 바꾼다. 
                    boardlist["content"] = boardlist["content"].Replace("\n", "<br>");  //줄바꿈을 HTML로 바꾼다. 
                    if (access_current.Equals("admin")) //현재 접근 모드가 관리자 모드
                    {
                        boolaccess = true; //전체 허용 
                    }
                    else if (access_current.Equals("member")) //현재 접근 모드가 회원 모드
                    {
                        if (!access.Equals("admin")) //게시물이 관리자 모드로 작성되지 않은 경우만 허용 
                        {
                            boolaccess = true;
                        }
                        else
                        {
                            boolaccess = false;
                        }
                    }
                    else
                    {
                        if (access_current.Equals(access)) //현재 접근 모드가 비회원 모드일 경우 비회원 모드로 작성된 글만 접근 허용 
                        {
                            boolaccess = true;
                        }
                        else
                        {
                            boolaccess = false;
                        }
                    }
                    Session["Boolaccess"] = boolaccess;
                    if (boolaccess)
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
                        g.jsmessage(Response, "illegal access detected.");
                    }
                }
            }
            catch(Exception ex)
            {
                    g.jsmessage(Response, ex.Message);
            }
          
        }
    }
}