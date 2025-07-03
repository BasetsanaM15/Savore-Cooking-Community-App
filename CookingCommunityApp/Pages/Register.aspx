<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CookingCommunityApp.Pages.Register" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>User Registration</h2>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    <br /><br />

    <table>
        <tr>
            <td>Email:</td>
            <td><asp:TextBox ID="txtEmail" runat="server" /></td>
        </tr>
        <tr>
            <td>Password:</td>
            <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /></td>
        </tr>
        <tr>
            <td>Full Name:</td>
            <td><asp:TextBox ID="txtFullName" runat="server" /></td>
        </tr>
        <tr>
            <td>Secret Question:</td>
            <td><asp:TextBox ID="txtQuestion" runat="server" /></td>
        </tr>
        <tr>
            <td>Secret Answer:</td>
            <td><asp:TextBox ID="txtAnswer" runat="server" /></td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            </td>
        </tr>
    </table>

    <p>Already have an account? 
   <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/Pages/Login.aspx">Login here</asp:HyperLink>
</p>

</asp:Content>

