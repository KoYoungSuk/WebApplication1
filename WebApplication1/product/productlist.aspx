<%@ Page Title="Product Manager" Language="C#" MasterPageFile="~/product/Product.Master" AutoEventWireup="true" CodeBehind="productlist.aspx.cs" Inherits="WebApplication1.product._productlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <hr />
     <p>Current User: <%= Session["LOGIN_ID"] %></p>
	    <p>Product Number: <asp:Label ID="ProductNumber" runat="server" /></p>
		<hr />
           SEARCH PRODUCT(BY NUMBER): <input type="text" name="ProductNumber" />&nbsp;&nbsp;
           <input type="submit" OnServerClick="TitleFound" class="btn btn-success" value="Search" runat="server" />
           <hr />
           <%
               if (Int32.Parse(Request.QueryString["desc"]) == 0)
               {
           %>
                 <input type="button" onclick="location.href='productlist.aspx?desc=1&columnname=product_no'" class="btn btn-primary" value="Descend By Number"  />             
                 <input type="button" onclick="location.href='productlist.aspx?desc=1&columnname=buy_date'" class="btn btn-primary" value="Descend By Buydate"  />     
                 <input type="button" onclick="location.href='productlist.aspx?desc=1&columnname=buy_date_used'" class="btn btn-primary" value="Descend By Buydate(used)"  />     
           <%
               }
               else
               {
           %>
                <input type="button" onclick="location.href='productlist.aspx?desc=0&columnname=product_no'" class="btn btn-primary" value="Ascend By Number" />
                <input type="button" onclick="location.href='productlist.aspx?desc=0&columnname=buy_date'" class="btn btn-primary" value="Ascend By Buydate" />
                <input type="button" onclick="location.href='productlist.aspx?desc=0&columnname=buy_date_used'" class="btn btn-primary" value="Ascend By Buydate(used)" />
           <%
               }
           %>
           <hr />
           <table border="1">
             <thead>
                <tr>
                 <th>Number</th>
                 <th>Name</th>
                 <th>Buy Date</th>
                 <th>Buy Date(Used)</th>
                 <th>Purpose</th>
               </tr>
             </thead>
             <tbody>
                 <%
                     
                     List<WebApplication1.ProductDTO> productlist = (List<WebApplication1.ProductDTO>)Session["totalproductlist"];
                     for (int i = 0; i < productlist.Count; i++)
                     {
                 %>
                     <tr>
                     <td><%= productlist[i].Product_no %></td>
                     <td><a href="detailproduct.aspx?number=<%= productlist[i].Product_no %>"><%= productlist[i].Product_name %></a></td>
                     <td><%= productlist[i].Buy_date %></td>
                     <td><%= productlist[i].Buy_date_used %></td>
                     <td><a href="deleteproduct.aspx?number=<%= productlist[i].Product_no %>">Delete</a></td>
                    </tr>
                 <%
                     } 
                     
                 %>
             </tbody>
           </table>
          <hr />
</asp:Content>
