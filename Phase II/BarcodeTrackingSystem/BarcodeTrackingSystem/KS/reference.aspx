<%@ Page Title="" Language="C#" MasterPageFile="~/KS/KSMasterPage.Master" AutoEventWireup="true"
    CodeBehind="reference.aspx.cs" Inherits="BarcodeTracking.KS.reference" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../style/reference.css" rel="stylesheet">
    <script type="text/javascript" src="../js/KS/reference.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <h2>
            当前位置：参照表管理</h2>
        <div class="filter border-gray">
            <div class="title border-bottom-gray">
                <i class="icon ion-android-search"></i>筛选条件</div>
            <div class="filter-inner">
                <ul class="filter-content clearfix">
                    <li>
                        <label>
                            项目</label>
                        <input type="text" id="s-item"></input>
                    </li>
                    <li>
                        <label>
                            颜色</label>
                        <input type="text" id="s-color"></input>
                    </li>
                    <li>
                        <label>
                            AP/N</label>
                        <input type="text" id="s-APN"></input>
                    </li>
                    <li>
                        <label>
                            出wistronJDE料号</label>
                        <input type="text" id="s-JDECode-out"></input>
                    </li>
                    <li>
                        <label>
                            产品名称</label>
                        <input type="text" id="s-product"></input>
                    </li>
                    <li>
                        <label>
                            盒形</label>
                        <input type="text" id="s-box"></input>
                    </li>
                    <li>
                        <label>
                            小标签</label>
                        <input type="text" id="s-label"></input>
                    </li>
                    <li>
                        <label>
                            OEM客户料号</label>
                        <input type="text" id="s-OEMCode"></input>
                    </li>
                    <li>
                        <label>
                            装箱数量</label>
                        <input type="text" id="s-number"></input>
                    </li>
                    <li>
                        <label>
                            版本</label>
                        <input type="text" id="s-version"></input>
                    </li>
                    <li>
                        <label>
                            JDE料号</label>
                        <input type="text" id="s-JDECode"></input>
                    </li>
                    <li>
                        <label>
                            出wistron客户料号</label>
                        <input type="text" id="s-OEMCode-out"></input>
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
        <div class="results">
            <div class="results-inner">
                <table id="resultTable" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <td>
                                项目
                            </td>
                            <td>
                                产品名称
                            </td>
                            <td>
                                装箱数量
                            </td>
                            <td>
                                颜色
                            </td>
                            <td>
                                盒形
                            </td>
                            <td>
                                版本
                            </td>
                            <td>
                                AP/N
                            </td>
                            <td>
                                小标签
                            </td>
                            <td>
                                JDE料号
                            </td>
                            <td>
                                出wistronJDE料号
                            </td>
                            <td>
                                OEM客户料号
                            </td>
                            <td>
                                出wistron客户料号
                            </td>
                            <td>
                                产品描述
                            </td>
                            <td>
                                操作
                            </td>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
        <button class="btn add" type="button">
            新增</button>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="popup delete-alert">
        <div class="popup-bg">
        </div>
        <div class="popup-inner">
            <p class="blue">
                确认删除本条记录？</p>
            <div>
                <button class="btn popup-cancel" type="button">
                    取消</button>
                <button class="btn delete-alert-comfirm" type="button">
                        确认</button>
            </div>
        </div>
    </div>
    <div class="popup add-item edit-item" style="display: none;">
        <div class="popup-bg">
        </div>
        <div class="popup-inner">
            <p class="blue">
                新增产品</p>
            <ul>
                <li>
                    <label>
                        项目</label>
                    <input type="text" id="r-item" />
                    <span class="error-msg">必填！</span> </li>
                <li>
                    <label>
                        产品名称</label>
                    <input type="text" id="r-product" />
                    <span class="error-msg">必填！</span> </li>
                <li>
                    <label>
                        装箱数量</label>
                    <input type="text" id="r-number" />
                    <span class="error-msg">必填！</span> </li>
                <li>
                    <label>
                        颜色</label>
                    <input type="text" id="r-color" />
                    <span class="error-msg">必填！</span> </li>
                <li>
                    <label>
                        盒形</label>
                    <input type="text" id="r-box" />
                    <span class="error-msg">必填！</span> </li>
                <li>
                    <label>
                        版本</label>
                    <input type="text" id="r-version" />
                    <span class="error-msg">必填！</span> </li>
                <li>
                    <label>
                        AP/N</label>
                    <input type="text" id="r-APN" />
                    <span class="error-msg">必填！</span> </li>
                <li>
                    <label>
                        小标签</label>
                    <input type="text" id="r-label" />
                    <span class="error-msg">必填！</span> </li>
                <li>
                    <label>
                        JDE料号</label>
                    <input type="text" id="r-JDECode" />
                    <span class="error-msg">必填！</span> </li>
                <li>
                    <label>
                        出wistronJDE料号</label>
                    <input type="text" id="r-JDECode-out" />
                </li>
                <li>
                    <label>
                        OEM料号</label>
                    <input type="text" id="r-OEMCode" />
                    <span class="error-msg">必填！</span> </li>
                <li>
                    <label>
                        出wistron客户料号</label>
                    <input type="text" id="r-OEMCode-out" />
                </li>
                <li>
                    <label>
                        产品描述</label>
                    <textarea id="r-Description"></textarea>
                    <input type="hidden" id="r-ID" />
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
