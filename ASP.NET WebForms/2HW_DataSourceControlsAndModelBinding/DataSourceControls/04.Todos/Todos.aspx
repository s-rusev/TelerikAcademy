<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Todos.aspx.cs" Inherits="_04.Todos.Todos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:EntityDataSource ID="EntityDataSourceCategories"
                runat="server" ConnectionString="name=TodosEntities"
                DefaultContainerName="TodosEntities" EnableFlattening="False"
                EntitySetName="Categories" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
            </asp:EntityDataSource>

        </div>

        <asp:ListBox ID="ListBoxCategories" runat="server"
            AutoPostBack="True" DataSourceID="EntityDataSourceCategories" DataTextField="Name"
            DataValueField="CategoryId"></asp:ListBox>
        <fieldset>
            <legend>Manage categories</legend>
            <asp:Label Text="Category name" runat="server" />
            <asp:TextBox runat="server" ID="TextBoxCategoryName" />
            <asp:LinkButton Text="Add category" runat="server" ID="ButtonAddCategory" OnClick="ButtonAddCategory_Click" />
            <br />
            <asp:LinkButton Text="Delete category" runat="server" ID="ButtonDeleteCategory" OnClick="ButtonDeleteCategory_Click" />
            <br />
            <asp:Label Text="Edit category name" runat="server" />
            <asp:TextBox runat="server" ID="TextBoxEditCategory" Text="Hello" />
            <asp:LinkButton Text="Edit category" runat="server" ID="ButtonEditCategory" OnClick="ButtonEditCategory_Click" />
        </fieldset>
        <asp:EntityDataSource ID="EntityDataSourceTodos" runat="server"
            ConnectionString="name=TodosEntities" DefaultContainerName="TodosEntities" EnableDelete="True"
            EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Todos"
            Include="Category"
            Where="it.CategoryId=@CategoryId">
            <WhereParameters>
                <asp:ControlParameter Name="CategoryId" Type="Int32" ControlID="ListBoxCategories" />
            </WhereParameters>
        </asp:EntityDataSource>


        <asp:GridView ID="GridViewTodos" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="TodoId" DataSourceID="EntityDataSourceTodos">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="TodoId" HeaderText="TodoId" ReadOnly="True" SortExpression="TodoId" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Body" HeaderText="Body" SortExpression="Body" />
                <asp:BoundField DataField="LastChangeDate" HeaderText="LastChangeDate" SortExpression="LastChangeDate" />
                <asp:BoundField DataField="Category.Name" HeaderText="Category" SortExpression="CategoryId" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
