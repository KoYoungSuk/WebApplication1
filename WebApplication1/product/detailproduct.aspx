<%@ Page Title="" Language="C#" MasterPageFile="~/product/Product.Master" AutoEventWireup="true" CodeBehind="detailproduct.aspx.cs" Inherits="WebApplication1.product.detailproduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Detail</h2>
<hr />
<table border="1">
<tr>
 <td>물품 번호:</td>
 <td><asp:Label ID="ProductnoLabel" runat="server" /></td>
</tr>
<tr>
 <td>물품 이름:</td>
 <td><asp:Label ID="ProductnameLabel" runat="server" /></td>
</tr>
<tr>
 <td>물품 구매 날짜(신품): </td>
 <td><asp:Label ID="BuydateLabel" runat="server" /></td>
</tr>
<tr>
 <td>물품 구매 날짜(중고): </td>
 <td><asp:Label ID="BuydateusedLabel" runat="server" /></td>
</tr>
<tr>
 <td>용도: </td>
 <td><asp:Label ID="PurposeLabel" runat="server" /></td>
</tr>
</table>
<hr>
<button class="btn btn-success" type="submit" OnServerClick="Modify_Click" runat="server">Modify</button>
<button class="btn btn-danger"  type="submit" OnServerClick="Delete_Click" runat="server">Delete</button>
<button class="btn btn-primary" type="button" onclick="history.go(-1);">Back</button>
<button class="btn btn-primary" type="button" onclick="location.href='productlist.aspx?desc=0&columnname=product_no'">Back to ProductList</button>
<button class="btn btn-primary" type="button" onclick="location.href='../default.aspx'">Back to MyBlog</button>
</asp:Content>
