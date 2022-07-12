using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Global
    {
        //Default DB ID, PW, URL, PORT, SID (FOR BOARD, MANAGE PRODUCT, DIARY AND MEMBER) 
        public String dbid = "dbid";
        public String dbpw = "dbpw";
        public String dburl = "localhost";
        public String dbport = "1521";
        public String dbsid = "xe";
        // Xeon E3-1230 V2 Server(Windows Server 2016 DataCenter 64-bit) 
        // ID AND PW ARE COVERED DUE TO SECURITY ISSUE.

        public String connectionString(String dburl, String port, String sid, String id, String pw)
        {
            String connstr = String.Format("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={2})));User Id={3};Password={4}", dburl, port, sid, id, pw);
            return connstr;
        }
        public void jsmessage(HttpResponse Response, String message)
        {
            Response.Write("<script> alert('" + message + "'); history.go(-1); </script>");
        }
        public String checkOSVer()
        {
            string HKLMWinNTCurrent = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            string osName = Registry.GetValue(HKLMWinNTCurrent, "productName", "").ToString();
            string osBuild = Registry.GetValue(HKLMWinNTCurrent, "CurrentBuildNumber", "").ToString();
            return osName + "(Build: " + osBuild + ")";
        }
    }
}
