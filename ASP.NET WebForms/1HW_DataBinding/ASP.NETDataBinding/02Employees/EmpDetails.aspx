<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpDetails.aspx.cs" Inherits="_02Employees.EmpDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:DetailsView runat="server" ID="DetailViewEmployee" ></asp:DetailsView>
          <asp:Button  ID="BackButton" Text="Go Back" OnClientClick="JavaScript:window.history.back(1);return false;" runat="server"/>
    </form>
</body>
</html>
