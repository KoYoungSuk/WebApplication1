using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.product
{
    public partial class deleteproduct : System.Web.UI.Page
    {
        Global g = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["LOGIN_ID"] == null && !Session["LOGIN_ID"].Equals("admin"))
            {
                g.jsmessage(Response, "Administrator Only");
            }
            else
            {
                String product_no = Request.QueryString["number"];
                String viewName = null;
                try
                {
                    ProductDAO productdao = new ProductDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                    int RowsDeleted = productdao.deleteProduct(product_no);
                    if(RowsDeleted == 1)
                    {
                        viewName = "productlist.aspx?desc=0&columnname=product_no";
                    }
                }
                catch(Exception ex)
                {
                    g.jsmessage(Response, ex.Message);
                }
                if(viewName != null)
                {
                    Response.Redirect(viewName);
                }
            }
        }
    }
}