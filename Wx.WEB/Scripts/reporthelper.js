function CreateFormPage(strPrintName, printDatagrid) {
    var tableString = '<h2 class="title">' + strPrintName + '<h2>'
    tableString += customerPrintFunc();
    tableString += '<table align="center" cellspacing="0" class="pb">';
    var frozenColumns = printDatagrid.datagrid("options").frozenColumns;  // 得到frozenColumns对象
    var columns = printDatagrid.datagrid("options").columns;    // 得到columns对象
    var nameList = '';

    // 载入title
    if (typeof columns != 'undefined' && columns != '') {
        $(columns).each(function (index) {
            tableString += '\n<tr>';
            if (typeof frozenColumns != 'undefined' && typeof frozenColumns[index] != 'undefined') {
                for (var i = 0; i < frozenColumns[index].length; ++i) {
                    if (!frozenColumns[index][i].hidden) {
                        tableString += '\n<th width="' + frozenColumns[index][i].width + '"';
                        if (typeof frozenColumns[index][i].rowspan != 'undefined' && frozenColumns[index][i].rowspan > 1) {
                            tableString += ' rowspan="' + frozenColumns[index][i].rowspan + '"';
                        }
                        if (typeof frozenColumns[index][i].colspan != 'undefined' && frozenColumns[index][i].colspan > 1) {
                            tableString += ' colspan="' + frozenColumns[index][i].colspan + '"';
                        }
                        if (typeof frozenColumns[index][i].field != 'undefined' && frozenColumns[index][i].field != '') {
                            nameList += ',{"f":"' + frozenColumns[index][i].field + '", "a":"' + frozenColumns[index][i].align + '"}';
                        }
                        tableString += '>' + frozenColumns[0][i].title + '</th>';
                    }
                }
            }
            for (var i = 0; i < columns[index].length; ++i) {
                if (!columns[index][i].hidden) {
                    tableString += '\n<th  ';
                    if (typeof columns[index][i].rowspan != 'undefined' && columns[index][i].rowspan > 1) {
                        tableString += ' rowspan="' + columns[index][i].rowspan + '"';
                    }
                    if (typeof columns[index][i].colspan != 'undefined' && columns[index][i].colspan > 1) {
                        tableString += ' colspan="' + columns[index][i].colspan + '"';
                    }
                    if (typeof columns[index][i].field != 'undefined' && columns[index][i].field != '') {
                        nameList += ',{"f":"' + columns[index][i].field + '", "a":"' + columns[index][i].align + '"}';
                    }
                    tableString += '>' + columns[index][i].title + '</th>';
                }
            }
            tableString += '\n</tr>';
        });
    }
    // 载入内容
    var rows = printDatagrid.datagrid("getRows"); // 这段代码是获取当前页的所有行
    var nl = eval('([' + nameList.substring(1) + '])');
    for (var i = 0; i < rows.length; ++i) {
        tableString += '\n<tr>';
        $(nl).each(function (j) {
            var e = nl[j].f.lastIndexOf('_0');

            tableString += '\n<td';
            if (nl[j].a != 'undefined' && nl[j].a != '') {
                tableString += ' style="text-align:' + nl[j].a + ';"';
            }
            tableString += '>';
            if (e + 2 == nl[j].f.length) {
                tableString += rows[i][nl[j].f.substring(0, e)];
            }
            else
                tableString += rows[i][nl[j].f];
            tableString += '</td>';
        });
        tableString += '\n</tr>';
    }
    tableString += '\n</table>';
    var headstr = "<html><head><title>打印</title>  \
            <style>     \
                *{      \
                  font-size: 12px; \
                }\
                body{ \
                   padding:50 0 50 50px; \
                }   \
      .title {\
            text-align: center;\
        }  \
        .time {\
            font-weight: normal;\
            font-size: 13px;\
            text-align: right;\
            }\
        .pb {\
            font-size: 13px;\
            width: 750px;\
            border-collapse: collapse;\
            }\
        .pb th {\
            font-weight: bold;\
            text-align: center;\
            border: 1px solid #333333;\
            padding: 2px;\
            }\
        .pb td {\
            font-weight: lighter;\
            border: 1px solid #333333;\
            padding: 2px;\
            }    \
            </style>  \
            </head><body>";
    var footstr = "";


    var printWin = open('', 'printWindow', 'left=50000,top=50000,width=0,height=0');

    printWin.document.write(headstr + tableString + footstr);
    printWin.document.close();
    printWin.document.body.insertAdjacentHTML("beforeEnd", " \
        <object id=\"printFactory\" style=\"\"   \
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