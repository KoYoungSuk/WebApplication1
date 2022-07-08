using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class BoardDAO
    {
        OracleConnection conn;
        Global g = new Global();
        String db_url;
        String db_port;
        String db_sid;
        String db_id;
        String db_pw;
        public BoardDAO(String db_url, String db_port, String db_sid, String db_id, String db_pw)
        {
            this.db_url = db_url;
            this.db_port = db_port;
            this.db_sid = db_sid;
            this.db_id = db_id;
            this.db_pw = db_pw;
        }

        public void connectDB()
        {
            String connstr = g.connectionString(db_url, db_port, db_sid, db_id, db_pw);
            conn = new OracleConnection(connstr);
            conn.Open();
        }
        public void disconnectDB()
        {
            conn.Close();
        }


        public int insertBoard(BoardDTO boarddto)
        {
            connectDB();
            String sql = "insert into board (serial, title, content2, savedate, modifydate, userid, anonymous, clicks) values(:0,:1,:2,:3,:4,:5,:6,:7)";
            //SqlCommand(아마 MSSQL)에서는 @을 사용하지만 오라클 데이터베이스에서는 :를 사용한다. 
            OracleCommand icmd = new OracleCommand(sql, conn);
            //icmd.BindByName = true;
            //SQL Injection(프로그램에 SQL 코드를 임의적으로 삽입하여 내부 데이터베이스 서버에 접근하여 데이터 유출, 변조, 관리자 인증 우회하는 거) 방지 
            
            icmd.Parameters.Add(new OracleParameter("0", boarddto.Serial));
            icmd.Parameters.Add(new OracleParameter("1", boarddto.Title));
            icmd.Parameters.Add(new OracleParameter("2", boarddto.Content));
            icmd.Parameters.Add(new OracleParameter("3", DateTime.Parse(boarddto.Savedate)));
            icmd.Parameters.Add(new OracleParameter("4", boarddto.Modifydate));
            icmd.Parameters.Add(new OracleParameter("5", boarddto.Userid));
            icmd.Parameters.Add(new OracleParameter("6", boarddto.Anonymous));
            icmd.Parameters.Add(new OracleParameter("7", boarddto.Clicks));
            //SqlCommand(아마 MSSQL)에서는 icmd.Parameters.Add("@0", boarddto.getSerial()); 이렇게 해서 하면 된다. 
            int RowInserted = icmd.ExecuteNonQuery();
            disconnectDB();
            return RowInserted;
        }

    
        public int UpdateBoard(BoardDTO boarddto, Boolean clicks)
        {
            //MODIFY = FALSE  DETAIL = TRUE 
            connectDB();
            String sql = "";
            OracleCommand ucmd = new OracleCommand();
            ucmd.BindByName = true;
            ucmd.Connection = conn;
            //sql = String.Format("update board set title='{0}', content2='{1}', anonymous='{2}', modifydate=sysdate where serial={3}", boarddto.getTitle(), boarddto.getContent(), boarddto.getAnonymous(), boarddto.getSerial());
            if (clicks)
            {
                sql = "update board set clicks=:clicks where serial=:serial";
                ucmd.CommandText = sql;
                ucmd.Parameters.Add(new OracleParameter("clicks", boarddto.Clicks));
                ucmd.Parameters.Add(new OracleParameter("serial", boarddto.Serial));
            }
            else
            {
                sql = "update board set title=:title, content2=:content2, anonymous=:anonymous, modifydate=:modifydate where serial=:serial";
                ucmd.CommandText = sql;
                ucmd.Parameters.Add(new OracleParameter("title", boarddto.Title));
                ucmd.Parameters.Add(new OracleParameter("content2", boarddto.Content));
                ucmd.Parameters.Add(new OracleParameter("anonymous", boarddto.Anonymous));
                ucmd.Parameters.Add(new OracleParameter("modifydate", DateTime.Parse(boarddto.Modifydate)));
                ucmd.Parameters.Add(new OracleParameter("serial", boarddto.Serial));
                //MSSQL에서는 @를 사용하나 오라클에서는 :를 사용한다. 
            }
            int RowUpdated = ucmd.ExecuteNonQuery();
            disconnectDB();
            return RowUpdated;
        }

        
        public int DeleteBoard(int serial)
        {
            connectDB();
            String sql = "delete from board where serial=:serial";
            OracleCommand dcmd = new OracleCommand(sql, conn);
            dcmd.BindByName = true;
            /* dcmd.Connection = conn;
            dcmd.CommandText = sql; */
            dcmd.Parameters.Add(new OracleParameter("serial", serial));
            int RowDeleted = dcmd.ExecuteNonQuery();
            disconnectDB();
            return RowDeleted; 
        }
        public SortedList<String, String> getBoardListBySerial(int serial, bool clicks)
        {
            connectDB();
            String sql = "select * from board where serial=:serial";
            OracleCommand scmd = new OracleCommand(sql, conn);
            scmd.BindByName = true;
            /*
            scmd.Connection = conn;
            scmd.CommandText = sql;
            */
            scmd.Parameters.Add(new OracleParameter("serial", serial));
            OracleDataReader dr = scmd.ExecuteReader();
            SortedList<String, String> boardlist = new SortedList<String, String>();
            int clicksnumber = 0;
            while (dr.Read())
            {
                boardlist.Add("userid", dr["userid"].ToString());
                boardlist.Add("serial", dr["serial"].ToString());
                boardlist.Add("title", dr["title"].ToString());
                boardlist.Add("content", dr["content2"].ToString());
                boardlist.Add("savedate", dr["savedate"].ToString());
                boardlist.Add("modifydate", dr["modifydate"].ToString());
                boardlist.Add("access", dr["anonymous"].ToString());
                if (clicks)
                {
                    clicksnumber = Int32.Parse(dr["clicks"].ToString()) + 1;
                    boardlist.Add("clicks", clicksnumber + "");
                    BoardDTO boarddto = new BoardDTO(serial, null, null, null, null, null, null, clicksnumber);
                    UpdateBoard(boarddto, true);
                }
                else
                {
                    boardlist.Add("clicks", dr["clicks"].ToString());
                }
            }
            dr.Close();
            disconnectDB();
            return boardlist;
        }
        
        public List<BoardDTO> getBoardList2(Boolean desc)
        {
            connectDB();
            String sql = null;
            if (desc)
            {
                sql = "select * from board order by serial desc";
            }
            else
            {
                sql = "select* from board order by serial";
            }
            OracleCommand scmd = new OracleCommand(sql, conn);
            /* scmd.Connection = conn;
            scmd.CommandText = sql;
            */
            OracleDataReader dr = scmd.ExecuteReader();
            List<BoardDTO> boardlist = new List<BoardDTO>();
            while (dr.Read())
            {
               BoardDTO boarddto = new BoardDTO();
               boarddto.Serial = Int32.Parse(dr["serial"].ToString());
               boarddto.Title = dr["title"].ToString();
               boarddto.Content = dr["content2"].ToString();
               boarddto.Savedate = dr["savedate"].ToString();
               boarddto.Modifydate = dr["modifydate"].ToString();
               boarddto.Userid = dr["userid"].ToString();
               boarddto.Anonymous = dr["anonymous"].ToString();
               boarddto.Clicks = Int32.Parse(dr["clicks"].ToString());
               boardlist.Add(boarddto);
            }
            dr.Close();
            disconnectDB();
            return boardlist;
        }

        public int getMaxBoardNumber()
        {
            connectDB();
            String sql = "select max(serial) maxnumber from board";
            OracleCommand scmd = new OracleCommand(sql, conn);
            OracleDataReader dr = scmd.ExecuteReader();
            int maxnumber = 0;
            while (dr.Read())
            {
                maxnumber = Int32.Parse(dr["maxnumber"].ToString());
            }
            disconnectDB();
            return maxnumber;
        }

        public int getBoardCount(String access)
        {
            connectDB();
            String sql = "";
            if (access.Equals("admin"))
            {
                sql = "select count(*) countnumber from board";
            }
            else if (access.Equals("member"))
            {
                sql = "select count(*) countnumber from board where anonymous != 'admin'";
            }
            else
            {
                sql = "select count(*) countnumber from board where anonymous = 'anonymous'";
            }
            OracleCommand scmd = new OracleCommand(sql, conn);
            OracleDataReader dr = scmd.ExecuteReader();
            int countnumber = 0;
            while (dr.Read())
            {
                countnumber = Int32.Parse(dr["countnumber"].ToString());
            }
            dr.Close();
            disconnectDB();
            return countnumber;
        }

        public int getBoardNumber(String title)
        {

            connectDB();
            String sql = "select serial from board where title = :title";
            OracleCommand scmd = new OracleCommand(sql, conn);
            scmd.Parameters.Add(new OracleParameter("title", title));
            OracleDataReader dr = scmd.ExecuteReader();
            int number = 0;
            while (dr.Read())
            {
                number = Int32.Parse(dr["serial"].ToString());
            }
            dr.Close();
            disconnectDB();
            return number;
        }
    }
}