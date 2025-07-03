<%@ Page Title="View Recipes" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ViewRecipes.aspx.cs" Inherits="CookingCommunityApp.Pages.ViewRecipes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>All Recipes</h2>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
    <br />

    <asp:GridView ID="gvRecipes" runat="server" AutoGenerateColumns="False" Width="100%" BorderStyle="Solid" BorderWidth="1px"
                  OnRowCommand="gvRecipes_RowCommand">
        <Columns>
            <asp:BoundField DataField="RecipeID" HeaderText="Recipe ID" />
            <asp:BoundField DataField="Title" HeaderText="Recipe Title" />
            <asp:BoundField DataField="Ingredients" HeaderText="Ingredients" />
            <asp:BoundField DataField="Method" HeaderText="Method" />
            <asp:BoundField DataField="AverageRating" HeaderText="Avg. Rating" />

            <asp:TemplateField HeaderText="Rate This">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlRating" runat="server">
                        <asp:ListItem Text="1" Value="1" />
                        <asp:ListItem Text="2" Value="2" />
                        <asp:ListItem Text="3" Value="3" />
                        <asp:ListItem Text="4" Value="4" />
                        <asp:ListItem Text="5" Value="5" />
                    </asp:DropDownList>
                    <asp:Button ID="btnRate" runat="server" Text="Rate" CommandName="Rate" CommandArgument='<%# Eval("RecipeID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
