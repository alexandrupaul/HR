<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inregistrare_concediu.aspx.cs" Inherits="ResurseUmane.Inregistrare_concediu" MasterPageFile="~/Default.master"%>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="pagesLoader">
    <fieldset>
        <legend>Alocare Concediu</legend>
        <div class="grid">
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
                    <span>Data start</span>
                </div>
                <div class="col-2">
                    <input type="Date" id="txtDataStart" ClientIDMode="Static" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Data End</span>
                </div>
                <div class="col-2">
                    <input type="Date" id="txtDataEnd" ClientIDMode="Static" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <span>Nr zile</span>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtNrZile" ClientIDMode="Static" runat="server" Width="163" Enabled="false"></asp:TextBox>
                </div>
            </div>
            
            <div class="row">
                <div class="col-1">
                    <asp:Button ID="btnAlocaConcediu" runat="server" OnClick="btnAlocaConcediu_Click" Text="Aloca Concediu" />
                </div>
                <div class="col-2">
                    <asp:Label ID="lblAlocaConcedii" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </fieldset>
    <script>
        (function () {
            var start = document.getElementById('txtDataStart'),
                end = document.getElementById('txtDataEnd'),
                result = document.getElementById('txtNrZile');

            function calcDates(start, end) {
                start = Date.parse(start.value);
                end = Date.parse(end.value);
                diff = Math.abs(end - start);
                return Math.ceil(diff / (1000 * 3600 * 24));
            }

            window.onload = function () {
                start.addEventListener('change', function () {
                    var res = isNaN(calcDates(start, end)) ? 'Invalid' : calcDates(start, end);
                    result.value = res;
                });
                end.addEventListener('change', function () {
                    var res = isNaN(calcDates(start, end)) ? 'Invalid' : calcDates(start, end);
                    result.value = res;
                });
            }
        })();
    </script>
</asp:Content>

