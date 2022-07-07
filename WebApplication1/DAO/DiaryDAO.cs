using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class DiaryDAO
    {
        String dburl;
        String dbport;
        String dbsid;
        String dbid;
        String dbpw;
        OracleConnection conn = null;
        Global g = new Global();
        public DiaryDAO(String dburl, String dbport, String dbsid, String dbid, String dbpw)
        {
            this.dburl = dburl;
            this.dbport = dbport;
            this.dbsid = dbsid;
            this.dbid = dbid;
            this.dbpw = dbpw;
        }
        public void connectDB()
        {
            String connstr = g.connectionString(dburl, dbport, dbsid, dbid, dbpw);
            conn = new OracleConnection(connstr);
            conn.Open();
        }

        public void disconnectDB()
        {
            conn.Close();
        }
        public SortedList<String, String> getDiaryByTitle(String title, Boolean br)
        {
            SortedList<String, String> diarylist = new SortedList<String, String>();
            connectDB();
            String sql = "select * from diary where title=:title";
            OracleCommand scmd = new OracleCommand(sql, conn);
            scmd.BindByName = true;
            scmd.Parameters.Add(new OracleParameter("title", title));
            OracleDataReader dr = scmd.ExecuteReader();
            while (dr.Read())
            {
                diarylist.Add("title", dr["title"].ToString());
                if (br)
                {
                    diarylist.Add("content", dr["context"].ToString().Replace("\r\n", "<br>"));
                }
                else
                {
                    diarylist.Add("content", dr["context"].ToString());
                }
                diarylist.Add("savedate", dr["savedate"].ToString());
                diarylist.Add("modifydate",dr["modifydate"].ToString());
            }
            dr.Close();
            disconnectDB();
            return diarylist;
        }

        public List<DiaryDTO> getDiary(Boolean desc)
        {
            List<DiaryDTO> diarylist = new List<DiaryDTO>();
            connectDB();
            String sql;
            if (desc)
            {
                sql = "select * from diary order by title desc";
            }
            else
            {
                sql = "select * from diary order by title";
            }
            OracleCommand scmd = new OracleCommand(sql, conn);
            OracleDataReader dr = scmd.ExecuteReader();
            while (dr.Read())
            {
                DiaryDTO diarydto = new DiaryDTO();
                diarydto.Title = dr["title"].ToString();
                diarydto.Context = dr["context"].ToString();
                diarydto.Savedate = dr["savedate"].ToString();
                diarydto.Modifydate = dr["modifydate"].ToString();
                diarylist.Add(diarydto);
            }
            dr.Close();
            disconnectDB();
            return diarylist;
        }

        public int insertDiary(DiaryDTO diarydto)
        {
            connectDB();
            String sql = "insert into diary (title, context, savedate, modifydate) values (:title, :context, :savedate, :modifydate)";
            OracleCommand icmd = new OracleCommand(sql, conn);
            icmd.BindByName = true;
            icmd.Parameters.Add(new OracleParameter("title", diarydto.Title));
            icmd.Parameters.Add(new OracleParameter("context", diarydto.Context));
            icmd.Parameters.Add(new OracleParameter("savedate", DateTime.Parse(diarydto.Savedate)));
            icmd.Parameters.Add(new OracleParameter("modifydate", diarydto.Modifydate));
            int result = icmd.ExecuteNonQuery();
            disconnectDB();
            return result;
        }

        public int updateDiary(DiaryDTO diarydto)
        {
            connectDB();
            String sql = "update diary set context=:context, modifydate=:modifydate where title = :title";
            OracleCommand ucmd = new OracleCommand(sql, conn);
            ucmd.BindByName = true;
            ucmd.Parameters.Add(new OracleParameter("context", diarydto.Context));
            ucmd.Parameters.Add(new OracleParameter("modifydate", DateTime.Parse(diarydto.Modifydate)));
            ucmd.Parameters.Add(new OracleParameter("title", diarydto.Title));
            int result = ucmd.ExecuteNonQuery();
            disconnectDB();
            return result; 

        }
        public int deleteDiary(String title)
        {
            connectDB();
            String sql = "delete from diary where title= :title";
            OracleCommand dcmd = new OracleCommand(sql, conn);
            dcmd.BindByName = true;
            dcmd.Parameters.Add(new OracleParameter("title", title));
            int result = dcmd.ExecuteNonQuery();
            disconnectDB();
            return result; 
        }
        public int getDiaryNumber()
        {
            connectDB();
            String sql = "select count(*) diarynumber from diary";
            OracleCommand scmd = new OracleCommand(sql, conn);
            OracleDataReader dr = scmd.ExecuteReader();
            int diarynumber = 0;
            while (dr.Read())
            {
                diarynumber = Int32.Parse(dr["diarynumber"].ToString());
            }
            dr.Close();
            disconnectDB();
            return diarynumber;
        }

    }
}