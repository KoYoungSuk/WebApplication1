<%@ Page Title="Product Manager" Language="C#" MasterPageFile="~/product/Product.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication1.product._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table>
	  <tr>
	    <td><label for="ID">ID:</label></td>
	    <td><input type="text" name="id" value="admin" readonly required /></td>
	  </tr>
	  <tr>
	   <td><label for="Password">Password:</label></td>
	   <td><input type="password" name="password" required /></td>
	  </tr>
	</table>
	<hr>
	<input type="submit" class="btn btn-primary" OnServerClick="Login_Click" runat="server" value="Login" />
	<input type="button" class="btn btn-primary" onclick="history.go(-1);" value="Back" />
	<input type="button" class="btn btn-primary" onclick="location.href='../default.aspx'" value="Back to main page" />
</asp:Content>
