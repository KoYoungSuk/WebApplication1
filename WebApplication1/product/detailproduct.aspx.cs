using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.product
{
    public partial class detailproduct : System.Web.UI.Page
    {
        Global g = new Global();
        String product_number;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_ID"] != null && Session["LOGIN_ID"].Equals("admin"))
            {
                product_number = Request.QueryString["number"];
                try
                {
                    ProductDAO productdao = new ProductDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                    SortedList<String, String> detailproductlist = productdao.getProductListByNumber(product_number);
                    ProductnoLabel.Text = detailproductlist["product_no"];
                    ProductnameLabel.Text = detailproductlist["product_name"];
                    BuydateLabel.Text = detailproductlist["buy_date"];
                    BuydateusedLabel.Text = detailproductlist["buy_date_used"];
                    PurposeLabel.Text = detailproductlist["purpose"];
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
            product_number = Request.QueryString["number"];
            Response.Redirect("modifyproduct.aspx?number=" + product_number);
        }
        
        protected void Delete_Click(object sender, EventArgs e)
        {
            product_number = Request.QueryString["number"];
            Response.Redirect("deleteproduct.aspx?number=" + product_number);
        }
    }
}