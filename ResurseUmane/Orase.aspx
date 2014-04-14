<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Orase.aspx.cs" Inherits="ResurseUmane.Orase" MasterPageFile="~/Default.master"%>


<asp:Content ContentPlaceHolderID="pagesLoader" runat="server">
    <fieldset>
        <legend>Adauga Oras</legend>
        <div class="grid">
            <div class="row">
                <div class="col-1">
                    <span>Denumire oras</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtDenumireOras" runat="server"></asp:TextBox>
                </div>
            </div>
            
            <div class="row">
                <div class="col-1">
                    <asp:Button ID="btnAdaugaOras" runat="server" OnClick="btnAdaugaOras_Click" Text="Adauga Oras" />
                </div>
                <div class="col-2">
                    <asp:Label ID="lblOrase" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </fieldset>
</asp:Content>