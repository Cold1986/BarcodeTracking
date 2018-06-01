<%@ Page Title="" Language="C#" MasterPageFile="~/KS/KSMasterPage.Master" AutoEventWireup="true" CodeBehind="WHQueryPallet.aspx.cs" Inherits="BarcodeTracking.KS.WHQueryPallet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="http://cdn.static.runoob.com/libs/bootstrap/3.3.7/css/bootstrap.min.css">

    <link href="../style/reset.css" rel="stylesheet">
    <link href="../style/global.css" rel="stylesheet">
    <link href="../style/ionicons.min.css" rel="stylesheet" type="text/css" />
    <link href="../style/reference.css" rel="stylesheet">
    <script type="text/javascript" src="../js/KS/WHQueryPallet.js"></script>

    <script src="http://cdn.static.runoob.com/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="http://cdn.static.runoob.com/libs/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style type="text/css">
        table td {
            text-align: center;
        }

        table thead {
            background: #d8e3e6;
            font-weight: bold;
            text-align: center;
            border-top: 0;
        }


        .filter ul li:nth-child(2n) label {
            width: 60px;
        }

        .filter ul li {
            min-width: 220px;
            width: 30%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <h2>当前位置：出入库查询</h2>
        <div class="filter border-gray">
            <div class="title border-bottom-gray">
                <i class="icon ion-android-search"></i>筛选条件
            </div>
            <div class="filter-inner">
                <ul class="filter-content clearfix">
                    <li>
                        <label>
                            卡板状态</label>
                        <select runat="server" id="palletType">
                            <option value="1">内仓入库</option>
                            <option value="2">销售出库</option>
                            <option value="3">VMI出库</option>
                        </select>
                    </li>
                    <li>
                        <label>
                            单号</label>
                        <input type="text" id="s-SONo"></input>
                    </li>
                    <li>
                        <label>
                            卡板ID</label>
                        <input type="text" id="s-palletNo"></input>
                    </li>

                    <li>
                        <label>
                            JDENo</label>
                        <input type="text" id="s-JDECode"></input>
                    </li>
                    <li>
                        <label>
                            开始日期</label>
                        <input type="date" id="s-beginDate"></input>
                    </li>
                    <li>
                        <label>
                            结束日期</label>
                        <input type="date" id="s-endDate"></input>
                    </li>
                    <li>
                        <label>
                            APN</label>
                        <input type="text" id="s-APN"></input>
                    </li>

                    <li>
                        <label>
                            二维码</label>
                        <input type="text" id="s-palletQRCode"></input>
                    </li> 
                </ul>

                <div class="control">
                    <section>
                        <button class="btn" id="btnClear" type="button">清空</button>
                        <button class="btn" id="btnSearch" type="button">查询</button>
                    </section>
                </div>
            </div>
        </div>


        <ul id="myTab" class="nav nav-tabs">
            <li class="active">
                <a href="#tab1" data-toggle="tab">报表
                </a>
            </li>
            <li><a href="#tab2" data-toggle="tab">明细</a></li>
        </ul>

        <div id="myTabContent" class="tab-content">
            <div class="results tab-pane fade in active" id="tab1">
                总数量：<span id="totalNumbers"></span>
                <div class="results-inner">
                    <table id="resultTable2" cellpadding="0" cellspacing="0">
                        <thead>
                            
                        </thead>
                    </table>
                </div>
            </div>
            <div class="results tab-pane fade" id="tab2">
                <div class="results-inner">
                    <table id="resultTable" cellpadding="0" cellspacing="0">
                        <thead>
                            
                        </thead>
                    </table>
                </div>
            </div>
        </div>
        <div>
            <button class="btn export2 add" type="button" style="width: 100px">
                导出箱唛信息</button>
            <button class="btn export add" type="button" style="width: 100px">
                导出卡板信息</button>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="popup add-item edit-item" style="display: none;">
        <div class="popup-bg">
        </div>
        <div class="popup-inner">
            <p class="blue">
            </p>
            <div class="results">
                <div class="results-inner">
                    <table id="popup-result" cellpadding="0" cellspacing="0">
                        <thead>
                            <tr>
                                <td>序号
                                </td>
                                <td style="width: 340px">箱唛
                                </td>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div>
            <br />
            <div class="popup-content">
            </div>
            <div>
                <button class="btn add-item-confirm" type="button">
                    确认</button>
            </div>
        </div>
    </div>
</asp:Content>
