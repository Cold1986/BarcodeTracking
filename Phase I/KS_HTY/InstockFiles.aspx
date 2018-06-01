<%@ Page Title="上传生产入库清单" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="InstockFiles.aspx.cs" Inherits="KS_HTY.InstockFiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="scripts/uploadify.css" rel="stylesheet" />
    <script src="scripts/jquery-1.4.1.min.js"></script>
    <script src="scripts/swfobject.js"></script>
    <script src="scripts/jquery.uploadify.min.js"></script>
    <script src="scripts/extendPagination.js"></script>
    <script type="text/javascript">
        var success = 0;
        var fail = 0;
        var files = new Array();
        var content;

        $(function () {
            $('.navbar-nav').children('li').removeClass('active').eq(1).addClass('active');
            var fileCheckResult = true;
            $("#file_upload").uploadify({
                //开启调试    
                'debug': false,
                //是否自动上传    
                'auto': false,
                'buttonText': '选择文件',
                //flash    
                'swf': "scripts/uploadify.swf",
                'queueSizeLimit': 5,
                //文件选择后的容器ID    
                'queueID': 'uploadfileQueue',
                //后台运行上传的程序  
                'uploader': 'handler/stockUpload.ashx',
                'width': '75',
                'height': '24',
                //是否支持多文件上传，这里为true，你在选择文件的时候，就可以选择多个文件  
                'multi': true,
                'fileTypeDesc': '支持的格式：',
                'fileTypeExts': '*.xlsx;*.xls;*.xlsm',
                'fileSizeLimit': '1024MB',
                //上传完成后多久删除进度条  
                'removeTimeout': 1,

                //返回一个错误，选择文件的时候触发    
                'onSelectError': function (file, errorCode, errorMsg) {
                    switch (errorCode) {
                        case -100:
                            alert("上传的文件数量已经超出系统限制的" + $('#file_upload').uploadify('settings', 'queueSizeLimit') + "个文件！");
                            break;
                        case -110:
                            alert("文件 [" + file.name + "] 大小超出系统限制的" + $('#file_upload').uploadify('settings', 'fileSizeLimit') + "大小！");
                            break;
                        case -120:
                            alert("文件 [" + file.name + "] 大小异常！");
                            break;
                        case -130:
                            alert("文件 [" + file.name + "] 类型不正确！");
                            break;
                    }
                },
                //检测FLASH失败调用    
                'onFallback': function () {
                    alert("您未安装FLASH控件，无法上传图片！请安装FLASH控件后再试。");
                },
                //上传到服务器，服务器返回相应信息到data里    
                'onUploadSuccess': function (file, data, response) {
                    if (data == "error") {
                        fail++;
                        alert(file.name + " 上传失败");
                    } else {
                        success++;
                        files.push(data);
                        alert(file.name + " 上传成功");
                    }
                },

                'onSelect': function (file) {
                    $.ajax({
                        url: 'handler/checkfiles.ashx',
                        data: { "files": file.name, "type": 1 },
                        type: "post",
                        async: false,
                        success: function (data) {
                            if (data == "1" || data == 1) {
                                if (!confirm("已有文件" + file.name + ",是否还要继续上传")) {
                                    closeLoad();
                                }
                            }
                        }
                    });

                },

                //多文件上传，服务器返回相应的信息  
                'onQueueComplete': function (queueData) {
                    $('#btnUp').attr('disable', 'false');
                    //alert(queueData.uploadsSuccessful);
                    var str = "执行完成。";
                    str += success == 0 ? "" : "上传成功：" + success + "个文件";
                    str += fail == 0 ? "" : "上传失败：" + fail + "个文件";
                    alert(str);

                    $.ajax({
                        url: 'handler/UploadInfo.ashx',
                        data: { "files": files.join(";"), "type": 1 },
                        dataType: "json",
                        type: "post",
                        async: false,
                        success: function (data) {
                            if (data.res == "success") {
                                callBackPagination(data);
                            }

                        }
                    })
                }
            });
        });

        //开始上传  
        function doUpload() {
            if ($("#uploadfileQueue").html().trim() != "") {

                if ($('#btnUp').attr('disable') != "true") {
                    $('#file_upload').uploadify('upload', '*');
                }
                success = 0;
                fail = 0;
                files = new Array();
                $('#btnUp').attr('disable', 'true');
            }
        }
        //停止上传  
        function closeLoad() {
            $('#file_upload').uploadify('cancel', '*');
            $('#btnUp').attr('disable', 'false');
        }


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
            html.push(' <caption>共上传:(' + total + ')</caption>');
            html.push(' <thead><tr><th>工单号</th><th>成品编码</th><th>生产序列号</th><th>装箱数量</th></tr></thead><tbody>');

            for (var i = (currPage - 1) * limit; i < (currPage - 1) * limit + showNum; i++) {
                //$.each(data.mes, function (i, list) {
                html.push('<tr><td>' + data.mes[i].JobNo || '' + '</td>');
                html.push('<td>' + data.mes[i].JDENo || '' + '</td>');
                html.push('<td>' + data.mes[i].ProductionNo || '' + '</td>');
                html.push('<td>' + data.mes[i].Num || 0 + '</td>');
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
        <table width="704px" border="0" align="center" cellpadding="0" cellspacing="0" id="__01">
            <tr>
                <td align="center" valign="middle">
                    <div id="uploadfileQueue" style="padding: 3px;">
                    </div>
                    <div id="file_upload">
                    </div>
                </td>
            </tr>
            <tr>
                <td height="50" align="center" valign="middle">
                    <input type="button" value="上传" onclick="doUpload()" id="btnUp" />
                    <input type="button" value="取消" onclick="closeLoad()" />
                </td>
            </tr>
        </table>
        <div style="display: none;">
            <asp:FileUpload ID="fuload" runat="server" /><asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" />
        </div>
        <div id="mainContent"></div>
        <div id="callBackPager"></div>
    </div>
</asp:Content>
