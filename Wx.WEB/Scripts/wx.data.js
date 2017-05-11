(function ($) {
    $.wx = $.wx || { version: 1.0 };
})(jQuery);
(function ($) {
    $.wx.data = {
        bool: [{ id: false, text: "否" }, { id: true, text: "是" }],
        bools: function (txtFalse, txtTrue) {
            if (txtFalse == null) txtFalse = "否";
            if (txtTrue == null) txtTrue = "是";
            return [{ id: false, value: false, text: txtFalse }, { id: true, value: true, text: txtTrue }];
        },
        formatPrice: function (val, row) {
            if ((val && !isNaN(val)) || val == 0) {
                return (val/100).toFixed(2);
            }
            else{
                return "";
            }
        },
        //获取远程数据更新Column的Editor数据
        updateColumnEditorData: function (url, columns, index) {
            $.getJSON(url, function (data) {
                var $columns = $(columns);
                $columns[index].editor.data = data;
            });
        }
    };
})(jQuery);