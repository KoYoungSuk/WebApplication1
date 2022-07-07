<%@ Page Title="Write Board" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="writeboard.aspx.cs" Inherits="WebApplication1.writeboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="col-sm-12">
                <h1>Write Board</h1>
                <hr />
                    <table>
                        <tr>
                            <td><p><label for="title">Title:</label></p></td>
                            <td><p><input type="text" name="title" style="width:500px;" required /></p></td>
                        </tr>
                        <tr>
                            <td><p><label for="ID">User ID:</label></p></td>
                            <td><p><input type="text" name="id" value="<%= Session["LOGIN_ID"] %>" style="width:500px;" readonly /></p></td>
                        </tr>
                        <tr>
                            <td><p><label for="content">Content:</label></p></td>
                            <td><p><textarea rows="15" cols="64" autofocus name="content" wrap="hard"></textarea></p></td>
                        </tr>
                        <tr>
                           <td><p><label for="anonymous">Choose Access Mode</label></p></td>
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
                    <button class="btn btn-success" type="submit" OnServerClick="Post_Board_Click" runat="server">Post Board</button>
                    <button class="btn btn-primary" type="button" onclick="history.go(-1);">Back</button>
            </div>
</asp:Content>
