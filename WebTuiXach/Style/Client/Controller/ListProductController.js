////$(document).ready(function () {
////    LoadListAllProduct();
////})
////function LoadListAllProduct() {
////    $.ajax({
////        url: "/Default/ListAllProduct",
////        type: "GET",
////        dataType: "json",
////        success: function (result) {
////            var html = 'abc';
////            $.each(result., function (i, item) {
////                html += '<div class="col-12 col-md-3"><div class="qc__block-product">';
////                html += '<div class="qc__image_block">';
////                html += '<div class="wImage">';
////                html += '<a href="" class="image">';
////                html += '<img src="' + item.Images + '" alt="">';
////                html += '</a>';
////                html += '</div>';
////                html += '<div class="qc__btn_ct">';
////                html += '<a href="" class="btn_ct">mua ngay</a>';
////                html += '<a href="" class="btn_ct">chi tiết</a>';
////                html += '</div>';
////                html += '</div>';
////                html += '<div class="qc__detail">';
////                html += '<a href="">' + item.Name + '</a>';
////                html += '<div class="qc__price">';
////                html += '<span>' + item.Price.GetValueOrDefault(0).ToString("N0") + 'đ</span>';
////                html += '</div>';
////                html += '</div>';
////                html += '</div></div>';
////            });
////            $('.row.listProduct').html(html);
////        }
////    });
////}
var product = {
    init: function () {

        product.LoadListAllProduct();
        //product.LoadListbyProduct();
    },
    LoadListAllProduct: function () {
        $.ajax({
            url: "/Default/ListAllProduct",
            type: "GET",
            dataType: "json",
            success: function (result) {
                var html = '';
                $.each(result, function (i, item) {
                    html += '<div class="col-12 col-md-3"><div class="qc__block-product">';
                    html += '<div class="qc__image_block">';
                    html += '<div class="wImage">';
                    html += '<a href="" class="image">';
                    html += '<img src="' + item.Images + '" alt="">';
                    html += '</a>';
                    html += '</div>';
                    html += '<div class="qc__btn_ct">';
                    html += '<a href="" class="btn_ct">mua ngay</a>';
                    html += '<a href="" class="btn_ct">chi tiết</a>';
                    html += '</div>';
                    html += '</div>';
                    html += '<div class="qc__detail">';
                    html += '<a href="">' + item.Name + '</a>';
                    html += '<div class="qc__price">';
                    if (item.Price == null) {
                        html += '<span style="color:red">Liên hệ</span>';
                    }
                    else {
                        html += '<span>' + item.Price + 'đ</span>';
                    }

                    html += '</div>';
                    html += '</div>';
                    html += '</div></div>';
                });
                $('.row.listProduct').html(html);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    },

    LoadListbyProduct: function () {
        $.ajax({
            url: "/Default/ListAllProduct2",
            type: "GET",
            dataType: "json",
            success: function (result) {
                var html = '';
                $.each(result, function (i, item) {
                    html += '<div class="col-12 col-md-3"><div class="qc__block-product">';
                    html += '<div class="qc__image_block">';
                    html += '<div class="wImage">';
                    html += '<a href="" class="image">';
                    html += '<img src="' + item.Images + '" alt="">';
                    html += '</a>';
                    html += '</div>';
                    html += '<div class="qc__btn_ct">';
                    html += '<a href="" class="btn_ct">mua ngay</a>';
                    html += '<a href="" class="btn_ct">chi tiết</a>';
                    html += '</div>';
                    html += '</div>';
                    html += '<div class="qc__detail">';
                    html += '<a href="">' + item.Name + '</a>';
                    html += '<div class="qc__price">';
                    if (item.Price == null) {
                        html += '<span style="color:red">Liên hệ</span>';
                    }
                    else {
                        html += '<span>' + item.Price + 'đ</span>';
                    }

                    html += '</div>';
                    html += '</div>';
                    html += '</div></div>';
                });
                $('.row.listProduct').html(html);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
product.init();