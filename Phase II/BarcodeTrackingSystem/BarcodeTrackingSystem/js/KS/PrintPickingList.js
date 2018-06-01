function myPrint(obj) {
    var newWindow = window.open("打印窗口", "_blank");
    var docStr = obj.innerHTML;
    newWindow.document.write(docStr);
    newWindow.document.close();
    newWindow.print();
    newWindow.close();
}


$(function () {
    $('#icon_printPickingList a').addClass('focus');

    $('#btnSearch').click(function () {
        $('#resultTable thead').siblings().remove();
        var so = $('#s-SONo').val().trim();
        if (so == '') {
            alert('请输入销售或VML单号');
            return
        }

        var params = {
            method: "getPickingList",
            SONo: so
        };
        $.ajax({
            url: '../Handler/KS/PrintPickingList.ashx',
            data: params,
            type: "post",
            dataType: "json",
            async: false,
            success: function (data) {
                var html = [];
                if (data.Rows.length == 0) {
                    alert('查无数据');
                }
                else {
                    for (var i = 0; i < data.Rows.length; i++) {
                        //html.push('<tr><td>' + (i / 1 + 1) + '</td>'); 
                        html.push('<tr><td>' + data.Rows[i].PROJECTNO + '</td>');
                        html.push('<td>' + data.Rows[i].LIBRARY + '</td>');
                        html.push('<td>' + data.Rows[i].Column1 + '</td>');
                        html.push('</tr>');
                    };
                }
                $('#resultTable').append(html.join(''));


                //if (data != null) {
                //    if (method == "getPickingList") {
                //        $('#resultTable thead').siblings().remove();
                //        var html = [];
                //        for (var i = 0; i < data.length; i++) {
                //            //html.push('<tr><td>' + (i / 1 + 1) + '</td>'); //序号
                //            //html.push('<td>' + data[i].CODE + '</td>'); //卡板号
                //            //html.push('<td>' + data[i].BARCODE + '</td>'); //卡板二维码
                //            //html.push('</tr>');
                //        };
                //        $('#resultTable').append(html.join(''));
                //    }
                //    else {
                //        window.location.href = data;
                //    }
                //}

            },
            error: function (data) {
                alert('查无数据');
            }
        });
    });
});
