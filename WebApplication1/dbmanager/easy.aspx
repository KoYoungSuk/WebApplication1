<%@ Page Title="ASPOracleManager Professional Mode" Language="C#" MasterPageFile="~/dbmanager/DBManager.Master" AutoEventWireup="true" CodeBehind="easy.aspx.cs" Inherits="WebApplication1.dbmanager.easy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Easy Mode</h3>
    <hr />
    <h6>SQL 명령문이 아닌 버튼을 통해 데이터베이스 연산을 수행할 수 있음. </h6>
    <h6>사용 가능한 연산: DML: 테이블 조회(select), 테이블 삭제(delete) </h6>
    <h6>테이블을 삭제할때는 식별자의  속성과 값을 반드시 입력해야 합니다. </h6>
    <h6> DataBase Address: <%= Session["DB_URL"] %> </h6>
    <h6> DataBase ID: <%= Session["DB_ID"] %></h6>
    <hr />
     <table>
        <tr>
          <td><label for="SQLCommand">Tablename:</label></td>
          <td><input type="text" name="tablename"  value="<%= Session["tablename"] %>" required /></td>
        </tr>
        <tr>
          <td><label for="SQLCommand">Attribute:</label></td>
          <td><input type="text" name="attribute" value="<%= Session["attribute"] %>"/></td>
        </tr>
         <tr>
           <td><label for="SQLCommand">Value:</label></td>
           <td><input type="text" name="value" value="<%= Session["value"] %>" /></td>
         </tr>
         <tr>
           <td><label for="SQLCommand">Mode(DML):</label></td>
           <td><input type="radio" name="mode" value="select" checked />Select</td>
           <td><input type="radio" name="mode" value="delete"  />Delete</td>
         </tr>
    </table>
    <button class="btn btn-primary" type="submit" OnServerClick="SQL_Click" runat="server">EXECUTE</button>
    <hr />
    <h3>Result</h3>
    <hr />
    <p><asp:Label ID="ExecuteLabelID" runat="server" /></p>
    <p>SQL Command:&nbsp;&nbsp; <%= (string)Session["tablename"] %></p>
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
  
