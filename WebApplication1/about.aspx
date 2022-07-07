<%@ Page Title="About" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="WebApplication1.about" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-sm-12">
       <H1>About</H1>
       <hr>
       <p>First Updated: September 20, 2021 </p>
       <p>Last Updated: Monday, May 16 2022 </p>
       <p>This is not copyrighted. But don't use this illegally.</p>
       <p>But Some Context are copyrighted to Other. especially Oracle and Microsoft.</p>
       <p>Oracle, Oracle DataBase are trademark of Oracle Corporation. </p>
       <p>Microsoft, Microsoft Windows, Microsoft Windows Server, .NET, ASP.NET, ASP, .NET Framework, IIS, Microsoft Visual Studio are trademark of Microsoft Corporation.</p>
       <%
           if (Session["LOGIN_ID"] != null)
           {
       %>
       <p>Web Server: Microsoft IIS(Internet Information Service) 10.0 </p>
       <p>Web Framework/.NET Framework: ASP.NET(Active Server Page .NET) 4.8/Microsoft .NET Framework 4.0 </p>
       <p>Other Framework: CSS Framework(Bootstrap 4/W3.CSS)</p>
       <p>Server Operating System: <asp:Label ID="OSID" runat="server" /></p>
       <p>DataBase: Oracle DataBase 18c Express Edition </p>
       <p>
       <a href="https://www.dnsever.com" target="dnsever"><img src="https://banner.dnsever.com/dnsever-banner_170x35.gif" border="0" alt="DNS server, DNS service"></a>
       </p>
       <hr />
       <p><a href="https://github.com/KoYoungSuk/WebApplication1">Source Code(GitHub)</a></p>
       <p><a href="/download/WebApplication1.zip">Source Code(Local)</a></p>
       <%
           }
       %>
       <hr>
       <button class="btn btn-primary" onclick="history.go(-1);">Back</button>
     </div>
</asp:Content>
