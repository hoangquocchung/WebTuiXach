$('#btnSelectImage').on('click', function (e) {
    e.preventDefault();//bỏ qua dấu thăng
    var finder = new CKFinder();
    finder.selectActionFunction = function (url) {
        $('#txtImage').val(url);
    };
    finder.popup();
});
var editor = CKEDITOR.replace('txtContent2', {
    customConfig: '/Style/Admin/plugins/ckeditor/config.js',
});