<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Salarii.aspx.cs" Inherits="ResurseUmane.Salarii"  MasterPageFile="~/Default.master"%>



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
                    <asp:Button ID="btnAdaugaSalariu" runat="server" OnClick="btnAdaugaSalariu_Click" Text="Adauga Salariu" />
                </div>
                <div class="col-2">
                    <asp:Label ID="lblSalarii" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </fieldset>

    <fieldset>
        <legend>Vizualizeaza salariile existente</legend>
        <asp:GridView runat="server" ID="gridSalarii" OnRowCommand="gridSalarii_RowCommand">
            <Columns>
                <asp:ButtonField Text="Edit" CommandName="EditRow" />
                <asp:ButtonField Text="Sterge" CommandName="DeleteRow"/>
            </Columns>
        </asp:GridView>
    </fieldset>
</asp:Content>
