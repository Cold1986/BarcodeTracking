<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uploadfiles.aspx.cs" Inherits="KS_HTY.uploadfiles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Please Upload The Excel File:
        <br />
        <asp:FileUpload runat="server" ID="fuload" /><asp:Label ID="lblMsg" runat="server"
            Font-Bold="True" ForeColor="Red"  Visible="False"></asp:Label>
        <asp:Button ID="btnUpload" runat="server"  Text="导入"
            OnClick="btnUpload_Click" />
    </div>
    </form>
</body>
</html>
