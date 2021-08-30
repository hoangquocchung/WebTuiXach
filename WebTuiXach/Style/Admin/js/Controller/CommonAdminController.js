$(document).ready(function () {
    $('.btn_check').click(function () {
        var text = "";
        var d = $(this).val();
        $('#MainMenu').val(d);
        console.log(d);
        $('.btn_check:checked').each(function () {
            text += $(this).val() + ',';
        });
        text = text.substring(0, text.length - 1);
        $("#ParentID").val(text);
    })
    ////////////////////////////////////////////////////////
    var aray = "";
    var a = new Array();
    var checkedValue = $('.btn_check');
    var c = $("#ParentID");
    aray = checkedValue;
    a = c.val().split(',');
    var i, j;
    for (i = 0; i <= a.length; i++) {
        checkedValue.each(function (index, value) {
            aray = $(this).val();
            if (a[i] == aray) {
                //console.log(aray)
                $('.btn_check')[index].checked = true;
                
            }

        })
    }
});