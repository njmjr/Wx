function CreatePrintPage() {
    var headstr = "<html><head><title></title> \
    <style>                         \
        .juedui {                   \
    	margin-left: 0px;            \
        margin-top: 0px;             \
    	margin-right: 0px;           \
    	margin-bottom: 0px;          \
    	background-repeat: no-repeat;\
    	font-size: 14px;             \
    	position: absolute;          \
        }                               \
         .juedui_fapiao {                   \
    	margin-left: 0px;            \
        margin-top: 0px;             \
    	margin-right: 0px;           \
    	margin-bottom: 0px;          \
    	background-repeat: no-repeat;\
    	font-size: 11px;             \
    	position: absolute;          \
        }                               \
    </style>                        \
    </head><body>   ";
    var myDate = new Date();
    var printForm = "<div id=\"print\" >";
    printForm += "<div class=\"juedui\" style=\"left:240px;top:25px;\" >";
    printForm += myDate.getFullYear();
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:285px; top:25px;\" >";
    printForm += (myDate.getMonth() + 1);
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:315px; top:25px;\" >";
    printForm += myDate.getDate();
    printForm += "</div>";

    printForm += "<div class=\"juedui\" style=\"left:605px;top:20px;\" >";
    printForm += myDate.getFullYear();
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:655px;top:20px;\" >";
    printForm += (myDate.getMonth() + 1);
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:680px;top:20px;\" >";
    printForm += myDate.getDate();
    printForm += "</div>";

    printForm += "<div class=\"juedui\" style=\"left:140px; top:55px;\" >";
    if (typeof (printInfo.CardNo) != "undefined") {
        printForm += printInfo.CardNo;
    }

    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:140px; top:76px;\" >";
    //printForm +=UserName;
    printForm += "";
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:165px; top:97px;\" >";
    //交易类型
    if (typeof (printInfo.TradeType) != "undefined") {
        printForm += printInfo.TradeType;
    }
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:165px; top:119px;\" >";
    //交易金额
    if (typeof (printInfo.TradeMoney) != "undefined") {
        printForm += printInfo.TradeMoney;
    }
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:165px; top:140px;\" >";
    //卡押金
    if (typeof (printInfo.Deposit) != "undefined") {
        printForm += printInfo.Deposit;
    }
    printForm += "</div>";

    printForm += "<div class=\"juedui\" style=\"left:280px; top:55px;\" >";
    //账号
    if (typeof (printInfo.AccoutNo) != "undefined") {
        printForm += printInfo.AccoutNo;
    }
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:280px; top:76px;\" >";
    //printForm +=ZhengJianHaoMa;
    printForm += "";
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:280px; top:97px;\" >";
    //
    if (typeof (printInfo.JiJuHao) != "undefined") {
        printForm += printInfo.JiJuHao;
    }
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:280px; top:119px;\" >";
    //余额
    if (typeof (printInfo.Balance) != "undefined") {
        printForm += printInfo.Balance;
    }
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:324px; top:140px;\" >";
    //折旧费
    if (typeof (printInfo.DeprectFee) != "undefined") {
        printForm += printInfo.DeprectFee;
    }
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:324px; top:190px;\" >";
    if (typeof (printInfo.TotalFeeCN) != "undefined") {
        printForm += printInfo.TotalFeeCN;
    }
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:200px; top:255px;\" >";
    if (typeof (printInfo.StaffID) != "undefined") {
        printForm += printInfo.StaffID;
    }
    printForm += "</div>";


    printForm += "<div class=\"juedui\" style=\"left:440px; top:55px;\" >";
    if (typeof (printInfo.TradeMode) != "undefined") {
        printForm += printInfo.TradeMode;
    }
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:440px; top:76px;\" >";
    //printForm +=ZhengJianMingChen;
    printForm += "";
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:420px; top:97px;\" >";
    if (typeof (printInfo.TradeID) != "undefined") {
        printForm += printInfo.TradeID;
    }
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:440px; top:119px;\" >";
    if (typeof (printInfo.ProdureFee) != "undefined") {
        printForm += printInfo.ProdureFee;
    }
    printForm += "</div>";

    printForm += "<div class=\"juedui\" style=\"left:370px; top:140px;\" >";
    printForm += "其他：";
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:440px; top:140px;\" >";
    if (typeof (printInfo.Other) != "undefined") {
        printForm += printInfo.Other;
    }
    printForm += "</div>";

    printForm += "<div class=\"juedui\" style=\"left:635px; top:45px;\" >";
    if (typeof (printInfo.CardNo) != "undefined") {
        printForm += printInfo.CardNo;
    }
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:652px; top:67px;\" >";
    //printForm +=UserName;
    printForm += "";
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:652px; top:88px;\" >";
    if (typeof (printInfo.TradeType) != "undefined") {
        printForm += printInfo.TradeType;
    }
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:652px; top:110px;\" >";
    if (typeof (printInfo.JiJuHao) != "undefined") {
        printForm += printInfo.JiJuHao;
    }
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:652px; top:131px;\" >";
    if (typeof (printInfo.TradeMoney) != "undefined") {
        printForm += printInfo.TradeMoney;
    }
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:652px; top:153px;\" >";
    if (typeof (printInfo.Balance) != "undefined") {
        printForm += printInfo.Balance;
    }
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:652px; top:175px;\" >";
    if (typeof (printInfo.ProdureFee) != "undefined") {
        printForm += printInfo.ProdureFee;
    }
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:652px; top:196px;\" >";
    if (typeof (printInfo.CardCost) != "undefined") {
        printForm += printInfo.CardCost;
    }
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:690px; top:218px;\" >";
    if (typeof (printInfo.DeprectFee) != "undefined") {
        printForm += printInfo.DeprectFee;
    }
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:690px; top:239px;\" >";
    if (typeof (printInfo.TotalFee) != "undefined") {
        printForm += printInfo.TotalFee;
    }
    printForm += "</div>";


    printForm += "</div>";
    var footstr = "</body></html>";


    var printWin = open('', 'printWindow', 'left=50000,top=50000,width=0,height=0');

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