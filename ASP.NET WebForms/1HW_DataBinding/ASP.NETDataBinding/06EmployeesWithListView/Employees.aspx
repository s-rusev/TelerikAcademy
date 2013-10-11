<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_06EmployeesWithListView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ListView runat="server" ID="ListViewEmployee">
            <LayoutTemplate>
                <h3>Employees</h3>
                <table>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                 <tr>
                    <td>Name:</td>
                    <td><%#: Eval("FirstName") + " " + Eval("LastName") %></td>
                </tr>
                 <tr>
                    <td>Title:</td>
                    <td><%#: Eval("Title")%></td>
                </tr>
                <tr>
                    <td>TitleOfCourtesy:</td>
                    <td><%#: Eval("TitleOfCourtesy")%></td>
                </tr>
                <tr>
                    <td>BirthDate:</td>
                    <td><%#: Eval("BirthDate")%></td>
                </tr>
                <tr>
                    <td>HireDate:</td>
                    <td><%#: Eval("HireDate")%></td>
                </tr>
                <tr>
                    <td>Address:</td>
                    <td><%#: Eval("Address")%></td>
                </tr>
                <tr>
                    <td>City:</td>
                    <td><%#: Eval("City")%></td>
                </tr>
                    <tr>
                <td>Region:</td>
                <td><%#: Eval("Region")%></td>
                </tr>
                        <tr>
                    <td>PostalCode:</td>
                    <td><%#: Eval("PostalCode")%></td>
                </tr>
                        <tr>
                    <td>Country:</td>
                    <td><%#: Eval("Country")%></td>
                </tr>
                        <tr>
                    <td>HomePhone:</td>
                    <td><%#: Eval("HomePhone")%></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </form>
</body>
</html>
