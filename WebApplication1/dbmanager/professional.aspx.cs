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
    public partial class professional : System.Web.UI.Page
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
            DataBaseGridViewID.Columns.Clear();
            DataBaseGridViewID.DataBind();
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
                String sql = Request.Form["sqlcommand"];
                //sql = sql.ToUpper();
                String[] splitcommand = sql.Split(' ');
                String firstsql = splitcommand[0].ToLower();
                DAO dao = new DAO(conn);
                Session["SQLCommand"] = sql;
                ExecuteLabelID.Text = "Executed Query at [ " + DateTime.Now.ToString() + "] ";
                
                if (firstsql.Equals("select"))
                {
                    DataBaseGridViewID.DataSource = dao.GetTotalList(sql, null, false);
                    DataBaseGridViewID.DataBind();
                    DegreeLabelID.Text = dao.GetTotalList(sql, null, false).Columns.Count.ToString();
                    CardinalityLabelID.Text = dao.GetTotalList(sql, null, false).Rows.Count.ToString();
                    ExecuteStatusLabelID.Text = "Success Query Executed at " + DateTime.Now.ToString();
                }
                else
                {
                    int result = dao.getQueryResult(sql, null, false);
                    if (result == 0)
                    {
                        g.jsmessage(Response, "Unknown Error Message at " + DateTime.Now.ToString());
                    }
                    else
                    {
                        
                        ExecuteStatusLabelID.Text = "Success Query Executed at " + DateTime.Now.ToString();
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