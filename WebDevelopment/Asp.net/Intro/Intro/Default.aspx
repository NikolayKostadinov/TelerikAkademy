﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Intro.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    First Number: <asp:TextBox ID="txtFirstNumber" runat="server"></asp:TextBox><br />
        Second Number: <asp:TextBox ID="txtSecondNumber" runat="server"></asp:TextBox><br/>
        <asp:LinkButton ID="btnSum" runat="server" OnClick="btnSum_Click" >Sum</asp:LinkButton><br/>
        <asp:Label ID="lblResult" runat="server"></asp:Label>
        

    </div>
    </form>
</body>
</html>
