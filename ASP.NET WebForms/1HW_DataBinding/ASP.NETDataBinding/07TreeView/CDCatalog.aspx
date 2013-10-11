<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CDCatalog.aspx.cs" Inherits="_07TreeView.CDCatalog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TreeView runat="server" ID="TreeViewCatalog" DataSourceID="source"
            OnSelectedNodeChanged="TreeViewCatalog_SelectedNodeChanged">
            <DataBindings>
                <asp:TreeNodeBinding DataMember="CD" TextField="#InnerText"/>
                <asp:TreeNodeBinding DataMember="TITLE" TargetField="#InnerText" />
                <asp:TreeNodeBinding DataMember="COUNTRY" TargetField="#InnerText" />
                <asp:TreeNodeBinding DataMember="COMPANY" TargetField="#InnerText" />
                <asp:TreeNodeBinding DataMember="PRICE" TargetField="#InnerText" />
                <asp:TreeNodeBinding DataMember="YEAR" TargetField="#InnerText" />
                <asp:TreeNodeBinding DataMember="ARTIST" TextField="#InnerText" />
            </DataBindings>
        </asp:TreeView>
        <asp:XmlDataSource ID="source" runat="server" DataFile="~/CDCatalog.xml"></asp:XmlDataSource>
        <asp:Label ID="innerXml" runat="server"></asp:Label>
    </form>
</body>
</html>
