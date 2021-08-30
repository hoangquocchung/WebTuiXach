$(document).ready(function () {
    $('.btn_delete').off('click').on('click', function (e) {
        e.preventDefault();
        var btn = $(this);
        var id = btn.data('id');
        $.ajax({
            type: "POST",
            url: "/Admin/Menu/Delete",
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
            url: "/Admin/Menu/ChangeStatus",
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
    ///////////////////////////////////////////////////////////////////
    //$('.ch').change(function () {
    //    var chec = $(this);
    //    var id = chec.data('id');
    //    $.ajax({
    //        type: "POST",
    //        url: "/Admin/Menu/Create",
    //        data: { id: id },
    //        dataType: "json",
    //        success: function () {
    //            if (chec.attr('checked', true)) {

    //            }
    //        }
    //    })
    //});
})
