<%@ Page Title="Modify Member" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="modifymemberinfo.aspx.cs" Inherits="WebApplication1.modifymemberinfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="col-sm-12">
       <h3>Modify Member Info </h3>
       <h6>NOTICE: After modify member, You must login again.</h6>
       <hr> 
        <table >
         <tr>
            <td>ID:</td>
            <td><input type="text" name="id" value='<%= Session["LOGIN_ID"] %>' readonly /></td>
         </tr>
         <tr>
            <td>New Password:</td>
            <td><input type="password" name="password" required /></td>
         </tr>
         <tr>
             <td>New Password Confirmed</td>
             <td><input type="password" name="cpassword" required /></td>
         </tr>
         <tr>
            <td>First Name:</td>
            <td><input type="text" name="firstname" value= '<%= Session["FIRST_NAME"] %>' /></td>
         </tr>    
         <tr>
            <td>Last Name:</td>
            <td><input type="text" name="lastname" value= '<%= Session["LAST_NAME"] %>' /></td>
         </tr>    
         <tr>
            <td>Birthday:</td>
            <td><input type="text" name="birthday" value= '<%= Session["BIRTHDAY"] %>' /></td>
         </tr>      
        </table>
     <hr>
     <button class="btn btn-success" type="submit" OnServerClick="Modify_Click" runat="server">Modify</button>
     <button class="btn btn-primary" type="button" onclick="history.go(-1);">Back</button>
     <button class="btn btn-primary" type="button" onclick="location.href='default.aspx'">Back To Main Page</button>
 </div>
</asp:Content>
