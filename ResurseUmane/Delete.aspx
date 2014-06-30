<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="ResurseUmane.Delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="styles.css" rel="stylesheet" />
    <title>Confirmati stergerea</title>

   <%-- <script type="text/javascript" >

        function DeleteRow() {
            var flag;
            flag = confirm("Sunteti sigur ca doriti sa stergeti intrarea?");
            return flag;
        }

    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
    <div class="edit-form">
        <div class="edit-row">
            <h2>Sunteti sigur ca doriti stergerea inregistrarii?</h2>
        </div>
        <div class="edit-row">
            <asp:Button runat="server" ID="btnConfirmDelete" Text="Da" OnClick="btnConfirmDelete_Click" />
            <asp:Button runat="server" ID="btnGoBack" Text="Nu" OnClick="btnGoBack_Click" />
            <div class="clear"></div>
        </div>
    </div>
    </form>
</body>
</html>
