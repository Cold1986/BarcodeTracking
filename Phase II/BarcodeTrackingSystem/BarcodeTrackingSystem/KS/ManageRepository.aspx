<%@ Page Title="" Language="C#" MasterPageFile="~/KS/KSMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageRepository.aspx.cs" Inherits="BarcodeTracking.KS.ManageRepository" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../style/reference.css" rel="stylesheet">
    <script type="text/javascript" src="../js/KS/ManageRepository.js"></script>
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
        .add-item li {
            margin-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <h2>当前位置：库位管理</h2>
        <div class="filter border-gray">
            <div class="title border-bottom-gray">
                <i class="icon ion-android-search"></i>筛选条件
            </div>
            <div class="filter-inner">
                <ul class="filter-content clearfix">
                    <li>
                        <label>
                            库位状态</label>
                        <select id="repositoryType">
                            <option value="1">正常</option>
                            <option value="0" selected>禁用</option>
                        </select>
                    </li>
                    <li>
                        <label>
                            库位编号</label>
                        <input type="text" id="s-repository"></input>
                    </li>
                    <li>
                        <label>
                            描述</label>
                        <input type="text" id="s-description"></input>
                    </li>
                </ul>
                <div class="control">
                    <button class="btn" id="btnClear" type="button">清空</button>
                    <button class="btn" id="btnSearch" type="button">查询</button>
                </div>
            </div>
        </div>
        <div class="results">
            <div class="results-inner">
                <table id="resultTable" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <td>序号
                            </td>
                            <td>库位编号
                            </td>
                            <td>描述
                            </td>
                            <td>库位状态
                            </td>
                            <td>操作
                            </td>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="popup add-item edit-item" style="display: none;">
        <div class="popup-bg">
        </div>
        <div class="popup-inner">
            <p class="blue">
                库位管理
            </p>
            <ul>
                <li>
                    <label>
                        库位编号</label>
                    <span id="w-repositoryId" style="display: none;"></span>
                    <span id="w-repository"></span></li>

                <li>
                    <label>
                        库位状态</label>
                    <select id="w-repositoryType">
                        <option value="1">正常</option>
                        <option value="0" selected>禁用</option>
                    </select>
                </li>
                <li>
                    <label>
                        描述</label>
                    <textarea type="text" id="w-description"></textarea>
                </li>
            </ul>
            <div>
                <button type="button" class="btn popup-cancel">
                    取消</button>
                <button class="btn add-item-confirm" type="button">
                    确认</button>
            </div>
        </div>
    </div>
</asp:Content>
