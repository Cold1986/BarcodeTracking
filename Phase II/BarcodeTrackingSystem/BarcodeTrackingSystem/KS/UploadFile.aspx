<%@ Page Title="" Language="C#" MasterPageFile="~/KS/KSMasterPage.Master" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="BarcodeTracking.KS.UploadFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../style/reference.css" rel="stylesheet">
    <script>
        $(function () {
            $('#icon_uploadFile a').addClass('focus');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <h2>当前位置：上传出货信息</h2>
        <div class="filter border-gray">
            <div class="title border-bottom-gray">
                <i class="icon ion-android-search"></i>上传出货信息
            </div>
            <div class="filter-inner">
                <ul class="filter-content clearfix">
                    <li>
                        <label>
                            出货类型</label>
                        <asp:DropDownList runat="server" ID="ddlType">
                            <asp:ListItem Value="1" Selected Text="销售"></asp:ListItem>
                            <asp:ListItem Value="0" Text="VML"></asp:ListItem>
                        </asp:DropDownList>
                    </li>
                    <li>
                        <asp:FileUpload runat="server" ID="fileUpload" />
                    </li>
                    <li>
                        <asp:Button runat="server" ID="btnUpload" OnClick="btnUpload_Click" Text="上传"/>
                    </li>
                </ul>

            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
