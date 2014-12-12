﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ZenekarManagerWebApp.Site.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="MultiMessageView" runat="server">
        <asp:ListView ID="ListView2" OnSelectedIndexChanging="ListView2_SelectedIndexChanging" OnSelectedIndexChanged="ListView2_SelectedIndexChanged" DataKeyNames="ID" runat="server" EnablePersistedSelection="True">
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td>
                        <asp:Label ID="Jogkor_idLabel" runat="server" Text='<%# Eval("sender") %>' />
                    </td>
                    <td>
                        <asp:Label ID="HangszerekLabel" runat="server" Text='<%# Eval("date") %>' />
                    </td>
                    <td>
                        <asp:Button ID="SelectButton" runat="server" Text="olvasás" CommandName="Select" />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <SelectedItemTemplate>
               <tr style="background-color:#ff6a00;">
                    <td>
                        <asp:Label ID="Jogkor_idLabel" runat="server" Text='<%# Eval("sender") %>' />
                    </td>
                    <td>
                        <asp:Label ID="HangszerekLabel" runat="server" Text='<%# Eval("date") %>' />
                    </td>
                    <td>
                        <asp:Button ID="SelectButton" runat="server" Text="olvasás" CommandName="Select" />
                    </td>
                </tr>
            </SelectedItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                        <asp:Label ID="Jogkor_idLabel" runat="server" Text='<%# Eval("sender") %>' />
                    </td>
                    <td>
                        <asp:Label ID="HangszerekLabel" runat="server" Text='<%# Eval("date") %>' />
                    </td>
                    <td>
                        <asp:Button ID="SelectButton" runat="server" Text="olvasás" CommandName="Select" />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                    <th runat="server">Küldő</th>
                                    <th runat="server">Dátum</th>
                                    <th runat="server">Olvasás</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;"></td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
    <asp:Button ID="SendMessageButton" runat="server" Text="Üzenet Küldése" Width="166px" OnClick="SendMessageButton_Click" />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="Uzenet" DataValueField="Uzenet_id" Width="242px">
        </asp:DropDownList>
        <br />
        <asp:Button ID="DeleteButton" runat="server" OnClick="DeleteButton_Click" Text="Üzenet Törlése" />
    </asp:View>
    <asp:View ID="MessageView" runat="server">
        Feladó:
        <asp:Label ID="SenderLabel" runat="server"></asp:Label>
        <br />
        Dátum:
        <asp:Label ID="DateLabel" runat="server"></asp:Label>
        <br />
        Üzenet:<br />
        <asp:Label ID="MessageLabel" runat="server"></asp:Label>
        <br />
        <asp:Button ID="BackButton" runat="server" Text="Vissza" OnClick="BackButton_Click" />
    </asp:View>
    <asp:View ID="SheetsView" runat="server">
        <asp:ListView ID="SheetListView" DataKeyNames="ID" runat="server" EnablePersistedSelection="True">
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td>
                        <asp:Label ID="Jogkor_idLabel" runat="server" Text='<%# Eval("author") %>' />
                    </td>
                    <td>
                        <asp:Label ID="HangszerekLabel" runat="server" Text='<%# Eval("title") %>' />
                    </td>
                    <td>
                        <asp:Button ID="SelectButton" runat="server" Text="kotta"/>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <SelectedItemTemplate>
               <tr style="background-color:#ff6a00;">
                    <td>
                        <asp:Label ID="Jogkor_idLabel" runat="server" Text='<%# Eval("author") %>' />
                    </td>
                    <td>
                        <asp:Label ID="HangszerekLabel" runat="server" Text='<%# Eval("title") %>' />
                    </td>
                    <td>
                        <asp:Button ID="SelectButton" runat="server" Text="kotta"/>
                    </td>
                </tr>
            </SelectedItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                        <asp:Label ID="Jogkor_idLabel" runat="server" Text='<%# Eval("author") %>' />
                    </td>
                    <td>
                        <asp:Label ID="HangszerekLabel" runat="server" Text='<%# Eval("title") %>' />
                    </td>
                    <td>
                        <asp:Button ID="SelectButton" runat="server" Text="kotta"/>
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                    <th runat="server">Szerző</th>
                                    <th runat="server">Cím</th>
                                    <th runat="server">Kotta</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;"></td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
    </asp:View>
</asp:MultiView>
    </asp:Content>
