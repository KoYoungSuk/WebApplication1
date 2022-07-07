using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class MemberDAO
    {
        OracleConnection conn;
        String db_url;
        String db_port;
        String db_sid;
        String db_id;
        String db_pw;
        public MemberDAO(String db_url, String db_port, String db_sid, String db_id, String db_pw)
        {
            this.db_url = db_url;
            this.db_port = db_port;
            this.db_sid = db_sid;
            this.db_id = db_id;
            this.db_pw = db_pw;

        }

        public void connectDB()
        {
            Global g = new Global();
            String connstr = g.connectionString(db_url, db_port, db_sid, db_id, db_pw);
            conn = new OracleConnection(connstr);
            conn.Open();
        }
        public void disconnectDB()
        {
            conn.Close();
        }
        public int insertMember(MemberDTO memberdto)
        {
            connectDB();
            String sql = "insert into member (id, password, firstname, lastname, birthday, joindate) values (:0, :1, :2, :3, :4, :5)";
            //String sql = String.Format("insert into member values('{0}', '{1}', '{2}', '{3}', '{4}', sysdate)", memberdto.getId(), memberdto.getPassword(), memberdto.getFirstName(), memberdto.getLastName(), memberdto.getBirthday());
            OracleCommand icmd = new OracleCommand(sql, conn);
            /*
            icmd.CommandText = sql;
            icmd.Connection = conn;
            */
            icmd.BindByName = true;
            icmd.Parameters.Add(new OracleParameter("0", memberdto.Id));
            icmd.Parameters.Add(new OracleParameter("1", memberdto.Password));
            icmd.Parameters.Add(new OracleParameter("2", memberdto.Firstname));
            icmd.Parameters.Add(new OracleParameter("3", memberdto.Lastname));
            icmd.Parameters.Add(new OracleParameter("4", memberdto.Birthday));
            icmd.Parameters.Add(new OracleParameter("5", DateTime.Parse(memberdto.Joindate)));
            int Rowinserted = icmd.ExecuteNonQuery();
            disconnectDB();
            return Rowinserted;
        }
        public int DeleteMember(String id)
        {
            connectDB();
            String sql = "delete from member where id = :id";
            OracleCommand dcmd = new OracleCommand(sql, conn);
            dcmd.BindByName = true;
            dcmd.Parameters.Add(new OracleParameter("id", id));
            int RowDeleted = dcmd.ExecuteNonQuery();
            disconnectDB();
            return RowDeleted;
        }
        public int UpdateMember(MemberDTO memberdto)
        {
            connectDB();
            String sql = "update member set password=:0, firstname=:1, lastname=:2, birthday=:3 where id=:4";
            //String sql = String.Format("update member set password='{0}', firstname='{1}', lastname='{2}', birthday='{3}' where id = '{4}'", memberdto.getPassword(), memberdto.getFirstName(), memberdto.getLastName(), memberdto.getBirthday(), memberdto.getId());
            OracleCommand ucmd = new OracleCommand(sql, conn);
            /* ucmd.CommandText = sql;
            ucmd.Connection = conn; */
            ucmd.BindByName = true;
            ucmd.Parameters.Add(new OracleParameter("0", memberdto.Password));
            ucmd.Parameters.Add(new OracleParameter("1", memberdto.Firstname));
            ucmd.Parameters.Add(new OracleParameter("2", memberdto.Lastname));
            ucmd.Parameters.Add(new OracleParameter("3", memberdto.Birthday));
            ucmd.Parameters.Add(new OracleParameter("4", memberdto.Id));
            int RowUpdated = ucmd.ExecuteNonQuery();
            disconnectDB();
            return RowUpdated;
        }
       
        public SortedList<String, String> GetMemberListById(String id)
        {
            connectDB();
            String sql = "select * from member where id = :id";
            OracleCommand scmd = new OracleCommand(sql, conn);
            scmd.BindByName = true;
            scmd.Parameters.Add(new OracleParameter("id", id));
            OracleDataReader dr = scmd.ExecuteReader();
     
            SortedList<String,String> memberlist = new SortedList<String, String>();
            while (dr.Read())
            {
                memberlist.Add("id", dr["id"].ToString());
                memberlist.Add("firstname", dr["firstname"].ToString());
                memberlist.Add("lastname", dr["lastname"].ToString());
                memberlist.Add("birthday", dr["birthday"].ToString());
                memberlist.Add("joindate", dr["joindate"].ToString());
            }
            dr.Close();
            disconnectDB();
            return memberlist;
        }

        public List<MemberDTO> GetMemberList()
        {
            connectDB();
            String sql = "select * from member order by id";
            OracleCommand scmd = new OracleCommand();
            scmd.Connection = conn;
            scmd.CommandText = sql;
            OracleDataReader odr = scmd.ExecuteReader();
            List<MemberDTO> memberlist = new List<MemberDTO>();
            while (odr.Read())
            {
                MemberDTO memberdto = new MemberDTO();
                memberdto.Id = odr["id"].ToString();
                memberdto.Password = odr["password"].ToString();
                memberdto.Firstname = odr["firstname"].ToString();
                memberdto.Lastname = odr["lastname"].ToString();
                memberdto.Birthday = odr["birthday"].ToString();
                memberdto.Joindate = odr["joindate"].ToString();
                memberlist.Add(memberdto); 
            }
            odr.Close();
            disconnectDB();
            return memberlist;
        }
        public DataTable GetTotalList(String sql)
        {
            connectDB();
            OracleDataAdapter oda = new OracleDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            disconnectDB();
            return dt;
        }
    }
}