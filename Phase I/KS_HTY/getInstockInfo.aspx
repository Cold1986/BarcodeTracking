<%@ Page Title="查看生产入库记录" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="getInstockInfo.aspx.cs" Inherits="KS_HTY.getInstockInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="scripts/jquery-1.4.1.min.js"></script>
    <script src="scripts/extendPagination.js"></script>
    <script>
        var content;
        $(function () {
            $('.navbar-nav').children('li').removeClass('active').eq(3).addClass('active');
            $("#btnSearch").click(function () {
                var params = {
                    method: "search",
                    type: 1,
                    strJobNO: $('#txtJobNo').val().trim(),//工单号
                    strCartonNo: $('#txtCartonNo').val().trim(),//箱唛编号
                    strJDE: $('#txtJDE').val().trim(),//JDE编号
                    strProNo: $('#txtProNo').val().trim(),//生产序列号
                    strUser: $('#txtUser').val().trim(),//操作人员
                    strUploadDate: $('#txtUploadDate').val().trim()
                }

                $.ajax({
                    url: 'handler/getInfo.ashx',
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
            html.push(' <caption>共有:(' + total + ')</caption>');
            html.push(' <thead><tr><th>工单号</th><th>成品编码</th><th>生产序列号</th><th>装箱数量</th><th>上传人员</th><th>上传日期</th></tr></thead><tbody>');

            for (var i = (currPage - 1) * limit; i < (currPage - 1) * limit + showNum; i++) {
                //$.each(data.mes, function (i, list) {
                html.push('<tr><td>' + data.mes[i].JobNo || '' + '</td>');
                html.push('<td>' + data.mes[i].JDENo || '' + '</td>');
                html.push('<td>' + data.mes[i].ProductionNo || '' + '</td>');
                html.push('<td>' + data.mes[i].Num || 0 + '</td>');
                html.push('<td>' + data.mes[i].upload_user || '' + '</td>');
                html.push('<td>' + data.mes[i].upload_date || '' + '</td>');
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
                <label for="txtJobNo" class="col-sm-2 control-label">工单号</label>
                <div class="col-sm-4">
                    <input type="text" id="txtJobNo" placeholder="工单号" class="form-control" />
                </div>
                <label for="txtCartonNo" class="col-sm-2 control-label">箱唛编号</label>
                <div class="col-sm-4">
                    <input type="text" id="txtCartonNo" placeholder="箱唛编号" class="form-control" />
                </div>
            </div>
            <div class="form-group">
                <label for="txtJDE" class="col-sm-2 control-label">成品编码</label>
                <div class="col-sm-4">
                    <input type="text" id="txtJDE" placeholder="成品编码" class="form-control" />
                </div>
                <label for="txtProNo" class="col-sm-2 control-label">生产序列号</label>
                <div class="col-sm-4">
                    <input type="text" id="txtProNo" placeholder="生产序列号" class="form-control" />
                </div>
            </div>
            <div class="form-group">
                <label for="txtUser" class="col-sm-2 control-label">上传人员</label>
                <div class="col-sm-4">
                    <input type="text" id="txtUser" placeholder="上传人员" class="form-control"  />
                </div>
                <label for="txtUploadDate" class="col-sm-2 control-label">上传日期</label>
                <div class="col-sm-4">
                    <input type="date" id="txtUploadDate" class="form-control" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-6 col-sm-offset-6">
                    <button type="button" class="btn btn-default" id="btnSearch">查询</button>
                    <button type="button" class="btn btn-default" id="btnExcel" style="display:none;">导出</button>
                </div>
            </div>
        </form>
        <div id="mainContent"></div>
        <div id="callBackPager"></div>
    </div>
</asp:Content>

