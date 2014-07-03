<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Concedii.aspx.cs" Inherits="ResurseUmane.Concedii" MasterPageFile="~/Default.master"  %>

<asp:Content runat="server" ContentPlaceHolderID="pagesLoader">

     <fieldset>
        <legend>Adauga Concediu</legend>
        <div class="grid">
            <div class="row">
                <div class="col-1">
                    <span>An</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtAn" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Total Zile</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtTotalZile" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Zile ramase</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtZileRamase" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Marca angajat</span>
                </div>
                <div class="col-2">
                    <asp:DropDownList ID="dropMarcaAngajat" runat="server" Width="155"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <asp:Button ID="btnAdaugaConcediu" runat="server" OnClick="btnAdaugaConcediu_Click" Text="Adauga Concediu" />
                </div>
                <div class="col-2">
                    <asp:Label ID="lblConcedii" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </fieldset>


    <fieldset>
        <legend>Selectati anul</legend>
        <asp:DropDownList runat="server" ID="dropDownAn" OnSelectedIndexChanged="dropDownSelectedIndexChanged" AutoPostBack="true" >

        </asp:DropDownList>
    </fieldset>

    <fieldset>
        <legend>Vizualizeaza concediile existente</legend>
        <asp:GridView runat="server" ID="gridConcedii" OnRowCommand="gridConcedii_RowCommand">
            <Columns>
                <asp:ButtonField Text="Edit" CommandName="EditRow" />
                <asp:ButtonField Text="Sterge" CommandName="DeleteRow"/>
            </Columns>
        </asp:GridView>
    </fieldset>
</asp:Content>
