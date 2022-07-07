<%@ Page Title="Bullet Board Detail" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="detailboard.aspx.cs" Inherits="WebApplication1.detailboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="col-sm-12">
                <h1>Detail Board</h1>
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
                <button class="btn btn-primary" type="button" onclick="history.go(-1);">Back</button>
                <button class="btn btn-primary" type="button" onclick="location.href='modifyboard.aspx?serial=<%= Request.QueryString["serial"] %>'">Modify</button>
                <button class="btn btn-danger" type="button" onclick="location.href='deleteboard.aspx?serial=<%= Request.QueryString["serial"] %>'">Delete</button>
            </div>
</asp:Content>
