<%@ Page Title="HomePage Manage Center" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="managehomepage.aspx.cs" Inherits="WebApplication1.managehomepage" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-sm-12">
       <H3>HomePage Management Center</H3>
       <hr />
        <p>Current User ID: <asp:Label ID="LabelSessionID" runat="server"></asp:Label></p>
        <hr />
        <p><a href="/dbmanager">ASPOracleManager</a></p>
        <p><a href="/membermanage.aspx">Member DataBase Management</a></p>
     </div>
</asp:Content>
