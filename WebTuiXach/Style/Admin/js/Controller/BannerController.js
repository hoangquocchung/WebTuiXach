$(document).ready(function () {
    $('.btn_delete').off('click').on('click', function (e) {
        e.preventDefault();
        var btn = $(this);
        var id = btn.data('id');
        $.ajax({
            type: "POST",
            url: "/Admin/Banner/Delete",
            data: { id: id },
            dataType: "json",
            success: function (response) {
                if (response.id == true) {
                    //return RedirectToAction("Index", "Menu");
                    $('#tr_' + id).remove();
                    location.reload();
                    alert("đã xóa thành công");

                }
            }
        })
    });
    //////////////////////////////////////////////////////////////////
    $('.ch').change(function () {
        var chec = $(this);
        var id = chec.data('id');
        $.ajax({
            type: "POST",
            url: "/Admin/Banner/ChangeStatus",
            data: { id: id },
            dataType: "json",
            success: function (response) {
                if (response.status == true) {
                    chec.attr('checked', true);
                } else {
                    chec.attr('checked', false);
                }
            }
        })
    });
    ////////////////////////////////////////////////////////////////////
    //$('#ddTypeOfAdvID').off('change').on('change', function() {
    //    //var id = $(this).val();
    //    //console.log(id);
    //    $.ajax({
    //        url: '/banner/LoadProvince',
    //        type: "POST",
    //        //data: { TypeOfAdvID: id },
    //        dataType: "json",
    //        success: function (response) {
    //            if (response.status == true) {
    //                var html = '<option value="">--Chọn tỉnh thành--</option>';
    //                var data = response.data;
    //                $.each(data, function (i, item) {
    //                    html += '<option value="' + item.ID + '">' + item.Name + '</option>'
    //                });
    //                $('#ddTypeOfAdvID').html(html);
    //            }
    //        }
    //    })
    //})
    
})


var banner = {
    init: function () {

        banner.loadprovince();
        banner.loadDistrict();
        //user.registerevent();
    },
    registerevent: function () {
        $('#ddTypeOfAdvID').off('change').on('change', function () {
            var id = $(this).val();
            if (id != '') {
                user.loadprovince(parseint(id));
            }
            else {
                $('#ddTypeOfAdvID').html('');
            }
        });
    },
    loadprovince: function () {

        $.ajax({
            url: '/banner/loadprovince',
            type: "post",
            datatype: "json",
            success: function (response) {
                if (response.status == true) {
                    var html = '<option value="">--chọn loại banners--</option>';
                    var data = response.data;
                    $.each(data, function (i, item) {
                        html += '<option value="' + item.ID + '">' + item.Name + '</option>'
                    });
                    $('#ddTypeOfAdvID').html(html);
                }
            }
        })
    },
    //loadDistrict: function (id) {
    //    $.ajax({
    //        url: '/banner/LoadDistrict',
    //        type: "POST",
    //        data: { TypeOfAdvID: id },
    //        dataType: "json",
    //        success: function (response) {
    //            if (response.status == true) {
    //                var html = '<option value="">--Chọn quận huyện--</option>';
    //                var data = response.data;
    //                $.each(data, function (i, item) {
    //                    html += '<option value="' + item.ID + '">' + item.Name + '</option>'
    //                });
    //                $('#ddTypeOfAdvID').html(html);
    //            }
    //        }
    //    })
    //}
}
banner.init();