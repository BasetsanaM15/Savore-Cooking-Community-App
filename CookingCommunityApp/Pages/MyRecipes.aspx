<%@ Page Title="My Recipes" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="MyRecipes.aspx.cs" Inherits="CookingCommunityApp.Pages.MyRecipes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>My Submitted Recipes</h2>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
    <br />

    <asp:GridView ID="gvMyRecipes" runat="server" AutoGenerateColumns="False" Width="100%" BorderStyle="Solid" BorderWidth="1px">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Ingredients" HeaderText="Ingredients" />
            <asp:BoundField DataField="Method" HeaderText="Method" />
            <asp:BoundField DataField="DateSubmitted" HeaderText="Date Submitted" />
        </Columns>
    </asp:GridView>

</asp:Content>
