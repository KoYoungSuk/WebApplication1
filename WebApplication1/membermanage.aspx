<%@ Page Title="Member Management Center" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="membermanage.aspx.cs" Inherits="WebApplication1.membermanage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div class= "col-sm-12">
              <h3>Member Management Center</h3>
              <hr />
              Delete ID: <input type="text" name="delete_id" />&nbsp;&nbsp;
              <button class="btn btn-danger" OnServerClick="DeleteMember_Click" runat="server">Delete</button>
              <hr />
              <asp:GridView ID="TotalMemberGridView" runat="server">
              </asp:GridView>
              <hr />
              <button class="btn btn-primary" onclick="location.href='membermanage.aspx'">Refresh</button>
              <button class="btn btn-primary" onclick="history.go(-1);">Back</button>
          </div>
</asp:Content>
