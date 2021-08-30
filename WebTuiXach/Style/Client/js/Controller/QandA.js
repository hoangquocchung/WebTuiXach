$(document).ready(function () {
    $('#qc__send_require').off('click').on('click', function (e) {
        e.preventDefault();
        var emObj = {
            Name: $('.text_name_qa').val(),
            Phone: $('.text_phone_qa').val(),
            Email: $('.text_email_qa').val(),
            Content: $('.text_ghichu').val()
        };
        if ($('.text_name_qa').val() == null) {
            alert('hãy điền đủ thông tin yêu cầu');
        }
        else {
            $.ajax({
                url: "Home/QandA",
                data: JSON.stringify(emObj),
                type: "POST",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) {


                    if (result.status == true) {
                        alert('gửi tahnhf công');
                    }

                },

                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        }
    })
})