<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ZenekarManagerWebApp.Site.LoginForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    
    
        <asp:Table ID="Table1" runat="server" Width="202px">
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="Label1" runat="server" Text="E-mail:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell><asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:TextBox ID="EmailBox" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell><asp:TextBox ID="PasswordBox" TextMode="password" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <p>
        <asp:Button ID="LoginButton" runat="server" OnClick="Button1_Click" Text="Login" />
    
        </p>
        <p>
            <asp:Button ID="GoogleLoginButton" runat="server" OnClick="GoogleLoginButton_Click" Text="Google login" />
    
        </p>
        <p>
    
            <asp:Label ID="tesztLabel" runat="server"></asp:Label>
        </p>
</div>
</asp:Content>
