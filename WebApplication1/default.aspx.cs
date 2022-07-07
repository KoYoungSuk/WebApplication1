using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _default : System.Web.UI.Page
    {
        Global g = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BoardDAO boarddao = new BoardDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                List<BoardDTO> boardlist = boarddao.getBoardList2(true);
                List<BoardDTO> newboardlist = new List<BoardDTO>();
                String access = null;
                int count = 0;
                if (Session["LOGIN_ID"] == null)
                {
                    access = "anonymous";
                }
                else
                {
                    if (Session["LOGIN_ID"].Equals("admin"))
                    {
                        access = "admin";
                    }
                    else
                    {
                        access = "member";
                    }
                }
                if(boardlist != null)
                {
                    for (int i = 0; i < boardlist.Count; i++)
                    {
                        if (access.Equals("admin"))   //관리자 모드이면 모든 접근 모드의 게시물을 다 볼수 있게 함 
                        {
                            newboardlist.Add(boardlist[i]);
                            count++;
                        }
                        else if (access.Equals("member"))  //멤버 모드면 관리자 모드로 제외된 게시물을 제외하고 다 볼 수 있게 함
                        {
                            if (!boardlist[i].Anonymous.Equals("admin"))
                            {
                                newboardlist.Add(boardlist[i]);
                                count++;
                            }
                        }
                        else
                        {
                            if (boardlist[i].Anonymous.Equals(access)) //비회원 모드이면 비회원 모드로만 작성된 게시물을 볼 수 있게 함
                            {
                                newboardlist.Add(boardlist[i]);
                                count++;
                            }
                        }

                        if(count >= 10)
                        {
                            break;
                        }
                    }
                    if(newboardlist != null)
                    {
                        Session["totalboardlist_default"] = newboardlist;
                    }
                    else
                    {
                        g.jsmessage(Response, "Null Error");
                    }
                }
                else
                {
                    g.jsmessage(Response, "Null Error");
                }
            }
            catch(Exception ex)
            {
                g.jsmessage(Response, ex.Message);
            }
           
        }
    }
}