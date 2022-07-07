<%@ Page Title="" Language="C#" MasterPageFile="~/diary/Diary.Master" AutoEventWireup="true" CodeBehind="deletediary.aspx.cs" Inherits="WebApplication1.diary.deletediary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
		<table border="1">
			<tr>
			  <td>Title:</td>
			  <td><asp:Label ID="TitleLabelID" runat="server"/></td>
			</tr>
			<tr>
			  <td>Context:</td>
			  <td><asp:Label ID="ContextLabelID" runat="server"/></td>
			</tr>
			<tr>
			  <td>SaveDate:</td>
			  <td><asp:Label ID="SaveDateLabelID" runat="server"/></td>
			</tr>
			<tr>
              <td>ModifyDate:</td>
			  <td><asp:Label ID="ModifyDateLabelID" runat="server"/></td>
			</tr>
		</table>
	    <hr /> 
	    <button class="btn btn-danger" OnServerClick="DeleteClick" type="button" runat="server">Delete</button>
	    <button class="btn btn-primary" onclick="history.go(-1);" type="button">Back</button>
	    <button class="btn btn-primary" onclick="location.href='diarylist.aspx?desc=0'" type="button">Back To Main Page(PersonalDiary)</button>
	    <button class="btn btn-primary" onclick="location.href='../default.aspx'" type="button">Back To Main Page(MyBlog)</button>
</asp:Content>
