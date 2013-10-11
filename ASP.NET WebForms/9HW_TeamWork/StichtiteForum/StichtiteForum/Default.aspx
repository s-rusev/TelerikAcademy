<%@ Page Title="Home Page" Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="StichtiteForum._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <asp:UpdatePanel runat="server" ID="UpdatePanelPosts">
            <ContentTemplate>
                <asp:ListView ID="PostsList"
                    runat="server"
                    ItemType="StichtiteForum.Models.Post"
                    SelectMethod="PostsList_GetData">
                    <LayoutTemplate>
                        <div class="well span8">
                            <asp:LoginView runat="server">
                                <LoggedInTemplate>
                                    <a href="EditPost.aspx" class="btn btn-primary pull-right">Add New Post</a>
                                </LoggedInTemplate>
                            </asp:LoginView>
                            <table class="table table-hover">
                                <colgroup>
                                    <col style="width: 50%" />
                                    <col style="width: 15%" />
                                    <col style="width: 10%" />
                                    <col style="width: 25%" />
                                </colgroup>
                                <thead>
                                    <tr>
                                        <th>Post</th>
                                        <th class="cell-center">Author</th>
                                        <th class="cell-center">Comments</th>
                                        <th>Last Comment</th>
                                    </tr>
                                </thead>
                                <tbody id="itemPlaceholder" runat="server"></tbody>
                            </table>
                            <asp:DataPager ID="DataPagerComments" runat="server" PageSize="5">
                                <Fields>
                                    <asp:NextPreviousPagerField ShowFirstPageButton="True"
                                        ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ShowLastPageButton="True"
                                        ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <a href="Post.aspx?id=<%# Item.PostId%>"><%#: Item.Title%></a>
                            </td>
                            <td class="cell-center"><%#: Item.AspNetUser.UserName %></td>
                            <td class="cell-center"><%# Item.Comments.Count %></td>
                            <td>by <%#: Item.Comments.Count > 0 ? Item.Comments.OrderByDescending(c => c.CommentDate).FirstOrDefault().AspNetUser.UserName : "......" %>
                                <br />
                                on <%#: Item.Comments.Count > 0 ? Item.Comments.OrderByDescending(c => c.CommentDate).FirstOrDefault().CommentDate.ToString(): "......" %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>


        <asp:ListView ID="CategoriesList"
            runat="server"
            ItemType="StichtiteForum.Models.Category"
            SelectMethod="CategoriesList_GetData">
            <LayoutTemplate>
                <div class="well span3">
                    <h3>Categories</h3>
                    <ul id="itemPlaceholder" runat="server"></ul>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <li>
                    <h4><a href="PostsByCategory.aspx?id=<%# Item.CategoryId %>"><%#: Item.Title%></a></h4>
                </li>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
