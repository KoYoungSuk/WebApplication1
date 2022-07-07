<%@ Page Title="" Language="C#" MasterPageFile="~/diary/Diary.Master" AutoEventWireup="true" CodeBehind="modifydiary.aspx.cs" Inherits="WebApplication1.diary.modifydiary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	  <table>
	   <tr>
	   <td><label for="title">제목:</label></td>
	   <td><input type="text" name="title" required  value="<%= Session["TITLE_DIARY"] %>" /></td>
	   </tr>
	   <tr>
	   <td><label for="context">내용:</label></td>
	   <td><textarea rows="15" cols="61" name="context" autofocus wrap="hard" ><%= Session["CONTEXT_DIARY"] %></textarea></td>
	   </tr>
	 </table>
	<hr /> 
	<button class="btn btn-primary" type="submit" OnServerClick="ModifyClick" runat="server">Modify</button>
	<button class="btn btn-primary" onclick="history.go(-1);" type="button">Back</button>
	<button class="btn btn-primary" onclick="location.href='diarylist.aspx?desc=0'" type="button">Back To The Main Page(PersonalDiary)</button>
	<button class="btn btn-primary" onclick="location.href='../default.aspx'" type="button">Back To The Main Page(MyBlog)</button>
</asp:Content>
