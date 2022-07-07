<%@ Page Title="Modify Board" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="modifyboard.aspx.cs" Inherits="WebApplication1.modifyboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="col-sm-12">
                <h1>Modify Board</h1>
                <hr />
                     <table>
                        <tr>
                          <td><label for="Number">Number:</label></td>
                          <td><input type="text" name="serial" value="<%= Session["serial"] %>" readonly /></td>
                        </tr>
                        <tr>
                          <td><label for="UserId">UserId:</label></td>
                          <td><input type="text" name="userid" value="<%= Session["userid"] %>" readonly /></td>
                        </tr>
                        <tr>
                          <td><label for="Title">Title:</label></td>
                          <td><input type="text" name="title" value="<%= Session["title"] %>"  /></td>
                        </tr>
                        <tr>
                          <td><label for="Content">Content:</label></td>
                          <td><textarea rows="15" cols="64" autofocus name="content" wrap="hard"><%= Session["content"] %></textarea></td>
                        </tr>
                        <tr>
                          <td><label for="Access">Choose Access Mode:</label></td>
                          <td>
                             <input type="radio" name="access" value="admin" checked />Administrater Mode
                             &nbsp;&nbsp;
                             <input type="radio" name="access" value="member" />Member Mode
                             &nbsp;&nbsp;
                             <input type="radio" name="access" value="anonymous">NonMember Mode
                          </td>
                        </tr>
                     </table>
                     <hr />
                    <button class="btn btn-success" type="submit" runat="server" onserverclick="Modify_Click">Modify</button>
                    <button class="btn btn-primary" type="button" onclick="history.go(-1);">Back</button>
            </div>
</asp:Content>
