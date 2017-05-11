(function ($) {
    $.wx = $.wx || { version: 1.0 };
    $.wx.easyui = $.wx.easyui || {};
})(jQuery);
(function ($) {
    $.wx.easyui.msg = {
        tip: function (content, title, timeout, showType) {
            $.messager.show({
                title: title || "消息提示",
                msg: content,
                timeout: timeout == undefined ? 3000 : timeout,
                showType: showType || "show"
            });
        },
        info: function (content, title) {
            $.messager.alert(title || "消息提示", content, "info");
        },
        warning: function (content, title) {
            $.messager.progress('close');
            $.messager.alert(title || "警告提示", content, "warning");
        },
        question: function (content, title) {
            $.messager.alert(title || "询问提示", content, "question");
        },
        error: function (content, title) {
            $.messager.progress('close');
            $.messager.alert(title || "错误提示", content, "error");
        },
        confirm: function (content, title, onOk, onCancel) {
            $.messager.confirm(title || "请选择", content, function (isOK) {
                if (isOK) {
                    if (onOk && (typeof onOk) == "function") {
                        onOk();
                        return;
                    }
                }
                if (onCancel && (typeof onCancel) == "function") {
                    onCancel();
                }
            });
        }
    };
    $.wx.easyui.info = {
        success: function (content) {
            var infos = $('#infos');
            $('#infos').append("<li class='infos'>" + content + "</li>");
        },
        error: function (content) {
            var infos = $('#infos');
            $('#infos').append("<li class='error'>" + content + "</li>"); 
        },
        clear: function () { $('#infos').empty(); }
    };
})(jQuery);

$.extend($.fn.validatebox.defaults.rules, {
    //验证电子钱包卡号
    cardno: {
        validator: function (value) {
            var reg = /^\d{16,19}$/;
            return reg.test(value);
        },
        message: '电子钱包卡号输入有误'
    },
    //验证金额
    money: {
        validator: function (value) {
            var reg = /^(([1-9]\d{0,9})|0)(\.\d{1,2})?$/;
            return reg.test(value);
        },
        message: '金额格式错误'
    }
}) 
 