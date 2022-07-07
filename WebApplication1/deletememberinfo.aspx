<%@ Page Title="Delete Member" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="deletememberinfo.aspx.cs" Inherits="WebApplication1.deletememberinfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                 <div class="col-sm-12">
                       <H3> Delete Member Information </H3>
                       <hr>
                         <table border="1">           
                         <tr>
                         <td>ID:</td>
                         <td><%= Session["LOGIN_ID"] %></td>
                         </tr>  
                         <tr>
                         <td>First Name:</td>
                          <td><%= Session["FIRST_NAME"] %></td>
                         </tr>    
                          <tr>
                         <td>Last Name:</td>
                          <td><%=Session["LAST_NAME"] %></td>
                        </tr> 
                           <tr>
                         <td>Full Name:</td>
                          <td><%=Session["FULL_NAME"] %></td>
                           </tr>   
                        <tr>
                         <td>Birthday:</td>
                         <td><asp:Label ID="BirthdayLabelID_Delete" runat="server" /></td>
                        </tr>   
                        <tr>
                         <td>Join Date:</td>
                         <td><asp:Label ID="JoinDateLabelID_Delete" runat="server" /></td>
                        </tr>        
                        </table>
                         <p></p>
                         <p>If you click Delete Button, this Member is Deleted. Continue? </p>
                         <button class="btn btn-success" type="submit" OnServerClick="Delete_Click" runat="server">Yes!, Delete </button>
                         <button class="btn btn-success" type="button" onclick="location.href='default.aspx'">NO! Back to Main Page</button>
                         <button class="btn btn-success" type="button" onclick="history.go(-1)">NO! Back</button>
                 </div>
</asp:Content>
