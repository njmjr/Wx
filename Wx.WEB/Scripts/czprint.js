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
    </style>                        \
    </head><body>";
    var printForm = '<div id=\'print\'>';
    printForm += '<div class=\"juedui\" style=\"left:0px;top:-10px;\" >';
    printForm += '<table><tr><td><img width=\"95px\" height=\"80px\" src=\'/content/Images/czpingzhenglogo.jpg\' /></td><td>业务回单</td></tr></table>';
    printForm += '</div>';
    printForm += '<div class=\"juedui\" style=\"left:10px;top:75px;\" >';
    var myDate = new Date();
    printForm += myDate.getFullYear() + " 年 " + (myDate.getMonth() + 1) + " 月 " + myDate.getDate() + " 日 ";
    printForm += '</div>';
    printForm += '<div class=\"juedui\" style=\"left:10px; top:95px;\" >';
    printForm += '姓名' + printInfo.UserName;
    printForm += '</div>';



    if (typeof (printInfo.NewCardNo) != "undefined" && printInfo.NewCardNo != "") 
    {
        printForm += "<div class=\"juedui\" style=\"left:10px; top:115px;\" >";
        printForm += "卡号："+printInfo.NewCardNo;
        printForm += "</div>";
        printForm += "<div class=\"juedui\" style=\"left:10px; top:275px;\" >";
        printForm += "旧卡号："+printInfo.CardNo;
        printForm += "</div>";
    }
    else
    {
        printForm += "<div class=\"juedui\" style=\"left:10px; top:115px;\" >";
        printForm += "卡号："+printInfo.CardNo;
        printForm += "</div>";
    }

    printForm += "<div class=\"juedui\" style=\"left:10px; top:135px;\" >";
    printForm += "交易类型："+printInfo.TradeType;
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:10px; top:155px;\" >";
    printForm += "交易时间："+ myDate.toLocaleTimeString();
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:10px; top:175px;\" >";
    printForm += "交易金额："+printInfo.TradeMoney;
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:10px; top:195px;\" >";
    printForm += "卡 余 额：" + printInfo.Balance;
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:10px; top:215px;\" >";
    printForm += "服 务 费：0 ";
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:10px; top:235px;\" >";
    printForm += "经 办 人：" + printInfo.StaffID;
    printForm += "</div>";
    printForm += "<div class=\"juedui\" style=\"left:10px; top:255px;\" >";
    printForm += "流水号：" + printInfo.Other;
    printForm += "</div>";
    printForm += "</div>";
    var footstr = "</body></html>";

    var printWin = open('', 'printWindow', 'left=50,top=50,width=0,height=0');

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