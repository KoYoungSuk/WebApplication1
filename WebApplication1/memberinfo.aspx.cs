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
  
    public partial class memberinfo : System.Web.UI.Page
    {
        Global g = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_ID"] != null)
            {
                LabelSessionID.Text = (string)Session["LOGIN_ID"];
                try
                {
                    MemberDAO memberdao = new MemberDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                    SortedList<String, String> memberlist =  memberdao.GetMemberListById(LabelSessionID.Text);
                    if(memberlist != null)
                    {
                        LabelSessionFirstName.Text = (string)Session["FIRST_NAME"];
                        LabelSessionLastName.Text = (string)Session["LAST_NAME"];
                        LabelSessionFullName.Text = (string)Session["FULL_NAME"];
                        LabelSessionBirthday.Text = memberlist["birthday"];
                        LabelSessionJoinDate.Text = memberlist["joindate"];
                    }
                    else
                    {
                        g.jsmessage(Response, "Null Error");
                    }
                }catch(Exception ex)
                {
                    g.jsmessage(Response, ex.Message);
                }
            }
            else
            {
                g.jsmessage(Response, "Please Login.");
            }
        }
    }
}