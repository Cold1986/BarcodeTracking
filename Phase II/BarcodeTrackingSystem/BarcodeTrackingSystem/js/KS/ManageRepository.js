$(function () {
    $('#icon_manageRepository a').addClass('focus');

    $('#btnClear').on('click', clearSearchInput);

    $('#btnSearch').click(getRepositoryInfo);

    $('.popup-cancel').on('click', function () {
        $(".edit-item").hide();
    });

    $('.add-item-confirm').on('click', function () {
        updateRepository();
    })
});


function clearSearchInput() {
    $(".filter-content input[type='text']").each(function (index, element) {
        $(this).val('');
    });
}


function getRepositoryInfo() {
    var method = 'searchRepository';
    var repositoryType = $('#repositoryType').val();
    var repository = $('#s-repository').val().trim();
    var description = $('#s-description').val().trim();

    //0 禁用  1 可用
    if (repositoryType == "1" && repository == "" && description == "") {
        alert('查询范围太大，请先输出筛选条件');
        return false;
    }

    var params = {
        method: method,
        repositoryType: repositoryType,
        repository: repository,
        description: description
    };

    $.ajax({
        url: '../Handler/KS/repositoryFacade.ashx',
        data: params,
        type: "post",
        dataType: "json",
        async: false,
        success: function (data) {
            if (data != null) {
                console.log(data);

                $('#resultTable thead').siblings().remove();
                var html = [];
                for (var i = 0; i < data.length; i++) {
                    html.push('<tr><td>' + (i / 1 + 1) + '</td>'); //序号
                    html.push('<td>' + data[i].repositoryNo + '</td>'); //卡板号
                    html.push('<td>' + data[i].description + '</td>'); //卡板二维码
                    html.push('<td>' + data[i].status + '</td>'); //APN

                    html.push('<td class="operation">');
                    html.push('<i class="icon ion-compose" onclick=showRepository("' + data[i].id + '","' + data[i].repositoryNo + '","' + data[i].description + '","' + data[i].status + '")></i>');
                    html.push('</td></tr>');
                };
                $('#resultTable').append(html.join(''));
            }
        }
    });
}

function showRepository(Repositoryid, repositoryNo, description, status) {
    $('#w-repositoryId').html(Repositoryid);
    $('#w-repository').html(repositoryNo);
    $('#w-description').val(description);
    $('#w-repositoryType').val(status == "正常" ? "1" : "0");
    $(".edit-item").show();
}

function updateRepository() {
    var params = {
        method: 'updateRepository',
        repositoryType: $('#w-repositoryType').val(),
        repository: $('#w-repository').html(),
        repositoryId: $('#w-repositoryId').html(),
        description: $('#w-description').val()
    };

    $.ajax({
        url: '../Handler/KS/repositoryFacade.ashx',
        data: params,
        type: "post",
        dataType: "json",
        async: false,
        success: function (data) {
            if (data == "success") {
                alert('更新成功');
                $(".edit-item").hide();
                $('#btnSearch').click();
            }
            else {
                alert('更新失败，请联系系统管理员');
            }
        }
    });
}