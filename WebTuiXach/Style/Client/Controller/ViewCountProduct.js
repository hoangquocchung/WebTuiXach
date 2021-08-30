$(document).ready(function () {
    $('.btn_ct,.image').off('click').on('click', function () {
        var btn = $(this);
        var id = btn.data('id');
        $.ajax({
            type: "POST",
            url: "/ProductDetail/ViewCount",
            data: { id: id },
            dataType: "json",
            success: function (response) {
                if (response.data == true) {
                    return true;

                }
            }
        })
    })
})