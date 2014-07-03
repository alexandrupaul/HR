<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ResurseUmane.Default" MasterPageFile="~/Default.master" %>
<asp:Content runat="server" ContentPlaceHolderID="pagesLoader">
    <fieldset runat="server" id="fldAuth">
        <legend>Autentificare</legend>
        <span>Utilizator</span><br />
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
        <span>Parola</span><br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:Button runat="server" ID="btnLogin" Text="Autentificare" OnClick="btnLogin_Click" />
    </fieldset>
    <h3 runat="server" id="lblAuth">Esti autentificat.</h3>
</asp:Content>
