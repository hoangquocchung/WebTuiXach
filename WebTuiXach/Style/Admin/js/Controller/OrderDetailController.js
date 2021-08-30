var order = {
    init: function () {
        order.registerEvents();
        order.huy();
        order.nhan();
    },
    registerEvents: function () {
        $('.btn-images').off('click').on('click', function (e) {
            e.preventDefault();//bỏ qua dấu thăng
            $('#imagesManange').modal('show');
            $('#hidProductID').val($(this).data('id'));
            var b = $(this);
            var ID = b.data('id');
            $.ajax({
                url: "/Admin/Order/HienThi",
                data: { id: ID },
                dataType: "json",
                success: function (res) {
                    var html = '';
                    $.each(res.data, function (i, item) {
                        console.log(item.ProductID);
                        html += '<tr>';
                        html += '<td>' + item.ProductName + '</td>';
                        html += '<td>' + item.Quantity + '</td>';
                        html += '<td>' + item.Price + '</td>';
                        html += '</tr >';
                    });
                    $('.c').html(html);

                }
            });
        });
        $('.check.ch').change(function () {
            var chec = $(this);
            var id = chec.data('id');
            $.ajax({
                type: "POST",
                url: "/Admin/Order/ChangeStatus",
                data: { id: id },
                dataType: "json",
                success: function (response) {
                    if (response.status == true) {
                        chec.attr('checked', true);
                        location.reload();
                    } else {
                        chec.attr('checked', false);
                        location.reload();
                    }
                }
            })
        });
    },
    huy: function () {
        $('.check.trahang').change(function () {
            var chec = $(this);
            var id = chec.data('id');
            $.ajax({
                type: "POST",
                url: "/Admin/Order/Huy",
                data: { id: id },
                dataType: "json",
                success: function (response) {
                    if (response.status == true) {
                        chec.attr('checked', true);
                        location.reload();
                    } else {
                        chec.attr('checked', false);
                        location.reload();
                    }
                }
            })
        });
    },
    nhan: function () {
        $('.check.nhan').change(function () {
            var chec = $(this);
            var id = chec.data('id');
            $.ajax({
                type: "POST",
                url: "/Admin/Order/Ship",
                data: { id: id },
                dataType: "json",
                success: function (response) {
                    if (response.status == true) {
                        chec.attr('checked', true);
                        location.reload();
                    } else {
                        chec.attr('checked', false);
                        location.reload();
                    }
                }
            })
        });
    }
}
order.init();