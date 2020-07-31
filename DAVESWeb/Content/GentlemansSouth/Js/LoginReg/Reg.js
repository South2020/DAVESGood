//具体配置参考：http://www.layui.com/doc/modules/layer.html#offset


layui.use('layer', function () { //独立版的layer无需执行这一句
    var $ = layui.jquery, layer = layui.layer; //独立版的layer无需执行这一句
    $.ajax({
        url: '/LoginReg/LoginReg/RegIndex',
        success: function (date) {
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
                    var type = othis.data('type')
                        , text = date;//弹出框内容
                    layer.open({
                        type: 1,
                        title: "注册"//标题
                        , offset: type
                        , id: 'layerDemo' + type //防止重复弹出
                        , content: '<div style="padding: 20px 50px;">' + text + '</div>'
                        , area: screen() < 2 ? ['90%', '80%'] : ['500px', '530px']
                        , btn: ['注册']
                        , btnAlign: 'c' //按钮居中
                        , shade: 0 //不显示遮罩
                        , yes: function () {
                            var UserAcc = $("[name=UserAcc]").val();
                            var UserPwd = $("[name=UserPwd]").val();
                            var UserName = $("[name=UserName]").val();
                            var UserID = $("[name=UserID]").val();
                            var UserPhone = $("[name=UserPhone]").val();
                            var info = {
                                UserAcc: UserAcc,
                                UserPwd: UserPwd,
                                UserName: UserName,
                                UserID: UserID,
                                UserPhone: UserPhone
                            };
                            //账号
                            if (info.UserAcc == "") {
                                layer.msg("账号不可为空", { icon: 2 });
                                return;
                            }
                            if (info.UserAcc.length<6) {
                                layer.msg("账号不可小于六位", { icon: 2 });
                                return;
                            }
                            if (info.UserAcc.length >15) {
                                layer.msg("账号过长", { icon: 2 });
                                return;
                            }
                            //密码
                            if (info.UserPwd == "") {
                                layer.msg("密码不可为空", { icon: 2 });
                                return;
                            }
                            if (info.UserPwd.length < 6) {
                                layer.msg("密码不可小于六位", { icon: 2 });
                                return;
                            }
                            if (info.UserPwd.length > 15) {
                                layer.msg("密码过长", { icon: 2 });
                                return;
                            }
                            //身份证
                            if (info.UserID.length != 18) {
                                layer.msg("身份证格式不对", { icon: 2 });
                                return;
                            }
                            //姓名
                            if (info.UserName.length == 0) {
                                layer.msg("用户名不可为空", { icon: 2 });
                                return;
                            }
                            //电话
                            if (info.UserPhone.length == 0) {
                                layer.msg("联系方式不可为空", { icon: 2 });
                                return;
                            }
                            if (info.UserPhone.length != 11) {
                                layer.msg("联系方式格式不正确", { icon: 2 });
                                return;
                            }
                            $.ajax({
                                url: "/LoginReg/LoginReg/Reg",
                                data: info,
                                type: "post",
                                success: function (date) {
                                    if (date == 1001) {
                                        layer.msg("注册成功", { icon: 1 });
                                        setTimeout(function () {
                                            layer.closeAll();
                                        }, 1000);
                                    } else if (date == 1000) {
                                        layer.msg("注册失败，请稍后再试", {icon:5});
                                    }
                                }
                            });
                        }, btn2: function () {

                        }, btn3: function () {
                            layer.closeAll();
                        }
                    });
                }
            };

            $('#Reg').on('click', function () {
                var othis = $(this), method = othis.data('method');
                active[method] ? active[method].call(this, othis) : '';
            });
        }
    });

});
