<%@ Page Title="Üzenet Küldése" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="ZenekarManagerWebApp.Site.SendMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Címzett:<br />
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Users_nev" DataValueField="Users_id">
    </asp:DropDownList>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getUsers" TypeName="ZenekarManagerWebApp.Site.UserList"></asp:ObjectDataSource>
    <br />
    Üzenet:<br />
    <asp:TextBox ID="MessageBox" runat="server" Height="232px" TextMode="MultiLine" Width="458px"></asp:TextBox>
    <br />
    <asp:Button ID="SendMessageButton" runat="server" OnClick="SendMessageButton_Click" Text="Üzenet Elküldése" />
</asp:Content>
