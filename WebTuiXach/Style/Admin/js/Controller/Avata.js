$(document).ready(function () {
    var a = "";
    var c = $('#txtImages').val();
    if ($('#txtImages').val() != '') {
        $('.avata').html('<div style="position:relative,margin-right: 10px;margin-bootom:10px;"><img src="' + c + '" style="width:70px;height:70px;" /><a href="#" class="btn-delImages" style="margin-left: 5px;"><i class="fa fa-times"></i></a></div>');

    }



    // đăng ký sự kiện click nút upload
    $('#SelectImages').click(function () {
        $('#fileUploads').trigger('click');
    })
    //Bắt sự kiện cảu change data của fileUpload
    $('#fileUploads').change(function () {
        // kiểm tra trình duyệt có hỗ trợ FormData object hay không
        // !== là phép so sánh tuyệt đối
        if (window.FormData !== undefined) {
            // lấy dữ liệu rên file Upload
            var fileUpload = $('#fileUploads').get(0); // get(0) lấy control đầu tiên
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
                    $('.avata').html('<div style="position:relative,margin-right: 10px;margin-bootom:10px;"><img src="' + url + '" style="width:70px;height:70px;" /><a href="#" class="btn-delImages" style="margin-left: 5px;"><i class="fa fa-times"></i></a></div>');
                    $('#txtImages').val(url);
                    if ($('#txtImages').val() != '') {
                        $('.btn-delImages').off('click').on('click', function (e) {
                            e.preventDefault();
                            $(this).parent().remove();


                            var text = '';
                            $('#txtImages').val(text);
                        })
                    }

                }
                , error: function (err) {
                    alert('có lỗi khi upload: ' + err.statusText);
                }
            });
        }
    })
})