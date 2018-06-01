$(function () {
    pageInit();

    $('#icon_reference a').addClass('focus');

    //新增或修改按钮点击
    $('.add-item-confirm').on('click', function () {
        if (inputCheck()) {
            if ($('#r-ID').val() != '') {//更新操作
                addOrUpdateReferenceById("updateReferenceById");
                alert("updated success");
            } else {//添加操作
                addOrUpdateReferenceById("addReference");
                alert("add success");
            }
            $(".edit-item").hide();
            clearInput();
            pageInit();
        }
    });


    $('.add').on('click', function () {
        $(".edit-item p").html("添加产品");
        $('#r-ID').val('');
        clearInput();
        $(".edit-item").show();
    });

    $('.popup-cancel').on('click', function () {
        $(".edit-item").hide();
    });

    $('#btnClear').on('click', clearSearchInput);

    $('#btnSearch').on('click', searchReference);

    $('.popup-cancel').on('click', function () {
        $('.delete-alert').hide();
    });
});

function searchReference() {
    $('#resultTable thead').siblings().remove();
    var params = {
        method: 'selReferenceList',
        project: $('#s-item').val(), //项目
        name: $('#s-product').val(), //产品名称
        packingQty: $('#s-number').val(), //装箱数量
        color: $('#s-color').val(), //颜色
        boxType: $('#s-box').val(), //盒形
        productVersion: $('#s-version').val(), //版本
        apn: $('#s-APN').val(), //APN
        label: $('#s-label').val(), //小标签
        jdeNo: $('#s-JDECode').val(), //JDE料号
        outJDENo: $('#s-JDECode-out').val(), //出wistronJDE料号
        oemCustNo: $('#s-OEMCode').val(), //OEM客户料号	
        outCustNo: $('#s-OEMCode-out').val(), //出wistron客户料号	
        description: $('#s-Description').val() //产品描述	
    };
    $.ajax({
        url: '../Handler/KS/referenceFacade.ashx',
        data: params,
        type: "post",
        dataType: "json",
        async: false,
        success: function (data) {
            if (data != null) {
                var html = [];
                for (var i = 0; i < data.length; i++) {
                    html.push('<tr><td>' + data[i].project + '</td>'); //项目
                    html.push('<td>' + data[i].name + '</td>'); //产品名称
                    html.push('<td>' + data[i].packingQty + '</td>'); //装箱数量
                    html.push('<td>' + data[i].color + '</td>'); //颜色
                    html.push('<td>' + data[i].boxType + '</td>'); //盒形
                    html.push('<td>' + data[i].productVersion + '</td>'); //版本
                    html.push('<td>' + data[i].apn + '</td>'); //AP/N
                    html.push('<td>' + data[i].label + '</td>'); //小标签
                    html.push('<td>' + data[i].jdeNo + '</td>'); //JDE料号
                    html.push('<td>' + data[i].outJDENo + '</td>'); //出wistronJDE料号
                    html.push('<td>' + data[i].oemCustNo + '</td>'); //OEM客户料号	
                    html.push('<td>' + data[i].outCustNo + '</td>'); //出wistron客户料号		
                    html.push('<td>' + data[i].description + '</td>'); //产品描述	
                    html.push('<td class="operation">');
                    html.push('<i class="icon ion-edit" onclick=editReferenceById(' + data[i].id + ')></i><i class="icon ion-trash-a" onclick=delReferenceById(' + data[i].id + ')></i>');
                    html.push('</td></tr>');
                };
                $('#resultTable').append(html.join(''));
            }
        }
    });
}

//新增 or 更新
function addOrUpdateReferenceById(myMethod) {
    var params = {
        method: myMethod,
        id: $('#r-ID').val(),
        project: $('#r-item').val(), //项目
        name: $('#r-product').val(), //产品名称
        packingQty: $('#r-number').val(), //装箱数量
        color: $('#r-color').val(), //颜色
        boxType: $('#r-box').val(), //盒形
        productVersion: $('#r-version').val(), //版本
        apn: $('#r-APN').val(), //APN
        label: $('#r-label').val(), //小标签
        jdeNo: $('#r-JDECode').val(), //JDE料号
        outJDENo: $('#r-JDECode-out').val(), //出wistronJDE料号
        oemCustNo: $('#r-OEMCode').val(), //OEM客户料号	
        outCustNo: $('#r-OEMCode-out').val(), //出wistron客户料号	
        description: $('#r-Description').val() //产品描述	
    };
    $.ajax({
        url: '../Handler/KS/referenceFacade.ashx',
        data: params,
        type: "post",
        dataType: "json",
        async: false,
        success: function (data) {
        }
    });
}

function clearSearchInput() {
    $(".filter-content input[type='text']").each(function (index, element) {
        $(this).val('');
    });

}

function clearInput() {
    $(".popup-inner input[type='text']").each(function (index, element) {
        $(this).val('');
    });
    $('#r-Description').val('');

}

function inputCheck() {
    var result = true;
    $(".popup-inner input[type='text']").each(function (index, element) {
        if ($(this).val().trim() == "" && $(this).next("span").length>0) {
            result = false;
            $(this).next("span").show();
        }
        else {
            $(this).next("span").hide();
        }
    });
    return result;
};

//页面加载完执行
function pageInit() {
    $('#resultTable thead').siblings().remove();
    var params = {
        method: "getReferenceList"
    }
    $.ajax({
        url: '../Handler/KS/referenceFacade.ashx',
        data: params,
        type: "post",
        dataType: "json",
        async: false,
        success: function (data) {
            if (data == null) {

            }
            else {
                var html = [];
                for (var i = 0; i < data.length; i++) {
                    html.push('<tr><td>' + data[i].project + '</td>'); //项目
                    html.push('<td>' + data[i].name + '</td>'); //产品名称
                    html.push('<td>' + data[i].packingQty + '</td>'); //装箱数量
                    html.push('<td>' + data[i].color + '</td>'); //颜色
                    html.push('<td>' + data[i].boxType + '</td>'); //盒形
                    html.push('<td>' + data[i].productVersion + '</td>'); //版本
                    html.push('<td>' + data[i].apn + '</td>'); //AP/N
                    html.push('<td>' + data[i].label + '</td>'); //小标签
                    html.push('<td>' + data[i].jdeNo + '</td>'); //JDE料号
                    html.push('<td>' + data[i].outJDENo + '</td>'); //出wistronJDE料号
                    html.push('<td>' + data[i].oemCustNo + '</td>'); //OEM客户料号	
                    html.push('<td>' + data[i].outCustNo + '</td>'); //出wistron客户料号		
                    html.push('<td>' + data[i].description + '</td>'); //产品描述	
                    html.push('<td class="operation">');
                    html.push('<i class="icon ion-edit" onclick=editReferenceById(' + data[i].id + ')></i><i class="icon ion-trash-a" onclick=delReferenceById(' + data[i].id + ')></i>');
                    html.push('</td></tr>');
                };
                $('#resultTable').append(html.join(''));
            }
        }
    });
}

//显示修改界面
function editReferenceById(referenceId) {
    $(".edit-item p").html("编辑产品");
    var params = {
        method: "getReferenceById",
        id: referenceId
    };
    $.ajax({
        url: '../Handler/KS/referenceFacade.ashx',
        data: params,
        type: "post",
        dataType: "json",
        async: false,
        success: function (data) {
            if (data == null) {
            }
            else {
                $('#r-ID').val(data.id);
                $('#r-item').val(data.project); //项目
                $('#r-product').val(data.name); //产品名称
                $('#r-number').val(data.packingQty); //装箱数量
                $('#r-color').val(data.color); //颜色
                $('#r-box').val(data.boxType); //盒形
                $('#r-version').val(data.productVersion); //版本
                $('#r-APN').val(data.apn); //AP/N
                $('#r-label').val(data.label); //小标签
                $('#r-JDECode').val(data.jdeNo); //JDE料号
                $('#r-JDECode-out').val(data.outJDENo); //出wistronJDE料号
                $('#r-OEMCode').val(data.oemCustNo); //OEM客户料号	
                $('#r-OEMCode-out').val(data.outCustNo); //出wistron客户料号		
                $('#r-Description').val(data.description); //产品描述	
            }
        }
    });
    $(".edit-item").show();
}



//确认删除界面
function delReferenceById(referenceId) {
    $('#hidDelId').val(referenceId);
    $('.delete-alert').show();

    $('.delete-alert-comfirm').click(function () {
        var params = {
            method: "delReferenceById",
            id: referenceId
        };
        $.ajax({
            url: '../Handler/KS/referenceFacade.ashx',
            data: params,
            type: "post",
            dataType: "json",
            async: false,
            success: function (data) {

            }
        });
        alert("删除成功！");
        pageInit();
        $('.delete-alert').hide();
    });
}

