//具体配置参考：http://www.layui.com/doc/modules/layer.html#offset
layui.use('layer', function () { //独立版的layer无需执行这一句
    var $ = layui.jquery, layer = layui.layer; //独立版的layer无需执行这一句




    //触发事件
    var active = {
        offset: function (othis) {
            function screen() {
                //获取当前窗口的宽度
                var width = $(window).width();
                if (width > 1200) {
                    return 3;   //大屏幕
                } else if (width > 992) {
                    return 2;   //中屏幕
                } else if (width > 768) {
                    return 1;   //小屏幕
                } else {
                    return 0;   //超小屏幕
                }
            }
            
            $.ajax({
                url: '/LoginReg/LoginReg/LoginIndex',
                success: function (date) {
                    var type = othis.data('type')
                        , text = date;//弹出框内容
                    layer.open({
                        type: 1,
                        title: "登录"//标题
                        , offset: type
                        , id: 'layerDemo' + type //防止重复弹出
                        , content: '<div class="login">' + text + '</div>'
                        , area: screen() < 2 ? ['90%', '80%'] : ['500px', '320px']
                        , btn: ['登录']
                        , btnAlign: 'c' //按钮居中
                        , shade: 0 //不显示遮罩
                        , yes: function () {
                            var UserAcc = $("[name=UserAcc]").val();
                            var UserPwd = $("[name=UserPwd]").val();
                            if (UserAcc == "" || UserPwd == "") {
                                setTimeout(function () {
                                    layer.msg("请正确填写账号或密码", { icon: 5 });
                                }, 500);
                                return;
                            }
                            var info = {
                                UserAcc: UserAcc,
                                UserPwd: UserPwd
                            };
                            $.ajax({
                                url: "/LoginReg/LoginReg/Login",
                                data: info,
                                type: "post",
                                success: function (date) {
                                    if (date == 1001) {
                                        setTimeout(function () {
                                            layer.closeAll();
                                            layer.msg("登录成功", { icon: 1 });
                                        }, 500);
                                        setTimeout(function () {
                                            history.go(0);
                                        }, 1500);
                                    } else if (date == 1000) {
                                        setTimeout(function () {
                                            layer.msg("登录失败，账号或者密码错误", { icon: 5 });
                                        }, 500);
                                    } else if (date == 0) {
                                        setTimeout(function () {
                                            layer.msg("程序出现错误，请联系维修员", { icon: 1 });
                                        }, 500);
                                    }
                                }
                            });
                        }, btn2: function () {

                        }, btn3: function () {
                            layer.closeAll();
                        }
                    });
                }
            });

        }
    };

    $('#Login').on('click', function () {
        var othis = $(this), method = othis.data('method');
        active[method] ? active[method].call(this, othis) : '';
    });
    $("#ShopCarGLJoin").on("click", function () {
        var othis = $(this), method = othis.data('method');
        active[method] ? active[method].call(this, othis) : '';
    });

});
