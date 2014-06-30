<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ResurseUmane.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="styles.css" type="text/css" />
    <style type="text/css">
        input, select {
            padding: 10px 20px;
            display: inline-block;
            min-width: 250px;        
        }
        h2 {
            font-size: 1.3em;
            text-align: center;
            margin: 15px 0px;
        }
            h2 a {
                position: relative;
                left: -350px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>
            <a href="<%= Request.UrlReferrer %>">Inapoi &laquo;</a>
            Editare <%= ModelType %>
        </h2>
        <br />
        <asp:Panel runat="server" ID="panel_Form" CssClass="edit-form">

        </asp:Panel>
    </div>
    </form>
</body>
</html>
