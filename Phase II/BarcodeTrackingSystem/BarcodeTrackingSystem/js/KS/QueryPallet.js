$(function () {
    $('#icon_queryPallet a').addClass('focus');

    setDateDefault();

    $('#btnSearch').click(function () {
        getPalletInfo('searchPalletInfo');
    });

    $('#btnClear').on('click', clearSearchInput);

    $('.export').click(function () {
        getPalletInfo('searchPalletInfo');
        getPalletInfo('exportPalletInfo');
    });

    $('.export2').click(function () {
        getPalletInfo('searchPalletInfo');
        getPalletInfo('exportShippingInfo');
    });

    $('.add-item-confirm').on('click', function () {
        $(".edit-item").hide();
    });

    $('#s-beginDate').change(function () {

        var beginDate = $(this).val();
        var endDate = $('#s-endDate').val();
        var days = daysBetween(beginDate, endDate);
        if (days <= 30) {

        } else {
            alert('查询范围不能超过30天')
        }
    });

    $('#s-endDate').change(function () {
        var endDate = $(this).val();
        var beginDate = $('#s-beginDate').val();
        var days = daysBetween(beginDate, endDate);
        if (days <= 30) {

        } else {
            alert('查询范围不能超过30天')
        }
    });
});

function daysBetween(sDate1, sDate2) {
    //Date.parse() 解析一个日期时间字符串，并返回1970/1/1 午夜距离该日期时间的毫秒数
    var time1 = Date.parse(new Date(sDate1));
    var time2 = Date.parse(new Date(sDate2));
    var nDays = Math.abs(parseInt((time2 - time1) / 1000 / 3600 / 24));
    return nDays;
};

function check(str) {
    if (str.indexOf("'") >= 0 || str.indexOf('"') >= 0) {
        return false;
    } else {
        return true;
    }
}

function getPalletInfo(type) {
    var method = type;
    var palletType = $('#ContentPlaceHolder1_palletType').val();
    var SONo = $('#s-SONo').val();
    var palletNo = $('#s-palletNo').val();//卡板号
    var JDECode = $('#s-JDECode').val();//JDENo
    var beginDate = $('#s-beginDate').val();//开始日期
    var endDate = $('#s-endDate').val();//结束日期
    var APN = $('#s-APN').val();//APN
    var palletQRCode = $('#s-palletQRCode').val();//二维码

    if (beginDate > endDate) {
        alert('查询起止时间不正确');
        return false;
    }
    var days = daysBetween(beginDate, endDate);
    if (days <= 30) {

    }
    else {
        alert('查询范围不能超过30天')
        return false;
    }

    if (check(method) && check(palletNo) && check(JDECode) && check(beginDate) && check(endDate) && check(APN) && check(palletQRCode)) {

    }
    else {
        alert('输入内容含有特殊字符');
        return false;
    }

    var params = {
        method: method,
        palletNo: palletNo,//卡板号
        JDECode: JDECode,//JDENo
        beginDate: beginDate,//开始日期
        endDate: endDate,//结束日期
        APN: APN,//APN
        palletQRCode: palletQRCode,//二维码
        palletType: palletType,
        SONo: SONo
    };
    $.ajax({
        url: '../Handler/KS/palletFacade.ashx',
        data: params,
        type: "post",
        dataType: "json",
        async: false,
        success: function (data) {
            if (data != null) {
                if (method == "searchPalletInfo") {
                    $('#resultTable thead').siblings().remove();
                    var html = [];
                    for (var i = 0; i < data.length; i++) {
                        html.push('<tr><td>' + (i / 1 + 1) + '</td>'); //序号
                        html.push('<td>' + data[i].CODE + '</td>'); //卡板号
                        html.push('<td>' + data[i].BARCODE + '</td>'); //卡板二维码
                        html.push('<td>' + data[i].APN + '</td>'); //APN
                        html.push('<td>' + data[i].JDENO + '</td>'); //JDENO
                        html.push('<td>' + data[i].QTY + '</td>'); //数量
                        html.push('<td>' + data[i].BOXQTY + '</td>'); //箱数

                        html.push('<td>' + data[i].stringMODIFIEDON + '</td>'); //创建日期	
                        html.push('<td>' + data[i].SONo + '</td>'); //SO号
                        html.push('<td>' + data[i].stringOutDate + '</td>'); //出库日期	
                        html.push('<td class="operation">');
                        html.push('<i class="icon ion-search" onclick=getPHListByPalletCode("' + data[i].BARCODE + '","' + data[i].QTY + '","' + data[i].BOXQTY + '")></i>');
                        html.push('</td></tr>');
                    };
                    $('#resultTable').append(html.join(''));
                }
                else {
                    window.location.href = data;
                }
            }

        }
    });

    params.method = "getBinderyReport"
    $.ajax({
        url: '../Handler/KS/palletFacade.ashx',
        data: params,
        type: "post",
        dataType: "json",
        async: false,
        success: function (data) {
            if (data != null) {
                $('#resultTable2 thead').siblings().remove();
                var html = [];
                var totalNums=0;
                for (var i = 0; i < data.length; i++) {
                    html.push('<tr><td>' + data[i].JDE + '</td>'); //序号
                    html.push('<td>' + data[i].workNo + '</td>'); //卡板号
                    html.push('<td>' + data[i].nums + '</td>'); //卡板号
                    html.push('</tr>');
                    totalNums = totalNums + data[i].nums / 1;
                };
                $('#resultTable2').append(html.join(''));
                $('#totalNumbers').html(totalNums);
            }
        }
    });
}

function getPHListByPalletCode(PalletCode, QTY, BOXQTY) {
    $('#popup-result thead').siblings().remove();
    $('.popup-inner .blue').html(PalletCode);
    $('.popup-inner .popup-content').html('共' + BOXQTY + '箱，' + QTY + '个成品');
    var params = {
        method: 'getPHListByPalletCode',
        palletQRCode: PalletCode//二维码
    };
    $.ajax({
        url: '../Handler/KS/palletFacade.ashx',
        data: params,
        type: "post",
        dataType: "json",
        async: false,
        success: function (data) {
            if (data != null) {
                console.log(data);
                var html = [];
                for (var i = 0; i < data.length; i++) {
                    html.push('<tr><td>' + (i / 1 + 1) + '</td>'); //序号
                    html.push('<td>' + data[i].BOXCODE + '</td></tr>'); //卡板号
                };
                $('#popup-result').append(html.join(''));
            }
        }
    });


    $(".edit-item").show();
}
Date.prototype.format = function (format) {
        var args = {
            "M+": this.getMonth() +1,
            "d+": this.getDate(),
            "h+": this.getHours(),
            "m+": this.getMinutes(),
            "s+": this.getSeconds(),
            "q+": Math.floor((this.getMonth() +3) / 3), //quarter

            "S": this.getMilliseconds()
};
        if(/(y+)/.test(format)) format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 -RegExp.$1.length));
        for(var i in args) {
            var n = args[i];

            if(new RegExp("(" +i + ")").test(format)) format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? n: ("00" +n).substr(("" +n).length));
}
        return format;
};

function setDateDefault() {
    //设置日期默认值
    var curDate = new Date();
    var stringBeginDate = new Date(curDate.getTime() - 24 * 60 * 60 * 1000).format("yyyy-MM-dd");
    console.log(stringBeginDate);
    $('#s-beginDate').val(stringBeginDate);

    var stringEndDate = new Date(curDate.getTime()).format("yyyy-MM-dd");
    console.log(stringEndDate);
    $('#s-endDate').val(stringEndDate);
}


function clearSearchInput() {
    $(".filter-content input[type='text']").each(function (index, element) {
        $(this).val('');
    });

    setDateDefault();
}


