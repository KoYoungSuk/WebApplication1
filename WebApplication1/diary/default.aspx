<%@ Page Title="PersonalDiary" Language="C#" MasterPageFile="~/diary/Diary.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication1.diary._default" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
	  <input type="submit" class="btn btn-primary" OnServerClick="LoginClick" value="LOGIN" runat="server" />
	  <input type="button" class="btn btn-primary" onclick="history.go(-1);" value="BACK" />
	  <input type="button" class="btn btn-primary" onclick="location.href='../default.aspx'" value="BACK TO THE MAIN PAGE" />
</asp:Content>
