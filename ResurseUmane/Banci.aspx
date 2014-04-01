<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Banci.aspx.cs" Inherits="ResurseUmane.Banci" MasterPageFile="~/Default.master" %>

<asp:Content ContentPlaceHolderID="pagesLoader" runat="server">
    <fieldset>
        <legend>Adauga Banca</legend>
        <div class="grid">
            <div class="row">
                <div class="col-1">
                    <span>Nume</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtNumeBanci" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Comision</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtComision" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <asp:Button ID="btnAdaugaBanca" runat="server" OnClick="btnAdaugaBanca_Click" Text="Adauga Banca" />
                </div>
                <div class="col-2">
                    <asp:Label ID="lblBanci" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </fieldset>
</asp:Content>
