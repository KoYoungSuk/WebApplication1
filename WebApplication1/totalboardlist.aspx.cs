using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class totalboardlist : System.Web.UI.Page
    {
        Global g = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            String access = null; 
            if(Session["LOGIN_ID"] != null)
            {
                LabelID.Text = Session["LOGIN_ID"].ToString();
                if (Session["LOGIN_ID"].Equals("admin"))
                {
                    access = "admin";  
                    LabelMode.Text = "Administrator Mode";
                }
                else
                {
                    access = "member";
                    LabelMode.Text = "Member Mode";
                }
            }
            else
            {
                access = "anonymous";
                LabelMode.Text = "Anonymous Mode";
            }   
    
              try
              {
                   BoardDAO boarddao = new BoardDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                   List<BoardDTO> boardlist = boarddao.getBoardList2(false);
                   List<BoardDTO> newboardlist = new List<BoardDTO>();
                   int boardnumber = boarddao.getBoardCount(access);
                   for(int i=0; i<boardlist.Count; i++)
                   {
                       if (access.Equals("admin"))   //관리자 모드이면 모든 접근 모드로 작성된 게시물을 다 볼수 있게 함 
                       {
                          newboardlist.Add(boardlist[i]);
                       }
                       else if (access.Equals("member"))  //멤버 모드면 관리자 모드로 작성된 게시물을 제외하고 다 볼 수 있게 함
                       {
                          if (!boardlist[i].Anonymous.Equals("admin"))
                          {
                            newboardlist.Add(boardlist[i]);
                          }
                       }
                       else
                       {
                          if (boardlist[i].Anonymous.Equals(access)) //비회원 모드이면 비회원 모드로만 작성된 게시물을 볼 수 있게 함
                          {
                            newboardlist.Add(boardlist[i]);
                          }
                       }  
                   }
                
                BoardNumber.Text = boardnumber + "";
                Session["totalboardlist_board"] = newboardlist;
             }
             catch (Exception ex)
             {
                 g.jsmessage(Response, ex.Message); 
             }
       }
       protected void SearchByTitle(object sender, EventArgs e)
        {
            String title = Request.Form["searchtitle"];
            String address = "detailboard.aspx?serial=";
            try
            {
                BoardDAO boarddao = new BoardDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                int number = boarddao.getBoardNumber(title);
                address = address + number;
                Response.Redirect(address);
            }
            catch(Exception ex)
            {
                g.jsmessage(Response, ex.Message);
            }
        }
     }
 }
