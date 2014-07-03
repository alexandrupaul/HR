<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rapoarte.aspx.cs" Inherits="ResurseUmane.Rapoarte" MasterPageFile="~/Default.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="pagesLoader">
    <fieldset >
        <legend id="legendReport" runat="server">Vizualizare raport</legend>
        <asp:GridView runat="server" ID="gridRapoarte">
        </asp:GridView>
    </fieldset>
</asp:Content>