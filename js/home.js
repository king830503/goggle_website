

$(function(){
    $(document).ready(function () {
        $("#btnmenu").click(function () {
            $('body').toggleClass('active');
        });
        $("nav ul li a").click(function () {
            if ($("body").hasClass("active")) {
                $("body").removeClass("active");
            }
        });
        $(".group1").colorbox();
    });

        $(window).scroll(function () {

            var ST = $(window).scrollTop();

            if (ST > 0) {
                var TOP = $(window).height() -60;

                $("#goTop").stop().animate({ top: TOP });

            } else {
                $("#goTop").stop().animate({ top: -44});

            }
            var wd = $(window).width();
            if (wd <= 960) {

            }
        })
        $("#goTop").click(function () {

            $("html,body").stop().animate({ scrollTop: 0 });

            return false;
        })
    //弹出登录
        $("#SIGN").on('click', function () {
            $("body").append("<div id='mask'></div>");
            $("#mask").addClass("mask").fadeIn("slow");
            $("body").css({ overflow: 'hidden' });
            $("#LoginBox").fadeIn("slow");
        });
    //
    //按钮的透明度
        $("#loginbtn").hover(function () {
            $(this).stop().animate({
                opacity: '1'
            }, 600);
        }, function () {
            $(this).stop().animate({
                opacity: '0.8'
            }, 1000);
        });
    //文本框不允许为空---按钮触发
        $("#loginbtn").on('click', function () {
            var txtName = $("#txtName").val();
            var txtPwd = $("#txtPwd").val();

            if (txtName == "" || txtName == undefined || txtName == null) {
                if (txtPwd == "" || txtPwd == undefined || txtPwd == null) {
                    $(".warning").css({ display: 'block' });
                    $("#loginbtn").attr('disabled', true);
                }
                else {
                    $("#warn").css({ display: 'block' });
                    $("#warn2").css({ display: 'none' });
                    $("#loginbtn").attr('disabled', true);
                }
            }
            else {
                if (txtPwd == "" || txtPwd == undefined || txtPwd == null) {
                    $("#warn").css({ display: 'none' });
                    $("#warn2").css({ display: 'block' });
                    $("#loginbtn").attr('disabled', true);
                }
                else {
                    $(".warning").css({ display: 'none' });
                    $("#loginbtn").attr('disabled', false);
                }

            }
        });
    //文本框不允许为空---单个文本触发
        $("#txtName").on('blur', function () {
            var txtName = $("#txtName").val();
            if (txtName == "" || txtName == undefined || txtName == null) {
                $("#warn").css({ display: 'block' });
                $('#loginbtn').attr('disabled', false);
            }
            else {
                $("#warn").css({ display: 'none' });
                $('#loginbtn').attr('disabled', false);
            }
        });
        $("#txtName").on('focus', function () {

            $("#warn").css({ display: 'none' });
        });
    //
        $("#txtPwd").on('blur', function () {
            var txtName = $("#txtPwd").val();
            if (txtName == "" || txtName == undefined || txtName == null) {
                $('#loginbtn').attr('disabled', false);
                $("#warn2").css({ display: 'block' });
            }
            else {
                $("#warn2").css({ display: 'none' });
                $('#loginbtn').attr('disabled', false);
            }
        });
        $("#txtPwd").on('focus', function () {
            $("#warn2").css({ display: 'none' });
        });
    //关闭
        $(".close_btn").hover(function () { $(this).css({ color: '#999' }) }, function () { $(this).css({ color: 'black' }) }).on('click', function () {
            $("#LoginBox").fadeOut("fast");
            $("body").css({ overflow : 'auto' });
            $("#mask").css({ display: 'none' });
        });

        $(document).ready(function () {
            $("#forget").click(function () {
                $("#panel").slideToggle("slow");
            });
        });
        $("#emailbtn").on('click', function () {
            var mail = $("#mail").val();
            var reg = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z]+$/;

            if (mail == "" || mail == undefined || mail == null) {
                if (!reg.test(mail)) {

                    $("#warn3").css({ display: 'block' });
                    $("#warn3").text("請輸入信箱");
                    $('#emailbtn').attr('disabled', true);
                }
            }
            else {
                if (!reg.test(mail)) {

                    $("#warn3").css({ display: 'block' });
                    $("#warn3").text("信箱格式有誤");
                }
                else {
                    $(".warning2").css({ display: 'none' });
                    $('#emailbtn').attr('disabled', false);
                }
            }
        });
    //文本框不允许为空---单个文本触发
        $("#mail").on('blur', function () {
            var mail = $("#mail").val();
            var reg = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z]+$/;
            if (mail == "" || mail == undefined || mail == null) {

                $("#warn3").css({ display: 'block' });
                $("#warn3").text("請輸入信箱");
            }
            else if (!reg.test(mail)) {
                $("#warn3").css({ display: 'block' });
                $("#warn3").text("信箱格式有誤");
            }
            else {
                $(".warning2").css({ display: 'none' });
                $('#emailbtn').attr('disabled', false);
            }
        });
        $("#mail").on('focus', function () {
            $("#warn3").css({ display: 'none' });
        });
      
});
