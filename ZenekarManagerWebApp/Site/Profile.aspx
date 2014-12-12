<%@ Page Title="Profilom" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ZenekarManagerWebApp.Site.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    E-mail cím:<br />
    <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
    <br />
    Név:<br />
    <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
    <br />
    Aktív tag:<asp:CheckBox ID="ActiveCheckBox" runat="server" />
    <br />
    Koncertre jár:<asp:CheckBox ID="ConcertCheckBox" runat="server" />
    <br />
    <br />
    Hangszerek:<br />
    <asp:ListBox ID="ListBox1" runat="server" Height="87px" SelectionMode="Multiple" Width="238px"></asp:ListBox>
    <br />
    <asp:Button ID="UpdateButton" runat="server" OnClick="UpdateButton_Click" Text="Frissít" />
    <br />
    <br />
    <asp:Label ID="CurrPassLabel" runat="server" Text="Jelenlegi jelszó:"></asp:Label>
    <br />
    <asp:TextBox ID="CurrPassTextBox" TextMode="Password" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="NewPassLabel" runat="server" Text="Új jelszó:"></asp:Label>
    <br />
    <asp:TextBox ID="NewPassTextBox" TextMode="Password" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="NewPassConfirmLabel" runat="server" Text="Új jelszó megerősítése:"></asp:Label>
    <br />
    <asp:TextBox ID="NewPassConfirmTextBox" TextMode="Password" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="PassChangeButton" runat="server" Text="Jelszó megváltoztatása" OnClick="PassChangeButton_Click" />
    <br />
    <asp:Label ID="PassReturnLabel" runat="server" Text=""></asp:Label>
    <br />
</asp:Content>
