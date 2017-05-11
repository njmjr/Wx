function CreatOrderPrintPage() {
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
        table.data {font-size: 90%; border-collapse: collapse; border: 0px solid black;}  \
        table.data th {background: #bddeff; width: 25em; text-align: left; padding-right: 8px; font-weight: normal; border: 1px solid black;}\
        table.data td {background: #ffffff; vertical-align:middle;padding: 0px 2px 0px 2px; border: 1px solid black;}\
    </style>                        \
    </head><body>   ";

    var myDate = new Date();
    var printForm = "<div align= \'center \' style= \'font-size:30px \'>卡片签收入库单</div>\
   <table border=1px cellpadding=0 cellspacing=0 width=\'100%\' align=\'center\' style=\'border-style:solid\' class=\'data\'>\
                             <tr height=25px>\
                                <td align=\'center\'>入库单号</td>\
                                <td>" + printInfo.TRADEID + "</td>\
                                <td align=\'center\'>入库日期</td>\
                                <td>" + myDate.getFullYear() + "-" + (myDate.getMonth() + 1) + "-" + myDate.getDate() + " " + myDate.toLocaleTimeString() + "</td>\
                             </tr>\
                                <tr height=25px>\
                                <td align=\'center\'>供货单位</td>\
                                <td>" + printInfo.ManuName + "</td>\
                                <td align='center'>卡面名称</td>\
                                <td>" + printInfo.CardSurfaceName + "</td>\
                            </tr>\
                            <tr height=25px>\
                                <td align=\'center\'>数量</td>\
                                <td colspan=3 align=left>" + printInfo.CardNum + "</td>\
                            </tr>\
                            <tr height=25px>\
                                <td align=\'center\'>入库部门</td>\
                                <td>" + printInfo.DepartName + "</td>\
                                <td align=\'center\'>入库员工</td>\
                                <td>" + printInfo.StaffName + "</td>\
                            </tr>\
                        </table>";
    var footstr = "</body></html>";

    var printWin = open('', 'printWindow', 'left=50000,top=50000,width=0,height=0');

    printWin.document.write(headstr + "<div class=juedui>" + printForm + "</div>" + footstr);
    printWin.document.close();
    var script = "<script>printFactory.printing.leftMargin = 0.1;printFactory.printing.topMargin = 0.1;printFactory.printing.rightMargin = 0.1;printFactory.printing.bottomMargin = 0.1;</script>";
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