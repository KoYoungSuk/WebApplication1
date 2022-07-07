using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.product
{
    public partial class modifyproduct : System.Web.UI.Page
    {
        Global g = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_ID"] != null && Session["LOGIN_ID"].Equals("admin"))
            {
                String number = Request.QueryString["number"];
                try
                {
                    ProductDAO productdao = new ProductDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                    SortedList<String, String> detailproductlist = productdao.getProductListByNumber(number);
                    Session["Product_no"] = detailproductlist["product_no"];
                    Session["Product_name"] = detailproductlist["product_name"];
                    Session["Buy_date"] = detailproductlist["buy_date"];
                    Session["Buy_date_used"] = detailproductlist["buy_date_used"];
                    Session["Purpose"] = detailproductlist["purpose"];
                }
                catch(Exception ex)
                {
                    g.jsmessage(Response, ex.Message);
                }
            }
            else
            {
                g.jsmessage(Response, "Administrator Only.");
            }
        }
        
        protected void Modify_Click(object sender, EventArgs e)
        {
            String number = Request.Form["product_no"];
            String name = Request.Form["product_name"];
            String buydate = Request.Form["buy_date"];
            String buydateused = Request.Form["buy_date_used"];
            String purpose = Request.Form["purpose"];
            String viewName = null;
            try
            {
                ProductDTO productdto = new ProductDTO(number, name, buydate, buydateused, purpose);
                ProductDAO productdao = new ProductDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                int RowsUpdated = productdao.updateProduct(productdto);
                if(RowsUpdated == 1)
                {
                    viewName = "productlist.aspx?desc=0&columnname=product_no";
                }
                else
                {
                    g.jsmessage(Response, "Unknown Error Message");
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