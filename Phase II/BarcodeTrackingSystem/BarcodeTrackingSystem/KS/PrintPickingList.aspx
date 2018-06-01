<%@ Page Title="" Language="C#" MasterPageFile="~/KS/KSMasterPage.Master" AutoEventWireup="true" CodeBehind="PrintPickingList.aspx.cs" Inherits="BarcodeTracking.KS.PrintPickingList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../style/reference.css" rel="stylesheet">
    <script type="text/javascript" src="../js/KS/PrintPickingList.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <h2>当前位置：打印拣货单</h2>
        <div class="filter border-gray">
            <div class="title border-bottom-gray">
                <i class="icon ion-android-search"></i>筛选条件
            </div>
            <div class="filter-inner">
                <ul class="filter-content clearfix">
                    <li>
                        <label>
                            单号</label>
                        <input type="text" id="s-SONo"></input>
                    </li>
                </ul>
                <div class="control">
                    <section>
                        <button class="btn" id="btnSearch" type="button">查询</button>
                    </section>
                </div>
            </div>
        </div>
        <div class="results">
            <div class="results-inner">
                <table id="resultTable" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <td>JDE号
                            </td>
                            <td>库位
                            </td>
                            <td>数量
                            </td>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
        <div>
            <button class="btn print" type="button" style="width: 100px;display:none;" onclick="myPrint(document.getElementById('resultTable'))">
                打印拣货单</button>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
