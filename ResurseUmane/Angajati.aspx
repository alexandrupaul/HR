<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Angajati.aspx.cs" Inherits="ResurseUmane.Angajati"  MasterPageFile="~/Default.master"%>



<asp:Content ContentPlaceHolderID="pagesLoader" runat="server">
    <fieldset>
        <legend>Adauga Angajat</legend>
        <div class="grid">
            <div class="row">
                <div class="col-1">
                    <span>Marca Angajat</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtMarcaAngajat" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>CNP</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtCNP" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Nume</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtNume" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Prenume</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtPrenume" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Adresa</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtAdresa" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Nationalitate</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtNationalitate" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Telefon</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtTelefon" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Data Nasterii</span>
                </div>
                <div class="col-2">
                    <input type="Date" id="txtDataNasterii" runat="server"/>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Data Angajare</span>
                </div>
                <div class="col-2">
                    <input type="Date" id="txtDataAngajare" runat="server"/>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Data Incheiere Contract</span>
                </div>
                <div class="col-2">
                    <input type="Date" id="txtDataIncheiereContract" runat="server"/>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Gen</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtGen" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>IBAN</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtIBAN" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Banca</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtBanca" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <asp:Button ID="btnAdaugaAngajat" runat="server" OnClick="btnAdaugaAngajat_Click" Text="Adauga Angajat" />
                </div>
                <div class="col-2">
                    <asp:Label ID="lblAngajat" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </fieldset>
</asp:Content>
