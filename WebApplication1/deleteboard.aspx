<%@ Page Title="Delete Board" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="deleteboard.aspx.cs" Inherits="WebApplication1.deleteboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="col-sm-12">
                <h1>Delete Board</h1>
                <hr />
                   <table border="1">
                     <tr>
                        <td>작성자 ID: </td>
                        <td><asp:Label ID="UserIDLabel" runat="server" /></td>
                     </tr>
                     <tr>
                        <td>글 번호: </td>
                        <td><asp:Label ID="SerialLabel" runat="server" /></td>
                     </tr>
                     <tr>
                        <td>제목: </td>
                        <td><asp:Label ID="TitleLabel" runat="server" /></td>
                     </tr>
                     <tr>
                        <td>내용: </td>
                        <td><asp:Label ID="ContextLabel" runat="server" /></td>
                     </tr>
                     <tr>
                         <td>작성 시간: </td>
                         <td><asp:Label ID="SaveDateLabel" runat="server" /></td>
                     </tr>
                     <tr>
                         <td>수정 시간: </td>
                         <td><asp:Label ID="ModifyDateLabel" runat="server" /></td>
                     </tr>
                     <tr>
                         <td>접근 모드: </td>
                         <td><asp:Label ID="AccessLabel" runat="server" /></td>
                     </tr>
                     <tr>
                         <td>조회수: </td>
                         <td><asp:Label ID="ClicksLabel" runat="server" /></td>
                     </tr>
                   </table>
                   <hr />
                   <p>If you click Delete Button, this Member is Deleted. Continue? </p>
                  <button class="btn btn-danger" type="submit" OnServerClick="Delete_Click" runat="server">Yes!, Delete </button>
                  <button class="btn btn-success" type="button" onclick="location.href='default.aspx'">NO! Back to Main Page</button>
                  <button class="btn btn-success" type="button" onclick="history.go(-1)">NO! Back</button>
            </div>
</asp:Content>
