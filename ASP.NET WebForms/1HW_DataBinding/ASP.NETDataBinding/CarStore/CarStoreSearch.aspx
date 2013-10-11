<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarStoreSearch.aspx.cs" Inherits="CarStore.CarStoreSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DropDownList runat="server" ID="ProducerDropDown" OnSelectedIndexChanged="Change_Models" AutoPostBack="true">
        </asp:DropDownList>

        <asp:DropDownList runat="server" ID="ModelDropDown" AutoPostBack="true"></asp:DropDownList>

        <asp:CheckBoxList runat="server" ID="CheckBoxListExtras"/>

        <asp:RadioButtonList runat="server" ID="RadioButtonsListEngines"></asp:RadioButtonList>
            
        <asp:Button runat="server" ID="ButtonSubmit" Text="Submit" OnClick="Show_Info"/>

        <asp:Literal ID="SubmitInfo" runat="server"></asp:Literal>
    </form>
</body>
</html>
