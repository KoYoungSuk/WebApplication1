<%@ Page Title="ASPOracleManager Professional Mode" Language="C#" MasterPageFile="~/dbmanager/DBManager.Master" AutoEventWireup="true" CodeBehind="professional.aspx.cs" Inherits="WebApplication1.dbmanager.professional" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Professional Mode</h3>
    <hr />
    <p> DataBase Address: <%= Session["DB_URL"] %> </p>
    <p> DataBase ID: <%= Session["DB_ID"] %></p>
    <hr />
     <table>
        <tr>
          <td><label for="SQLCommand">SQL 명령문 입력</label></td>
        </tr>
        <tr>
            <td><textarea rows="10" cols="100" autofocus name="sqlcommand" wrap="hard"><%= (string)Session["SQLCommand"] %></textarea></td>
        </tr>
    </table>
    <button class="btn btn-primary" type="submit" OnServerClick="SQL_Click" runat="server">EXECUTE</button>
    <hr />
    <h3>Result</h3>
    <hr />
    <p><asp:Label ID="ExecuteLabelID" runat="server" /></p>
    <p>SQL Command:&nbsp;&nbsp; <%= (string)Session["SQLCommand"] %></p>
    <p>Degree(Number of Attributes): <asp:Label ID="DegreeLabelID" runat="server" /></p>
    <p>Cardinality(Number of Tuples): <asp:Label ID="CardinalityLabelID" runat="server" /></p>
    <p>Schema: Header   Instance: Content</p>
     <hr />
     <asp:GridView ID="DataBaseGridViewID" runat="server"></asp:GridView>
     <hr />
     <p><asp:Label ID="ExecuteStatusLabelID" runat="server" /></p>
     <hr />
     <button class="btn btn-primary" type="button" onclick="window.print()">Print</button>
     <button class="btn btn-primary" type="button" onclick="history.go(-1);">Back</button>
     <button class="btn btn-primary" type="submit" OnServerClick="BackManager_Click" runat="server">Back to ASPOracleManager Page</button>
     <button class="btn btn-primary" type="submit" OnServerClick="BackMain_Click" runat="server">Back to Main Page</button>
     <hr />
</asp:Content>
  
