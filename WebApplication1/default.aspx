<%@ Page Title="Main Page" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication1._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
   <div class="col-md-6">
     <h2> Welcome to MyBlog! </h2>
     <hr />
     <h5> This Web Site is Second Server.  </h5>
     <h5> <a href="https://home.yspersonal.com">Main Server</a> </h5>
     <h5> <a href="https://blog.naver.com/vheh5678">Naver Blog(Neighbor Only)</a></h5>
   </div>
   <div class="col-md-6">
     <h2>Why I make this? </h2>
     <hr />
     <h5>Hmm.........</h5>
     <h5><a href="whyimakethis.aspx">Maybe Here?</a></h5>
  </div>
</div>
<hr />
 <div class="row">
  <div class="col-md-12">
  <h2>Latest Update on Board</h2>
  <hr />
  <table>
     <thead>
         <tr>
           <th>Number</th>
           <th>Title</th>
           <th>Save Date</th>
           <th>Modify Date</th>
           <th>Access</th>
           <th>Clicks</th>
         </tr>
     </thead>
     <tbody>
            <%
                List<WebApplication1.BoardDTO> boardlist = (List<WebApplication1.BoardDTO>)Session["totalboardlist_default"];
                for(int i = 0; i < boardlist.Count; i++)
                {
            %>
             <tr> 
                 <td><%= boardlist[i].Serial %></td>
                 <td><a href="detailboard.aspx?serial=<%=boardlist[i].Serial%>"><%= boardlist[i].Title %></a>  </td> 
                 <td><%= boardlist[i].Savedate %></td>
                 <td><%= boardlist[i].Modifydate %></td>
                 <td><%= boardlist[i].Anonymous %></td>
                 <td><%= boardlist[i].Clicks %></td>
            </tr>
            <%  
            }
            %>
     </tbody>
  </table>
  </div>
 </div>
<hr />
</asp:Content>
