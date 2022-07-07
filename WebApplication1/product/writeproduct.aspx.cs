using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.product
{
    public partial class writeproduct : System.Web.UI.Page
    {
        Global g = new Global(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_ID"] == null && !Session["LOGIN_ID"].Equals("admin"))
            {
                g.jsmessage(Response, "Administrator Only.");
            }
        }

        protected void Write_Click(object sender, EventArgs e)
        {
            String product_no = Request.Form["product_no"];
            String product_name = Request.Form["product_name"];
            String buy_date = Request.Form["buy_date"];
            String buy_date_used = Request.Form["buy_date_used"];
            String purpose = Request.Form["purpose"];
            String viewName = null;
            try
            {
                ProductDTO productdto = new ProductDTO(product_no, product_name, buy_date, buy_date_used, purpose);
                ProductDAO productdao = new ProductDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                int Rowsinserted = productdao.insertProduct(productdto);
                if(Rowsinserted == 1)
                {
                    viewName = "productlist.aspx?desc=0&columnname=product_no";
                }
                else
                {
                    g.jsmessage(Response, "Unknown Error Message");
                }
            }catch(Exception ex)
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