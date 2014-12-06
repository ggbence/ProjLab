<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ZenekarManagerWebApp.Account.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            Kuldo:
            <asp:Label ID="KuldoLabel" runat="server" Text='<%# Eval("Kuldo") %>' />
            <br />
            Uzenet:
            <asp:Label ID="UzenetLabel" runat="server" Text='<%# Eval("Uzenet") %>' />
            <br />
            Cimzett:
            <asp:Label ID="CimzettLabel" runat="server" Text='<%# Eval("Cimzett") %>' />
            <br />
            Datum:
            <asp:Label ID="DatumLabel" runat="server" Text='<%# Eval("Datum") %>' />
            <br />
            Uzenet_id:
            <asp:Label ID="Uzenet_idLabel" runat="server" Text='<%# Eval("Uzenet_id") %>' />
            <br />
            Ervenyesseg:
            <asp:Label ID="ErvenyessegLabel" runat="server" Text='<%# Eval("Ervenyesseg") %>' />
            <br />
<br />
        </ItemTemplate>
    </asp:DataList>
    <asp:Button ID="SendMessageButton" runat="server" Text="Üzenet Küldése" Width="166px" OnClick="SendMessageButton_Click" />
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="Uzenet" DataValueField="Uzenet_id">
    </asp:DropDownList>
    <br />
    <asp:Button ID="DeleteButton" runat="server" Text="Üzenet Törlése" OnClick="DeleteButton_Click" />
    </asp:Content>
