<%@ Page Title="Sign up" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="WebApplication1.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
  <div class="col-sm-12">
<H2> Sign-up Menu. </H2>
<hr>
<p> if you use this website perfectly,  you need to make your account. </p>
<p> you need to type id, password, confirmed password to make your account. </p>
<p>  
But typing your birthday your name(First name, Last name)  is optional. 
</p>
<p>Birthday: for example: 1999-12-31 or 2000-01-01 </p>
<hr>
<table>
   <thead>
     <tr>
       <td><label for="id"><b>ID:</b></label></td>
       <td><input type="text" name="id_signup" class="form-controls mr-sm-2" placeHolder="ID" required /></td>
     </tr>
     <tr>
       <td><label for="password"><b>Password:</b></label></td>
       <td><input type="password" name="password_signup" class="form-controls mr-sm-2" placeholder="Password" required /></td>
     </tr>
     <tr>
      <td><label for="password"><b>Confirmed Password:</b></label></td>
      <td><input type="password" name="cpassword_signup" class="form-controls mr-sm-2" placeholder="Confirmed Password" required /></td>
     </tr>
     <tr>
       <td><label for="first_name"><b>First Name(optional):</b></label></td>
       <td><input type="text" name="firstname_signup" class="form-controls mr-sm-2" placeholder="First Name"  /></td>
     </tr>
     <tr>
      <td><label for="last_name"><b>Last Name(optional):</b></label></td>
      <td><input type="text" name="lastname_signup" class="form-controls mr-sm-2" placeholder="Last Name"  /></td>
     </tr>  
     <tr>
     <td> <label for="birthday"><b> Your Birthday(optional/YYYY-MM-DD): </b></label> </td>
     <td> <input type="text" name="birthday_signup" class="form-controls mr-sm-2" placeholder="Birthday(YYYY-MM-DD)" /></td>
     </tr>
   </thead>
</table>
<hr>
 <button class="btn btn-success" type="submit" OnServerClick="Signup_Click" runat="server"> Sign up </button>
 <button class="btn btn-warning" type="button" onclick="location.href='./default.aspx' "> Back to Main Page </button>
</div>
</div>
</asp:Content>
