<%@ Page Title="Member Info" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="memberinfo.aspx.cs" Inherits="WebApplication1.memberinfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="col-sm-12">
       <h3>Member Info </h3>
       <hr> 
        <table border=1>
         <tr>
            <td>ID:</td>
            <td><asp:Label ID="LabelSessionID" runat="server"></asp:Label></td>
         </tr>
         <tr>
            <td>First Name:</td>
            <td><asp:Label ID="LabelSessionFirstName" runat="server"></asp:Label></td>
         </tr>    
         <tr>
            <td>Last Name:</td>
            <td><asp:Label ID="LabelSessionLastName" runat="server"></asp:Label></td>
         </tr>    
         <tr>
            <td>Full Name:</td>
            <td><asp:Label ID="LabelSessionFullName" runat="server"></asp:Label></td>
         </tr>
         <tr>
            <td>Birthday:</td>
            <td><asp:Label ID="LabelSessionBirthday" runat="server"></asp:Label></td>
         </tr>   
         <tr>
            <td>Join Date:</td>
            <td><asp:Label ID="LabelSessionJoinDate" runat="server"></asp:Label></td>
         </tr>        
        </table>
     <hr>
     <button class="btn btn-success" type="button" onclick="location.href='modifymemberinfo.aspx'">Modify Member</button>            
     <button class="btn btn-danger"  type="button" onclick="location.href='deletememberinfo.aspx'">Delete Member</button>
 </div>
</asp:Content>
