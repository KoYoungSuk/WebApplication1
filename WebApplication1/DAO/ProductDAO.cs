using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class ProductDAO
    {
        String dburl;
        String dbport;
        String dbsid;
        String dbid;
        String dbpw;
        OracleConnection conn = null;
        Global g = new Global();
        public ProductDAO(string dburl, string dbport, string dbsid, string dbid, string dbpw)
        {
            this.dburl = dburl;
            this.dbport = dbport;
            this.dbsid = dbsid;
            this.dbid = dbid;
            this.dbpw = dbpw;
        }
        public void connectDB()
        {
            String connstr = g.connectionString(dburl, dbport, dbsid, dbid, dbpw);
            conn = new OracleConnection(connstr);
            conn.Open();
        }
        public void disconnectDB()
        {
            conn.Close();
        }

        public int insertProduct(ProductDTO productdto)
        {
            String sql = "insert into product (product_no, producT_name, buy_date, buy_date_used, purpose) values (:0, :1, :2, :3, :4)";
            connectDB();
            OracleCommand icmd = new OracleCommand(sql, conn);
            icmd.BindByName = true;
            icmd.Parameters.Add(new OracleParameter("0", productdto.Product_no));
            icmd.Parameters.Add(new OracleParameter("1", productdto.Product_name));
            icmd.Parameters.Add(new OracleParameter("2", productdto.Buy_date));
            icmd.Parameters.Add(new OracleParameter("3", productdto.Buy_date_used));
            icmd.Parameters.Add(new OracleParameter("4", productdto.Purpose));
            int result = icmd.ExecuteNonQuery();
            disconnectDB();
            return result; 
        }

        public int updateProduct(ProductDTO productdto)
        {
            String sql = "update product set product_name=:0, buy_date=:1, buy_date_used=:2, purpose=:3 where product_no=:4";
            connectDB();
            OracleCommand ucmd = new OracleCommand(sql, conn);
            ucmd.BindByName = true;
            ucmd.Parameters.Add(new OracleParameter("0", productdto.Product_name));
            ucmd.Parameters.Add(new OracleParameter("1", productdto.Buy_date));
            ucmd.Parameters.Add(new OracleParameter("2", productdto.Buy_date_used));
            ucmd.Parameters.Add(new OracleParameter("3", productdto.Purpose));
            ucmd.Parameters.Add(new OracleParameter("4", productdto.Product_no));
            int result = ucmd.ExecuteNonQuery();
            disconnectDB();
            return result;
        }
        public int deleteProduct(String number)
        {
            String sql = "delete from product where product_no=:product_no";
            connectDB();
            OracleCommand dcmd = new OracleCommand(sql, conn);
            dcmd.BindByName = true;
            dcmd.Parameters.Add(new OracleParameter("product_no", number));
            int result = dcmd.ExecuteNonQuery();
            disconnectDB();
            return result; 
        }
        public List<ProductDTO> GetProductTotalList(String columnname, Boolean desc)
        {
            List<ProductDTO> productlist = new List<ProductDTO>();
            String sql = null;
            if (desc)
            {
                if (columnname.Equals("buy_date"))
                {
                    sql = "select * from product order by buy_date desc";
                }
                else if (columnname.Equals("buy_date_used"))
                {
                    sql = "select * from product order by buy_date_used desc";
                }
                else
                {
                    sql = "select * from product order by product_no desc";
                }
            }
            else
            {
                if (columnname.Equals("buy_date"))
                {
                    sql = "select * from product order by buy_date";
                }
                else if (columnname.Equals("buy_date_used"))
                {
                    sql = "select * from product order by buy_date_used";
                }
                else
                {
                    sql = "select * from product order by product_no";
                }
            }
            connectDB();
            OracleCommand scmd = new OracleCommand(sql, conn);
            OracleDataReader dr = scmd.ExecuteReader();
            while (dr.Read())
            {
                ProductDTO productdto = new ProductDTO();
                productdto.Product_no = dr["product_no"].ToString();
                productdto.Product_name = dr["product_name"].ToString();
                productdto.Buy_date = dr["buy_date"].ToString();
                productdto.Buy_date_used = dr["buy_date_used"].ToString();
                productdto.Purpose = dr["purpose"].ToString();
                productlist.Add(productdto);
            }
            dr.Close();
            disconnectDB();
            return productlist;
        }

        public SortedList<String, String> getProductListByNumber(String number)
        {
            SortedList<String, String> productlist = new SortedList<String, String>();
            String sql = "select * from product where product_no=:product_no";
            connectDB();
            
            OracleCommand scmd = new OracleCommand(sql, conn);
            scmd.BindByName = true;
            scmd.Parameters.Add(new OracleParameter("product_no", number));
            OracleDataReader dr = scmd.ExecuteReader();
            while (dr.Read())
            {
                productlist.Add("product_no", dr["product_no"].ToString());
                productlist.Add("product_name", dr["product_name"].ToString());
                productlist.Add("buy_date", dr["buy_date"].ToString());
                productlist.Add("buy_date_used", dr["buy_date_used"].ToString());
                productlist.Add("purpose", dr["purpose"].ToString());
            }
            dr.Close();
            disconnectDB();
            return productlist;
        }

        public int GetProductNumber()
        {
            String sql = "select count(*) productnumber from product";
            int productnumber = 0;
            connectDB();
            OracleCommand scmd = new OracleCommand(sql, conn);
            OracleDataReader dr = scmd.ExecuteReader();
            while (dr.Read())
            {
                productnumber = Int32.Parse(dr["productnumber"].ToString());
            }
            dr.Close();
            disconnectDB();
            return productnumber;
        }
    }
}