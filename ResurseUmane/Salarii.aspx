<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Salarii.aspx.cs" Inherits="ResurseUmane.Salarii"  MasterPageFile="~/Default.master"%>



<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="pagesLoader">
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
