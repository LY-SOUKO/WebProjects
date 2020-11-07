!(function () {
    $(function () {
        href = "/Common/Login/ajax/HandlerLogin.ashx"
        bingData();
        clickData();
    });
    function bingData() {
        $(".captcha-code").hide();
        $("#hidCore").val("");
        $(".tips-text").html("");
    }
    function clickData() {
        $("#btnOk").click(function () {
            loginOn();
        })


        document.onkeydown = function (e) {
            
            if (!e) {
                e = window.event;
            }
            if ((e.keyCode || e.which) == 13) {
                
                loginOn();
            }
        }
    }
    function loginOn() {

        var userName = $(".name").val();//账号
        var password = $(".password").val();//密码
        var codeer = $(".code").val();//验证码
        var codeOld = $("#code").val();//验证码生成器
        var hidCore = $("#hidCore").val();//是否需要验证码
        if (userName.trim().length == 0 && password.trim().length == 0) {
            $(".tips-text").html("请输入账号以及密码！");
            return false;
        }
        if (userName.trim().length == 0) {
            $(".tips-text").html("请输入账号！");
            return false;
        }
        if (password.trim().length == 0) {
            $(".tips-text").html("请输入密码！");
            return false;
        }
        if (hidCore == "验证") {
            if (codeer.trim().length == 0) {

                $(".tips-text").html("请输入验证码！");
                return false;
            }
            if (codeer != codeOld) {
                $(".tips-text").html("验证码输入错误！");
                return false;
            }

        }
        var parameters = {
            cmd: "getLogin",
            userName: userName,
            password: password
        }
        $.post(href, parameters, function (jsonData) {

            if (jsonData.state == "success") {
                $(".tips-text").html(jsonData.msg);
                window.location.href = "/Common/Student/StudentList.aspx";
            }
            else {
                $(".tips-text").html(jsonData.msg);
                $(".captcha-code").show();
                $("#hidCore").val("验证");
            }
        })
    }
})();