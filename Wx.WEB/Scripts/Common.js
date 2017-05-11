function ChinaCost(numberValue) {
    var numberValue = new String(Math.round(numberValue * 100)); // 数字金额
    var chineseValue = ""; // 转换后的汉字金额
    var String1 = "零壹贰叁肆伍陆柒捌玖"; // 汉字数字
    var String2 = "万仟佰拾亿仟佰拾万仟佰拾圆角分"; // 对应单位
    var len = numberValue.length; // numberValue 的字符串长度
    var Ch1; // 数字的汉语读法
    var Ch2; // 数字位的汉字读法
    var nZero = 0; // 用来计算连续的零值的个数
    var String3; // 指定位置的数值
    if (len > 15) {
        alert("超出计算范围");
        return "";
    }
    if (numberValue == 0) {
        chineseValue = "零圆整";
        return chineseValue;
    }

    String2 = String2.substr(String2.length - len, len); // 取出对应位数的STRING2的值
    for (var i = 0; i < len; i++) {
        String3 = parseInt(numberValue.substr(i, 1), 10); // 取出需转换的某一位的值
        if (i != (len - 3) && i != (len - 7) && i != (len - 11) && i != (len - 15)) {
            if (String3 == 0) {
                Ch1 = "";
                Ch2 = "";
                nZero = nZero + 1;
            }
            else if (String3 != 0 && nZero != 0) {
                Ch1 = "零" + String1.substr(String3, 1);
                Ch2 = String2.substr(i, 1);
                nZero = 0;
            }
            else {
                Ch1 = String1.substr(String3, 1);
                Ch2 = String2.substr(i, 1);
                nZero = 0;
            }
        }
        else { // 该位是万亿，亿，万，元位等关键位
            if (String3 != 0 && nZero != 0) {
                Ch1 = "零" + String1.substr(String3, 1);
                Ch2 = String2.substr(i, 1);
                nZero = 0;
            }
            else if (String3 != 0 && nZero == 0) {
                Ch1 = String1.substr(String3, 1);
                Ch2 = String2.substr(i, 1);
                nZero = 0;
            }
            else if (String3 == 0 && nZero >= 3) {
                Ch1 = "";
                Ch2 = "";
                nZero = nZero + 1;
            }
            else {
                Ch1 = "";
                Ch2 = String2.substr(i, 1);
                nZero = nZero + 1;
            }
            if (i == (len - 11) || i == (len - 3)) { // 如果该位是亿位或元位，则必须写上
                Ch2 = String2.substr(i, 1);
            }
        }
        chineseValue = chineseValue + Ch1 + Ch2;
    }

    if (String3 == 0) { // 最后一位（分）为0时，加上“整”
        chineseValue = chineseValue + "整";
    }

    return chineseValue;
}

function GetCardRecordJsonObject() {
    var money = parseFloat($('#Money').val()) * 100;
    var cardRecords = [];

    for (var i = 0; i < 10; i++) {
        if ($('#hidTradeMoney').val().substr(i * 8, 8) && !isNaN($('#hidTradeMoney').val().substr(i * 8, 8))) {
            if ($('#hidTradeType').val().substr(i * 2, 2) == '02') {
                money = money - parseFloat($('#hidTradeMoney').val().substr(i * 8, 8), 10);
            } else {
                money = money + parseFloat($('#hidTradeMoney').val().substr(i * 8, 8), 10);
            }
        }
        cardRecords[i] = new Object();
        cardRecords[i].CARDNO = $('#CardNo').val();
        cardRecords[i].SEQ = (i + 1);
        cardRecords[i].CARDTRADENO = $('#hidTradeno').val().substr(i * 4, 4);
        cardRecords[i].ICTRADETYPECODE = $('#hidTradeType').val().substr(i * 2, 2);
        if ($('#hidTradeMoney').val().substr(i * 8, 8) && !isNaN($('#hidTradeMoney').val().substr(i * 8, 8))) {
            cardRecords[i].TRADEMONEY = (parseFloat($('#hidTradeMoney').val().substr(i * 8, 8), 10) / 100).toFixed(2);
        } else {

            cardRecords[i].TRADEMONEY = $('#hidTradeMoney').val().substr(i * 8, 8);
        }
        cardRecords[i].SAMNO = $('#hidTradeTerm').val().substr(i * 12, 12);
        cardRecords[i].TRADEDATE = $('#hidTradeDate').val().substr(i * 8, 8);
        cardRecords[i].TRADETIME = $('#hidTradeTime').val().substr(i * 6, 6);
        cardRecords[i].TRADEDATETIME = $('#hidTradeDate').val().substr(i * 8, 4)
            + '-' + $('#hidTradeDate').val().substr(i * 8 + 4, 2)
            + '-' + $('#hidTradeDate').val().substr(i * 8 + 6, 2)
            + ' ' + $('#hidTradeTime').val().substr(i * 6, 2)
            + ':' + $('#hidTradeTime').val().substr(i * 6 + 2, 2)
            + ':' + $('#hidTradeTime').val().substr(i * 6 + 4, 2);
        if ($('#hidTradeMoney').val().substr(i * 8, 8) && !isNaN($('#hidTradeMoney').val().substr(i * 8, 8))) {
            cardRecords[i].PREMONEY = parseFloat((money / 100), 10).toFixed(2);
        } else {
            cardRecords[i].PREMONEY = "";
        }
    }
    var reports = new Object();
    reports.total = 10;
    reports.rows = cardRecords;
    reports.ResponseStatus = new Object();
    reports.ResponseStatus.ErrorCode = "OK";
    reports.ResponseStatus.Errors = [];
    return reports;
}


function changeDepart(DepartNo, StaffNo) {
    $("#" + StaffNo + "").combobox('loadData', GetStaffList(DepartNo));
    var data = $("#" + StaffNo + "").combobox('getData');

    if (data.length > 0) {
        $("#" + StaffNo + "").combobox('select', data[0].STAFFNO);
    }
}


function GetStaffList(DepartNo) {
    var query = $.Enumerable.From(staffListInfo)
        .Where(function (x) {
            return x.DEPARTNO == DepartNo || x.DEPARTNO == "";
        })
        .ToArray();
    if (query) {
        return query;
    }
    return null;
}