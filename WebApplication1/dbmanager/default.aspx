<%@ Page Title="Welcome to ASPOracleManager" Language="C#" MasterPageFile="~/dbmanager/DBManager.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication1.dbmanager._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table>
   <tr>
   <td><label for="dburl">DB Address/port(ETC: kyshome.iptime.org:1521/xe)</label></td>
   <td><input type="text" name="dburl" required /></td>
  </tr>
   <tr>
   <td><label for="dbid">DB ID</label></td>
   <td><input type="text" name="dbid" required /></td>
   </tr>
   <tr>
   <td><label for="dbpw">DB Password</label></td>
   <td><input type="password" name="dbpw" required /></td>
   </tr>
   <tr>
    <td><label for="mode">DB Mode</label></td>
    <td><input type="radio" name="mode" value="easy" />Easy Mode</td>
    <td><input type="radio" name="mode" value="professional" checked />Professional Mode</td>
    </tr>
   </table>
    <hr />
   <button type="submit" class="btn btn-success" OnServerClick="DBLogin_Click" runat="server">LOGIN</button>
   <button type="button" class="btn btn-primary" onclick="history.go(-1);">BACK</button>
   <button type="button" class="btn btn-primary" onclick="location.href='../default.aspx'">BACK TO MAIN PAGE</button>
</asp:Content>
