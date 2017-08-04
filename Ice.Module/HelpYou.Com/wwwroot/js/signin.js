var bgImgs = ['../images/01.jpg', '../images/02.jpg']
var currentIndex = 0;
function changeBg() {
    //定义要切换的背景图片，双引号里面，可以放任意多个
    if (currentIndex >= bgImgs.length)
        currentIndex = 0;
    var obj = document.getElementsByTagName("BODY")[0];
    obj.style.backgroundImage = "url(" + bgImgs[currentIndex] + ")"
    currentIndex += 1;
}
setInterval(changeBg, 3000); //设定定时切换，单位为毫秒，比如：30分钟=1800秒=1800000毫秒

var $sub = $("#submit");//提交按钮
var $cal = $("#cancel");//取消按钮
//提交注册
$sub.on("click", function () {
    var email = $.trim($("#email").val());
    var pw1 = $.trim($("#pw1").val());
    var pw2 = $.trim($("#pw2").val());
    var param = { email: email, pw1: pw1, pw2: pw2 }
    $.ajax({
        type: 'post',
        data: param,
        url: 'Custom/SignIn',
        beforeSend: function () {
            if (email == '' || email == 'undefined') {
                alert("邮箱名不能为空"); return false;
            }
            if (pw1 == '' || pw1 == 'undefined') {
                alert("请输入密码"); return false;
            }
            if (pw2 == '' || pw2 == 'undefined') {
                alert("请再次输入密码"); return false;
            }
            if (pw1 != pw2) {
                alert("两次密码输入不一致"); return false;
            }
        },
        success: function (res) {

        }
    });

})
//取消注册
$cal.on("click", function () {
    window.location.href = 'http://helpyou.net.cn';
})