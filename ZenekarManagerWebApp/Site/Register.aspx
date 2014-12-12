<%@ Page Title="Regisztráció" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ZenekarManagerWebApp.Site.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>E-mail cím:</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="EmailTextBox" runat="server" Height="26px" Width="161px"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Név:</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="NameTextBox" runat="server" Height="26px" Width="161px"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Jelszó:</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="PwTextBox" runat="server" Height="26px" Width="161px" TextMode="Password"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Jelszó megerősítése:</asp:TableCell>
            <asp:TableCell><asp:TextBox ID="PwConfirmTextBox" runat="server" Height="26px" Width="161px" TextMode="Password"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Button ID="RegisterButton" runat="server" Text="Regisztrál" OnClick="RegisterButton_Click" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="SuccessfulLabel" runat="server"></asp:Label></asp:TableCell>
        </asp:TableRow>

    </asp:Table>
    
</asp:Content>
