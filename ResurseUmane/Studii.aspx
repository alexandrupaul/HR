<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Studii.aspx.cs" Inherits="ResurseUmane.Studii"  MasterPageFile="~/Default.master"%>

<asp:Content ContentPlaceHolderID="pagesLoader" runat="server">
    <fieldset>
        <legend>Adaugare studii</legend>
        <div class="grid">
            <div class="row">
                <div class="col-1">
                    <span>Denumire</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtDenumireStudii" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Nivel</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtNivelStudii" runat="server"></asp:TextBox>
                </div>
            </div>
           <%-- <div class="row">
                <div class="col-1">
                    <span>Scutire impozit</span>
                </div>
                <div class="col-2">
                    <asp:CheckBox runat="server" ID="chkScutireImpozit" />
                </div>
            </div>--%>
            <div class="row">
                <div class="col-1">
                    <asp:Button ID="btnAdaugaStudii" runat="server" OnClick="btnAdaugaStudiu_Click" Text="Adauga studiu" />
                </div>
                <div class="col-2">
                    <asp:Label ID="lblStudii" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </fieldset>
    <asp:TextBox ID="txtFiltruStudii" runat="server"></asp:TextBox>
    <asp:Button ID="btnFiltreazaStudii" runat="server" OnClick="btnFiltreazaStudii_Click" Text="Filtru" />
    
    <fieldset>
        <legend>Vizualizeaza studiile existente</legend>
        <asp:GridView runat="server" ID="gridStudii" OnRowCommand="gridStudii_RowCommand">
            <Columns>
                <asp:ButtonField Text="Edit" CommandName="EditRow" />
                <asp:ButtonField Text="Sterge" CommandName="DeleteRow" />
            </Columns>
        </asp:GridView>
        
    </fieldset>
</asp:Content>