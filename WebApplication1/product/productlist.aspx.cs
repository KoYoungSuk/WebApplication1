using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.product
{
    public partial class _productlist : System.Web.UI.Page
    {
        Global g = new Global();

        protected void Page_Load(object sender, EventArgs e)
        {
            int desc = Int32.Parse(Request.QueryString["desc"]);
            String columnname = Request.QueryString["columnname"];
            Boolean descbool = false;
            if (Session["LOGIN_ID"] != null && Session["LOGIN_ID"].Equals("admin"))
            {
                if(desc == 1)
                {
                    descbool = true;
                }
                ProductDAO productdao = new ProductDAO(g.dburl, g.dbport, g.dbsid, g.dbid, g.dbpw);
                List<ProductDTO> totalproductlist = productdao.GetProductTotalList(columnname, descbool);
                ProductNumber.Text = productdao.GetProductNumber() + "";
                Session["totalproductlist"] = totalproductlist; 
            }
            else
            {
                g.jsmessage(Response, "Administrator Only.");
            }
        }

        protected void TitleFound(object sender, EventArgs e)
        {
            String product_number = Request.Form["ProductNumber"];
            try
            {
                Response.Redirect("detailproduct.aspx?title=" + product_number);
            }catch(Exception ex)
            {
                g.jsmessage(Response, ex.Message);
            }
        }
    }
}