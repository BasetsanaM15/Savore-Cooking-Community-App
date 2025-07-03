<%@ Page Title="Submit Recipe" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="SubmitRecipe.aspx.cs" Inherits="CookingCommunityApp.Pages.SubmitRecipe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Submit a New Recipe</h2>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    <br /><br />

    <table>
        <tr>
            <td>Title:</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="300px" />
            </td>
        </tr>
        <tr>
            <td>Ingredients:</td>
            <td>
                <asp:TextBox ID="txtIngredients" runat="server" TextMode="MultiLine" Rows="4" Columns="50" />
            </td>
        </tr>
        <tr>
            <td>Method:</td>
            <td>
                <asp:TextBox ID="txtMethod" runat="server" TextMode="MultiLine" Rows="6" Columns="50" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit Recipe" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>

    <p>
    <asp:HyperLink ID="lnkViewRecipes" runat="server" NavigateUrl="~/Pages/ViewRecipes.aspx">View All Recipes</asp:HyperLink> |
    <asp:HyperLink ID="lnkMyRecipes" runat="server" NavigateUrl="~/Pages/MyRecipes.aspx">My Recipes</asp:HyperLink>
</p>

</asp:Content>
