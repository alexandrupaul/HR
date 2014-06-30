<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Functii.aspx.cs" Inherits="ResurseUmane.Functii"  MasterPageFile="~/Default.master"%>

<asp:Content ContentPlaceHolderID="pagesLoader" runat="server">
    <fieldset>
        <legend>Adauga functie</legend>
        <div class="grid">
            <div class="row">
                <div class="col-1">
                    <span>Denumire</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtDenumireFunctii" runat="server"></asp:TextBox>
                </div>
            </div>
            
            <div class="row">
                <div class="col-1">
                    <asp:Button ID="btnAdaugaFunctie" runat="server" OnClick="btnAdaugaFunctie_Click" Text="Adauga Functie" />
                </div>
                <div class="col-2">
                    <asp:Label ID="lblFunctii" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </fieldset>
    <fieldset>
        <legend>Vizualizeaza functiile existente</legend>
        <asp:GridView runat="server" ID="gridFunctii" OnRowCommand="gridFunctii_RowCommand">
            <Columns>
                <asp:ButtonField Text="Edit" CommandName="EditRow" />
                <asp:ButtonField Text="Sterge" CommandName="DeleteRow" />
            </Columns>
        </asp:GridView>
        
    </fieldset>
</asp:Content>