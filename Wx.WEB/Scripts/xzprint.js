function CreatePrintPage() {
    var headstr = "<html><head><title></title> \
    <style>                         \
        * {                   \
    	margin-left: 0px;           \
        margin-top: 2px;             \
    	margin-right: 0px;           \
    	margin-bottom: 2px;          \
    	font-size: 12px;             \
        font-family: 黑体 ;          \
        }                            \
     </style>                        \
    </head><body>   ";
    var printForm = '<div id=\'print\'>';
    printForm += '<div style=\'width:175px;\'>';
    if (typeof (printInfo.TradeType) != "undefined" && printInfo.TradeType != "") {
        printForm += '<p style=\'margin-top: 10px;\'>徐州市市民卡';
        printForm += printInfo.TradeType;
        printForm += '小票</p>'
    }
    if (typeof (printInfo.TradeID) != "undefined" && printInfo.TradeID != "") {
        printForm += '<p>凭证号：';
        printForm += printInfo.TradeID;
        printForm += '</p>'
    }
    if (typeof (printInfo.TradeMode) != "undefined" && printInfo.TradeMode != "") {
        printForm += '<p>网点名称：';
        printForm += printInfo.TradeMode;
        printForm += '</p>'
    }
    if (typeof (printInfo.StaffID) != "undefined" && printInfo.StaffID != "") {
        printForm += '<p>操作员：';
        printForm += printInfo.StaffID;
        printForm += '</p>'
    }
    if (typeof (printInfo.CardNo) != "undefined" && printInfo.CardNo != "") {
        printForm += '<p>用户卡号：';
        printForm += printInfo.CardNo;
        printForm += '</p>'
    }
    if (typeof (printInfo.UserName) != "undefined" && printInfo.UserName != "") {
        printForm += '<p>姓名：';
        printForm += printInfo.UserName;
        printForm += '</p>'
    }
    if (typeof (printInfo.PaperNo) != "undefined" && printInfo.PaperNo != "") {
        printForm += '<p>证件号码：';
        printForm += printInfo.PaperNo;
        printForm += '</p>'
    }
    if (typeof (printInfo.TradeMoney) != "undefined") {
        printForm += '<p>金额：';
        printForm += printInfo.TradeMoney;
        printForm += '元</p>'
        if (typeof (printInfo.Balance) != "undefined") {
            printForm += '<p>余额：';
            printForm += printInfo.Balance;
            printForm += '元</p>'
        }
    }
    if (parseInt(printInfo.TotalFee) < 0) {
        if (printInfo.TotalFee != "undefined") {
            printForm += '<p>退款金额：';
            printForm += printInfo.TotalFee;
            printForm += '元</p>'
        }
    }
    if (typeof (printInfo.AppType) != "undefined" && printInfo.AppType != "") {
        printForm += '<p>月票类型：';
        printForm += printInfo.AppType;
        printForm += '</p>'
    }
    if (typeof (printInfo.Other) != "undefined" && printInfo.Other != "" && printInfo.Other != "0.00") {
        printForm += '<p>';
        printForm += printInfo.Other;
        printForm += '</p>'
    }
    var myDate = new Date();
    printForm += '<p>交易时间';
    printForm += myDate.getFullYear() + "-" + (myDate.getMonth() + 1) + "-" + myDate.getDate() + " " + myDate.toLocaleTimeString();
    printForm += '</p>';
    printForm += '<img width=\'200px\' height=\'59px\' src=\'/content/Images/xzsmk.png\' />';
    printForm += '</div>';
    printForm += '</div>';

    var footstr = "</body></html>";

    var printWin = open('', 'printWindow', 'left=0,top=0,width=0,height=0');

    printWin.document.write(headstr + printForm + footstr);
    printWin.document.close();

    printWin.document.body.insertAdjacentHTML("beforeEnd", " \
        <object id=\"printFactory\" style=\"display:none\"   \
         classid=\"clsid:1663ED61-23EB-11D2-B92F-008048FDD814\"> \
        </object>");

    printWin.focus();
    if (printWin.printFactory.object) {

        printWin.printFactory.printing.Print(false);
    }
    else {
        printWin.print();
    }
    printWin.close();

    return false;
}