<%@ Page Title="" Language="C#" MasterPageFile="~/diary/Diary.Master" AutoEventWireup="true" CodeBehind="diarylist.aspx.cs" Inherits="WebApplication1.diary.diarylist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	    <hr />
	    <p>Current User: <%= Session["LOGIN_ID"] %></p>
	    <p>Diary Number: <asp:Label ID="DiaryNumber" runat="server" /></p>
		<hr />
           SEARCH DIARY: <asp:TextBox ID="TitleID" runat="server" />
           <input type="submit" OnServerClick="TitleFound" class="btn btn-success" value="Search" runat="server" />
           &nbsp;&nbsp;
           <%
               if (Int32.Parse(Request.QueryString["desc"]) == 0)
               {
           %>
                 <input type="button" onclick="location.href='diarylist.aspx?desc=1'" class="btn btn-success" value="DESCEND"  />             
           <%
               }
               else
               {
           %>
                <input type="button" onclick="location.href='diarylist.aspx?desc=0'" class="btn btn-success" value="ASCEND" />
           <%
               }
           %>
           <hr />
           <table border="1">
             <thead>
                <tr>
                 <th>Number</th>
                 <th>Title</th>
                 <th>Save Date</th>
                 <th>Modify Date</th>
                 <th>Delete</th>
               </tr>
             </thead>
             <tbody>
                 <%
                     List<WebApplication1.DiaryDTO> diarylist = (List<WebApplication1.DiaryDTO>)Session["totaldiarylist"];
                     for (int i = 0; i < diarylist.Count; i++)
                     {
                 %>
                     <tr>
                     <td><%= i %></td>
                     <td><a href="detaildiary.aspx?title=<%= diarylist[i].Title %>"><%= diarylist[i].Title %></a></td>
                     <td><%= diarylist[i].Savedate %></td>
                     <td><%= diarylist[i].Modifydate %></td>
                     <td><a href="deletediary.aspx?title=<%= diarylist[i].Title %>">Delete</a></td>
                    </tr>
                 <%
                     } 
                 %>
             </tbody>
           </table>
</asp:Content>
