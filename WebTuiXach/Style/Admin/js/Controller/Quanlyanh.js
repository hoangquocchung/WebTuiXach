$(document).ready(function () {
    var text = "";
    var c = $("#txtImage");
    var u = $('.imageList img');
    
    var aray = "";
    var a = new Array();
    c.each(function () {
        a = $(this).val().split(',');
        //console.log(a)
        var i;
        for (i = 0; i < a.length; i++) {
            //console.log(a[i])
            if (a[i] != '') {
                $('.imageList').append('<div style="position:relative;margin-right: 10px;margin-bootom:10px;"><img src="' + a[i] + '" style="width:70px;height:70px;" /><a href="#" class="btn-delImages" style="margin-left: 5px;"><i class="fa fa-times"></i></a></div>');
            }
        }
    })

    $('.btn-delImages').off('click').on('click', function (e) {
        e.preventDefault();
        $(this).parent().remove();
        text = text.substring(0, text.length - text.length);
        $.each($('.imageList img'), function () {
            text += $(this).attr('src') + ',';
            text = text.substring(0, text.length);
            console.log(text.length)
        })

        console.log(text)
        $('#txtImage').val(text);
    })


    // đăng ký sự kiện click nút upload
    $('#SelectImage').click(function () {
        $('#fileUpload').trigger('click');
    })
    //Bắt sự kiện cảu change data của fileUpload
    $('#fileUpload').change(function () {
        // kiểm tra trình duyệt có hỗ trợ FormData object hay không
        // !== là phép so sánh tuyệt đối
        if (window.FormData !== undefined) {
            // lấy dữ liệu rên file Upload
            var fileUpload = $('#fileUpload').get(0); // get(0) lấy control đầu tiên
            var files = fileUpload.files;//lấy các tập tin trên đó
            // tạo đối tượng formdata
            var formData = new FormData();
            // đưa dữ liệu vào form
            formData.append('file', files[0]);// lấy đầu tiên tropng tập tin khi upload 1 thì chỉ nhận đc 1
            //Post lên server
            $.ajax({
                type: 'POST',
                url: '/Admin/Product/UploadImage',
                contentType: false, // không có header
                processData: false, //không sử lý dữ liệu
                data: formData,
                success: function (url) {
                    $('.imageList').append('<div style="position:relative;margin-right: 10px;margin-bootom:10px;"><img src="' + url + '" style="width:70px;height:70px;" /><a href="#" class="btn-delImages" style="margin-left: 5px;"><i class="fa fa-times"></i></a></div>');
                    var images = ""; // khai báo 1 mảng

                    $.each($('.imageList img'), function () {
                        images += $(this).attr('src') + ',';
                    })
                    images = images.substring(0, images.length -1);
                    $('#txtImage').val(images);



                    aray = u;
                    u.each(function (index, value) {
                        aray = $(this).attr('src');
                        console.log(aray)

                    })
                    var i, j;
                    $('.btn-delImages').off('click').on('click', function (e) {
                        e.preventDefault();
                        $(this).parent().remove();
                        images = images.substring(0, images.length - images.length);
                        $.each($('.imageList img'), function () {
                            images += $(this).attr('src') + ',';
                            images = images.substring(0, images.length);
                            console.log(images.length)
                        })

                        console.log(images)
                        $('#txtImage').val(images);
                    })
                }
                , error: function (err) {
                    alert('có lỗi khi upload: ' + err.statusText);
                }
            });
        }
    })
    
})