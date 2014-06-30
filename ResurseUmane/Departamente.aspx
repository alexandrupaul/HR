<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Departamente.aspx.cs" Inherits="ResurseUmane.Departamente" MasterPageFile="~/Default.master"%>



<asp:Content ID="Content1" ContentPlaceHolderID="pagesLoader" runat="server">
    <fieldset>
        <legend>Adauga Departament</legend>
        <div class="grid">
            <div class="row">
                <div class="col-1">
                    <span>Nume</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtNumeDepartament" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Marca Manager</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtMarcaManager" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <asp:Button ID="btnAdaugaDepartament" runat="server" OnClick="btnAdaugaDepartament_Click" Text="Adauga Departament" />
                </div>
                <div class="col-2">
                    <asp:Label ID="lblDepartament" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </fieldset>
    <br />
    <%--<asp:TextBox ID="txtFiltruBanci" runat="server"></asp:TextBox>--%>
    <%--<asp:Button ID="btnFiltreazaBanci" runat="server" OnClick="btnFiltreazaBanci_Click" Text="Filtru" />--%>
    
    <fieldset>
        <legend>Vizualizeaza departamentele existente</legend>
        <asp:GridView runat="server" ID="gridDepartamente" OnRowCommand="gridDepartamente_RowCommand">
            <Columns>
                <asp:ButtonField Text="Edit" CommandName="EditRow" />
                <asp:ButtonField Text="Sterge" CommandName="DeleteRow" />
            </Columns>
        </asp:GridView>
        
    </fieldset>
</asp:Content>
