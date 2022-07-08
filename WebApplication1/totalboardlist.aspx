<%@ Page Title="Board" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="totalboardlist.aspx.cs" Inherits="WebApplication1.totalboardlist" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-sm-12">
       <H3>Board <asp:Label ID="LabelMode" runat="server"></asp:Label></H3>
       <hr />
          <p>Current User ID: <asp:Label ID="LabelID" runat="server"></asp:Label></p>
          <p>Number of Boards: <asp:Label ID="BoardNumber" runat="server"></asp:Label></p>
          <hr />
          <p>
          <label>SEARCH BY TITLE:</label>
          <input type="text" name="searchtitle" />&nbsp;&nbsp;
          <button type="submit" class= "btn btn-primary" OnServerClick="SearchByTitle" runat="server">Search By Title</button>
          </p>
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
                <th>Delete</th>
              </tr>
          </thead>
          <tbody>
          <%
              List<WebApplication1.BoardDTO> boardlist = (List<WebApplication1.BoardDTO>)Session["totalboardlist_board"];
              for(int i=0; i< boardlist.Count; i++)
              {
          %>
             <tr> 
                 <td><%= boardlist[i].Serial %></td>
                 <td><a href="detailboard.aspx?serial=<%=boardlist[i].Serial %>"><%= boardlist[i].Title %></a>  </td> 
                 <td><%= boardlist[i].Savedate %></td>
                 <td><%= boardlist[i].Modifydate %></td>
                 <td><%= boardlist[i].Anonymous %></td>
                 <td><%= boardlist[i].Clicks %></td>
                 <td><a href="deleteboard.aspx?serial=<%= boardlist[i].Serial %>">Delete</a></td>
            </tr>
          <%
              }
          %>
            </tbody>
           </table>
     <hr />
    <button type="button" class="btn btn-primary" onclick="history.go(-1)">Back</button>
    <button type="button" class="btn btn-primary" onclick="location.href='totalboardlist.aspx'">Board Session Update</button>
    <button type="button" class="btn btn-success" onclick="location.href='writeboard.aspx'">Go To Write</button>
     </div>
</asp:Content>
