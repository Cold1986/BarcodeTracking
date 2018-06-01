<%@ Page Title="查看销售出库统计" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="getOustockReport.aspx.cs" Inherits="KS_HTY.getOustockReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="scripts/jquery-1.4.1.min.js"></script>
    <script src="scripts/extendPagination.js"></script>
    <script>
        var content;
        var bchkSONo = false;
        var bchkJDE = false;
        var bchkProNo = false;
        var bchkDate = false;
        $(function () {
            $('.navbar-nav').children('li').removeClass('active').eq(2).addClass('active');
            $("#btnSearch").click(function () {
                bchkSONo = $('#chkSONo').get(0).checked;
                bchkJDE = $('#chkJDE').get(0).checked;
                bchkProNo = $('#chkProNo').get(0).checked;
                bchkDate = $('#chkDate').get(0).checked;

                var params = {
                    method: "search",
                    type: 0,
                    strSONO: $('#txtSONo').val().trim(),//销售订单号
                    strJDE: $('#txtJDE').val().trim(),//JDE编号
                    strProNo: $('#txtProNo').val().trim(),//生产序列号
                    strUploadDate: $('#txtUploadDate').val().trim(),
                    chkSONo: bchkSONo,
                    chkJDE: bchkJDE,
                    chkProNo: bchkProNo,
                    chkDate: bchkDate
                }
                if (!bchkSONo && !bchkJDE && !bchkProNo && !bchkDate) {
                    alert('请至少显示一个字段');
                    return;
                }

                $.ajax({
                    url: 'handler/getReport.ashx',
                    data: params,
                    type: "post",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        if (data == null) {
                            var mainObj = $('#mainContent');
                            mainObj.empty();
                            $('#callBackPager').empty();
                            mainObj.html('查无数据');
                        }
                        else {
                            if (data.res == "success") {
                                if (data.mes.length > 0) {
                                    callBackPagination(data);
                                }
                                else {
                                    var mainObj = $('#mainContent');
                                    mainObj.empty();
                                    $('#callBackPager').empty();
                                    mainObj.html('查无数据');
                                }
                            }
                        }
                    }
                });
            });
            $("#btnExcel").click(function () {
                bchkSONo = $('#chkSONo').get(0).checked;
                bchkJDE = $('#chkJDE').get(0).checked;
                bchkProNo = $('#chkProNo').get(0).checked;
                bchkDate = $('#chkDate').get(0).checked;

                var params = {
                    method: "download",
                    type: 0,
                    strSONO: $('#txtSONo').val().trim(),//销售订单号
                    strJDE: $('#txtJDE').val().trim(),//JDE编号
                    strProNo: $('#txtProNo').val().trim(),//生产序列号
                    strUploadDate: $('#txtUploadDate').val().trim(),
                    chkSONo: bchkSONo,
                    chkJDE: bchkJDE,
                    chkProNo: bchkProNo,
                    chkDate: bchkDate
                }
                if (!bchkSONo && !bchkJDE && !bchkProNo && !bchkDate) {
                    alert('请至少显示一个字段');
                    return;
                }


                $.ajax({
                    url: 'handler/getReport.ashx',
                    data: params,
                    type: "post",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        console.log(data);
                        window.open(data, "_blank");
                    }
                });
            })
        });
        function callBackPagination(data) {
            content = data;
            var totalCount = data.mes.length || 200, showCount = $('#showCount1').val() || 20,
                    limit = Number($('#limit').val()) || 20;
            createTable(1, limit, totalCount, data);
            $('#callBackPager').extendPagination({
                totalCount: totalCount,
                showCount: showCount,
                limit: limit,
                callback: function (curr, limit, totalCount) {
                    createTable(curr, limit, totalCount);
                }

            });

        }

        function createTable(currPage, limit, total) {
            data = content;

            var html = [], showNum = limit;
            if (total - (currPage * limit) < 0) showNum = total - ((currPage - 1) * limit);
            html.push(' <table class="table table-hover piece" style="margin-left: 0;">');
            //html.push(' <caption>共有:(' + total + ')</caption>');

            html.push(' <thead><tr>');
            if (bchkSONo) {
                html.push(' <th>销售订单号</th>');
            }
            if (bchkJDE) {
                html.push('<th>成品编码</th>');
            }
            if (bchkProNo) {
                html.push('<th>生产序列号</th>');
            }
            if (bchkDate) {
                html.push('<th>发货日期</th>');
            }
            html.push('<th>总数</th>');
            html.push(' </tr></thead><tbody>');

            for (var i = (currPage - 1) * limit; i < (currPage - 1) * limit + showNum; i++) {
                html.push('<tr>');
                if (bchkSONo) {
                    html.push('<td>' + data.mes[i].SONo || '' + '</td>');
                }
                if (bchkJDE) {
                    html.push('<td>' + data.mes[i].JDENo || '' + '</td>');
                }
                if (bchkProNo) {
                    html.push('<td>' + data.mes[i].ProductionNo || '' + '</td>');
                }
                if (bchkDate) {
                    html.push('<td>' + data.mes[i].uploaddate || '' + '</td>');
                }
                html.push('<td>' + data.mes[i].SumNum || 0 + '</td>');
                html.push('</tr>');
            }

            html.push('</tbody></table>');
            var mainObj = $('#mainContent');
            mainObj.empty();
            mainObj.html(html.join(''));
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <form role="form" class="form-horizontal">
            <div class="form-group">
                <label for="txtSONo" class="col-sm-2 control-label">销售订单号</label>
                <div class="col-sm-4">
                    <input type="text" id="txtSONo" placeholder="销售订单号" class="form-control" />
                </div>
                <label for="txtJDE" class="col-sm-2 control-label">成品编码</label>
                <div class="col-sm-4">
                    <input type="text" id="txtJDE" placeholder="成品编码" class="form-control" />
                </div>
            </div>
            <div class="form-group">

                <label for="txtProNo" class="col-sm-2 control-label">生产序列号</label>
                <div class="col-sm-4">
                    <input type="text" id="txtProNo" placeholder="生产序列号" class="form-control" />
                </div>
                <label for="txtUploadDate" class="col-sm-2 control-label">上传日期</label>
                <div class="col-sm-4">
                    <input type="date" id="txtUploadDate" class="form-control" />
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-2 control-label">勾选显示字段</label>
                <label for="chkSONo" class="checkbox-inline col-sm-2">
                    <input type="checkbox" id="chkSONo" value="A" />销售订单号
                </label>
                <label for="chkJDE" class="checkbox-inline col-sm-2">
                    <input type="checkbox" id="chkJDE" value="B" checked />成品编码
                </label>
                <label for="chkProNo" class="checkbox-inline col-sm-2">
                    <input type="checkbox" id="chkProNo" value="C" />生产序列号
                </label>
                <label for="chkDate" class="checkbox-inline col-sm-2">
                    <input type="checkbox" id="chkDate" value="D" checked />上传日期
                </label>
            </div>


            <div class="form-group">
                <div class="col-sm-6 col-sm-offset-6">
                    <button type="button" class="btn btn-default" id="btnSearch">查询</button>
                    <button type="button" class="btn btn-default" id="btnExcel">导出</button>
                </div>
            </div>
        </form>
        <div id="mainContent"></div>
        <div id="callBackPager"></div>
    </div>
</asp:Content>
