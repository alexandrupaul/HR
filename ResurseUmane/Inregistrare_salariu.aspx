<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inregistrare_salariu.aspx.cs" Inherits="ResurseUmane.Inregistreaza_salariu"  MasterPageFile="~/Default.master"%>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="pagesLoader">
    <fieldset>
        <legend>Adauga Salariu</legend>
        <div class="grid">
            <div class="row">
                <div class="col-1">
                    <span>Salariu Brut</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtSalariuBrut" runat="server" Width="163"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Data Plata</span>
                </div>
                <div class="col-2">
                    <input type="Date" id="txtDataPlata" runat="server"/>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Marca angajat</span>
                </div>
                <div class="col-2">
                    <asp:DropDownList ID="dropMarcaAngajat" runat="server" Width="163"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <asp:Button ID="btnAdaugaSalariu" runat="server" OnClick="btnAdaugaSalariu_Click" Text="Adauga Salariu" />
                </div>
                <div class="col-2">
                    <asp:Label ID="lblSalarii" runat="server"></asp:Label>
                </div>
            </div>

        </div>
    </fieldset>
</asp:Content>
