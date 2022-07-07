<%@ Page Title="" Language="C#" MasterPageFile="~/product/Product.Master" AutoEventWireup="true" CodeBehind="writeproduct.aspx.cs" Inherits="WebApplication1.product.writeproduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h2>Write</h2>
 <hr />
 <table>
 <tr>
  <td><label for="product_no">물품 번호: </label></td>
  <td><input type="text" name="product_no" required /></td>
 </tr>
 <tr>
  <td><label for="product_name">물품 이름: </label></td>
  <td><input type="text" name="product_name" required /></td>
 </tr>
 <tr>
  <td><label for="buy_date">구매 날짜(신품): </label></td>
  <td><input type="text" name="buy_date" /></td>
 </tr>
 <tr>
  <td><label for="buy_date_used">구매 날짜(중고): </label></td>
  <td><input type="text" name="buy_date_used" /></td>
 </tr>
 <tr>
  <td><label for="purpose">용도: </label></td>
  <td><input type="text" name="purpose" /></td>
 </tr>
</table>
<hr />
<button class="btn btn-success" type="submit" OnServerClick="Write_Click" runat="server">Write</button>
<button class="btn btn-primary" type="button" onclick="history.go(-1);">Back</button>
<button class="btn btn-primary" type="button" onclick="location.href='../default.aspx'">Back to MyBlog</button>
<button class="btn btn-primary" type="button" onclick="location.href='productlist.aspx?desc=0&columnname=product_no'">Back to ProductList</button>
</asp:Content>
