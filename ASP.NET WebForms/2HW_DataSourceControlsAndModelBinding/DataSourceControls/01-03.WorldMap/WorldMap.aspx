<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorldMap.aspx.cs" Inherits="_01_03.WorldMap.WorldMap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:EntityDataSource ID="EntityDataSourceContinents" runat="server"
            ConnectionString="name=WorldMapEntities" DefaultContainerName="WorldMapEntities"
            EnableDelete="True" EnableFlattening="False" EnableInsert="True"
            EnableUpdate="True" EntitySetName="Continents">
        </asp:EntityDataSource>

        <asp:ListBox ID="ListBoxContinents" runat="server"
            DataSourceID="EntityDataSourceContinents" DataTextField="Name"
            DataValueField="ContinentId" AutoPostBack="true"></asp:ListBox>

        <fieldset>
            <legend>Adding continent form</legend>
            <asp:TextBox ID="textBoxContinent" runat="server"></asp:TextBox>
            <asp:LinkButton ID="btnAddContinent" runat="server" OnClick="btnAddContinent_Click">Add Continent</asp:LinkButton>
            <br />
            <asp:LinkButton ID="btnDeleteContinent" runat="server" OnClick="btnDeleteContinent_Click">Delete Continent</asp:LinkButton>
        </fieldset>

        <asp:EntityDataSource ID="EntityDataSourceCountries"
            runat="server" ConnectionString="name=WorldMapEntities"
            DefaultContainerName="WorldMapEntities" EnableDelete="True"
            EnableFlattening="False" EnableInsert="True" EnableUpdate="True"
            EntitySetName="Countries" Include="Continent, Language"
            Where="it.ContinentId=@ContinentId">
            <WhereParameters>
                <asp:ControlParameter Name="ContinentId" Type="Int32" ControlID="ListBoxContinents" />
            </WhereParameters>
        </asp:EntityDataSource>
        <asp:EntityDataSource ID="EntityDataSourceLanguages" runat="server" ConnectionString="name=WorldMapEntities" DefaultContainerName="WorldMapEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Languages">
        </asp:EntityDataSource>
        <asp:GridView ID="GridViewCountries" runat="server"
            AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" DataKeyNames="CountryId"
            DataSourceID="EntityDataSourceCountries" ItemType="_01_03.WorldMap.Country">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="ButtonEditCountry" CommandName="Edit" Text="Edit" runat="server" />
                        <asp:Button ID="ButtonDeleteCountry" CommandName="Delete" Text="Delete" runat="server" />
                        <asp:Button ID="ButtonSelectCountry" CommandName="Select" Text="Select" runat="server" />
                        <td>
                            <%#:Item.Name %>
                        </td>
                        <td>
                            <%#:Item.Language.Language1 %>
                        </td>
                        <td>
                            <%#:Item.Population %>
                        </td>
                        <td>
                            <%#:Item.Continent.Name %>
                        </td>
                        <td>
                            <asp:Image ID="FlagImage" runat="server" Width="36px" ImageUrl='<%# GetImage(Item.Flag) %>' />
                        </td>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="ButtonUpdateCountry" CommandName="Update" Text="Update" runat="server" OnClick="ButtonUpdateCountry_Click" />
                        <asp:Button ID="ButtonCancelCountry" CommandName="Cancel" Text="Cancel" runat="server" />
                        <td>
                            <asp:TextBox ID="TextBoxCountryName" runat="server" Text="<%#:BindItem.Name %>" />
                        </td>
                        <td>
                            <asp:DropDownList DataSourceID="EntityDataSourceLanguages"
                                runat="server" ID="DropDownListCountryLanguage" DataValueField="LanguageId" DataTextField="Language1">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxCountryPopulation" runat="server" Text="<%#:BindItem.Population %>" />
                        </td>
                        <td>
                            <asp:FileUpload ID="UploadImage" runat="server" />
                            <asp:Button ID="ButtonAddFlag" Text="Add" runat="server" OnClick="UploadImage_Click" />
                        </td>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <fieldset>
            <legend>Adding country form</legend>
            <asp:Label runat="server">Country name</asp:Label>
            <asp:TextBox ID="textBoxCountryName" runat="server"></asp:TextBox>
            <asp:Label runat="server">Country Language</asp:Label>
            <asp:DropDownList ID="DropDownListCountryLanguage" DataSourceID="EntityDataSourceLanguages"
                DataValueField="LanguageId" DataTextField="Language1" runat="server">
            </asp:DropDownList>
            <asp:Label runat="server">Country population</asp:Label>
            <asp:TextBox ID="textBoxCountryPopulation" runat="server"></asp:TextBox>
            <asp:LinkButton ID="LinkButtonAddCountry" runat="server" OnClick="LinkButtonAddCountry_Click">Add Country</asp:LinkButton>
        </fieldset>

        <asp:EntityDataSource ID="EntityDataSourceTowns" runat="server"
            ConnectionString="name=WorldMapEntities" DefaultContainerName="WorldMapEntities"
            EnableDelete="True" EnableFlattening="False" EnableInsert="True"
            EnableUpdate="True" EntitySetName="Towns" Include="Country"
            Where="it.CountryId=@CountryId">
            <WhereParameters>
                <asp:ControlParameter Name="CountryId" Type="Int32"
                    ControlID="GridViewCountries" />
            </WhereParameters>
        </asp:EntityDataSource>

        <asp:ListView ID="ListViewTowns" runat="server"
            DataSourceID="EntityDataSourceTowns" DataKeyNames="TownId"
            InsertItemPosition="LastItem">
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:Label ID="TownIdLabel1" runat="server" Text='<%#: Eval("TownId") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%#: Bind("Name") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                    </td>

                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="TownIdLabel" runat="server" Text='<%#: Eval("TownId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%#: Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%#: Eval("Population") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%#: Eval("Country.Name") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr runat="server" style="">
                                    <th runat="server"></th>
                                    <th runat="server">TownId</th>
                                    <th runat="server">Name</th>
                                    <th runat="server">Population</th>
                                    <th runat="server">Country</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="TownIdLabel" runat="server" Text='<%#: Eval("TownId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%#: Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%#: Eval("Population") %>' />
                    </td>

                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%#: Eval("Country.Name") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
            <InsertItemTemplate>
            </InsertItemTemplate>
        </asp:ListView>
        <fieldset>
            <legend>Adding town form</legend>
            <asp:Label runat="server">Town name</asp:Label>
            <asp:TextBox ID="TextBoxTownName" runat="server"></asp:TextBox>
            <asp:Label runat="server">Town population</asp:Label>
            <asp:TextBox ID="TextBoxTownPopulation" runat="server"></asp:TextBox>
            <asp:LinkButton ID="LinkButtonAddTown" runat="server" OnClick="LinkButtonAddTown_Click">Add Town</asp:LinkButton>
        </fieldset>

    </form>
</body>
</html>
