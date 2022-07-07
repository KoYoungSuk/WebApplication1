using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace WebApplication1.dbmanager
{
    public partial class easy : System.Web.UI.Page
    {
        Global g = new Global();
        
        public void DisconnectDB(Boolean check)
        {
            Session.Clear();
            String viewName = null;
            if (check) 
            {
                viewName = "../default.aspx";
            }
            else
            {
                viewName = "default.aspx";
            }
            Response.Redirect(viewName);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DataBaseGridViewID.DataSource = null;
            DegreeLabelID.Text = "";
            CardinalityLabelID.Text = "";
            ExecuteLabelID.Text = "";
            ExecuteStatusLabelID.Text = "Please Execute Query..";
        }
        protected void SQL_Click(object sender, EventArgs e)
        {
            try
            {
                DataBaseGridViewID.DataSource = null;
                DegreeLabelID.Text = "";
                CardinalityLabelID.Text = "";
                String dburl = (string)Session["DB_URL"];
                String dbid = (string)Session["DB_ID"];
                OracleConnection conn = (OracleConnection)Session["DB_CONNECTION"];
                String tablename = Request.Form["tablename"];
                String attribute = Request.Form["attribute"];
                String value = Request.Form["value"];
                String mode = Request.Form["mode"];
                DAO dao = new DAO(conn);
                Session["tablename"] = tablename;
                Session["attribute"] = attribute;
                Session["value"] = value; 
                ExecuteLabelID.Text = "Executed Query at [ " + DateTime.Now.ToString() + "] ";

                if (mode.Equals("select"))
                {
                    DataBaseGridViewID.DataSource = dao.GetTotalListEasy(tablename, attribute, value);
                    DataBaseGridViewID.DataBind();
                    DegreeLabelID.Text = dao.GetTotalListEasy(tablename, attribute, value).Columns.Count.ToString();
                    CardinalityLabelID.Text = dao.GetTotalListEasy(tablename, attribute, value).Rows.Count.ToString();
                    ExecuteStatusLabelID.Text = "Success Query Executed at " + DateTime.Now.ToString();
                }
                else
                {
                    int result = dao.getQueryResultEasy(tablename, attribute, value);
                    if(result == 1)
                    {
                        ExecuteStatusLabelID.Text = "Success Query Executed at " + DateTime.Now.ToString();
                    }
                    else
                    {
                        g.jsmessage(Response, "Unknown Error Message at " + DateTime.Now.ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                g.jsmessage(Response, ex.Message + " at " + DateTime.Now.ToString());
            }
       }
        
        protected void BackManager_Click(object sender, EventArgs e)
        {
            DisconnectDB(false);
        }

        protected void BackMain_Click(object sender, EventArgs e)
        {
            DisconnectDB(true);
        }
    }
}