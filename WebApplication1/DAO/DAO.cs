using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class DAO
    {
        OracleConnection conn = null;
        public DAO(OracleConnection conn)
        {
            this.conn = conn;
        }
        public int getQueryResult(String sql, String value, Boolean identified) //삽입, 수정, 삭제 
        {
            OracleCommand ocmd = new OracleCommand(sql, conn);
            if (identified)
            {
                ocmd.BindByName = true;
                ocmd.Parameters.Add("attribute", value);
            }
            int result = ocmd.ExecuteNonQuery();
            return result;
        }
        public DataTable GetTotalList(String sql, String value, Boolean identified) //SELECT 
        {
            OracleCommand scmd = new OracleCommand(sql, conn);
            if (identified)
            {
                scmd.BindByName = true;
                scmd.Parameters.Add(new OracleParameter("attribute", value));
            }
            OracleDataAdapter oda = new OracleDataAdapter();
            oda.SelectCommand = scmd;
            DataTable dt = new DataTable();
            oda.Fill(dt);
            return dt;
        }

        public int getQueryResultEasy(String tablename, String attribute, String value)
        {
            String sql = "delete from " + tablename + " where " + attribute + "=:attribute";
            int result = getQueryResult(sql, value, true);
            return result;
        }
        public DataTable GetTotalListEasy(String tablename, String attribute, String value)
        {
            DataTable dt = null;
            String sql = null;
            System.Diagnostics.Debug.WriteLine(attribute);
            System.Diagnostics.Debug.WriteLine(sql);
            Boolean identified = false;
            if (attribute.Equals("") && value.Equals(""))
            {
                attribute = null;
                value = null;
            }
            if(attribute == null && value == null)
            {
                sql = "select * from " + tablename;
            }
            else
            {
                sql = "select * from " + tablename + " where " + attribute + "=:attribute";
                identified = true;
            }
            dt = GetTotalList(sql, value, identified);
            return dt; 
        }
    }
}