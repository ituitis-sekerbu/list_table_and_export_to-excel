﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OrnekWebUygulamasi.WebForm1" %>


<!DOCTYPE html>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
button,input{overflow:visible}button,input,optgroup,select,textarea{margin:0;font-family:inherit;font-size:inherit;line-height:inherit}*,::after,::before{text-shadow:none!important;box-shadow:none!important}*,::after,::before{box-sizing:border-box}</style>
</head>
 <link href="StyleSheet1.css" rel="stylesheet" />
 <link href="https://fonts.googleapis.com/css2?family=Squada+One&display=swap" rel="stylesheet">
<body>
    <form id="form1" runat="server" style="height: 523px">
        <div>
            Welcome!<br />
            <br />
            E-mail:<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            User Name:<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Password:<br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Confirm Password:<br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" class="myButton"/>
            <br />
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click1">Login</asp:LinkButton>
        </div>
        
    </form>
</body>
</html>

