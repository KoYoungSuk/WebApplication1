using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class ProductDTO
    {
        String product_no;
        String product_name;
        String buy_date;
        String buy_date_used;
        String purpose;
         
        public ProductDTO()
        {

        }
        public ProductDTO(string product_no, string product_name, string buy_date, string buy_date_used, string purpose)
        {
            this.product_no = product_no;
            this.product_name = product_name;
            this.buy_date = buy_date;
            this.buy_date_used = buy_date_used;
            this.purpose = purpose;
        }
        public string Product_no { get => product_no; set => product_no = value; }
        public string Product_name { get => product_name; set => product_name = value; }
        public string Buy_date { get => buy_date; set => buy_date = value; }
        public string Buy_date_used { get => buy_date_used; set => buy_date_used = value; }
        public string Purpose { get => purpose; set => purpose = value; }
    }
       
}