<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BarcodeTracking.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>Barcode Tracking - User Login</title>
    <link href="style/reset.css" rel="stylesheet">
    <link href="style/global.css?v1" rel="stylesheet">
    <link href="style/login.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div class="stars">
    </div>
    <div class="content">
        <div class="logo">
            <img src="image/logo.png"></div>
        <h1>
            Barcode Tracking</h1>
        <div class="login-box">
            <h2 class="blue">
                User Login</h2>
            <label>
                User Name:</label>
            <input class="bd-blue" type="text" id="userName" runat="server"></input>
            <label>
                Password:</label>
            <input class="bd-blue" type="password" id="password" runat="server"></input>
            <div class="error-msg" id="lblMsg" runat="server">
               
            </div>
            <input class="btn" type="button" value="Login" runat="server" id="btn" onserverclick="btn_Click"></input>
        </div>
    </div>
    </form>
</body>
</html>
