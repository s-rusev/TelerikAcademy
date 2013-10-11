<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_02Employees.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView runat="server" ID="GridViewEmployeeName" AllowPaging="true" AutoGenerateColumns="False">
            <Columns>
                <asp:HyperLinkField DataTextField="LastName" HeaderText="Last Name" 
                    DataNavigateUrlFormatString="EmpDetails.aspx?id={0}" DataNavigateUrlFields="EmployeeID"/>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
