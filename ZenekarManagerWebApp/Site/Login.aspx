<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ZenekarManagerWebApp.Site.LoginForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="E-mail:"></asp:Label>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
    
        &nbsp;
    
    </div>
        <p>
            <asp:TextBox ID="EmailBox" runat="server"></asp:TextBox>
            <asp:TextBox ID="PasswordBox" TextMode="password" runat="server"></asp:TextBox>
        </p>
        <p>
    
        <asp:Button ID="LoginButton" runat="server" OnClick="Button1_Click" Text="Login" />
    
        </p>
        <p>
    
            <asp:Label ID="tesztLabel" runat="server"></asp:Label>
        </p>
        <p>
    
            &nbsp;</p>
</asp:Content>
