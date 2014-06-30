<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Banci.aspx.cs" Inherits="ResurseUmane.Banci" MasterPageFile="~/Default.master" %>


<asp:Content ContentPlaceHolderID="pagesLoader" runat="server">
    <script type="text/javascript">
        $(".deleteLink").click(function () {
            return confirm('Are you sure you wish to delete this record?');
        });
    </script>
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
    <br />
    <asp:TextBox ID="txtFiltruBanci" runat="server"></asp:TextBox>
    <asp:Button ID="btnFiltreazaBanci" runat="server" OnClick="btnFiltreazaBanci_Click" Text="Filtru" />
    
    <fieldset>
        <legend>Vizualizeaza bancile existente</legend>
        <asp:GridView runat="server" ID="gridBanci" OnRowCommand="gridBanci_RowCommand">
            <Columns>
                <asp:ButtonField Text="Edit" CommandName="EditRow" />
                <asp:ButtonField Text="Sterge" CommandName="DeleteRow"/>
            </Columns>
        </asp:GridView>
    </fieldset>
</asp:Content>
