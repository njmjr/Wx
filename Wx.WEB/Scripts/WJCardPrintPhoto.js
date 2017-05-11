//打印模板
function PrintTemplate() {
    document.getElementById('divImg').className = 'juedui template6';
   
    var headarr = [];
    headarr.push("<html><head><title>打印</title>");
    headarr.push("<style type='text/css'>");
    headarr.push(".juedui {");
    headarr.push("margin-left: 0px; ");
    headarr.push("margin-top:  0px;  ");
    headarr.push("margin-right: 0px;");
    headarr.push("margin-bottom: 0px;");
    headarr.push("background-repeat: no-repeat;");
    headarr.push("position: absolute; }");
    headarr.push(".template1{top:210px;left:28px;}");
    headarr.push(".template1 img{width:111px !important; height:91px !important;}");
    headarr.push(".template2{top:22px;left:28px;}");
    headarr.push(".template2 img{width:148px !important; height:118px !important;}");
    headarr.push(".template3{top:10px;left:40px;}");
    headarr.push(".template3 img{width:117px !important; height:84px !important;}");
    headarr.push(".template4{top:21px;left:32px;}");
    headarr.push(".template4 img{width:138px !important; height:100px !important;}");
    headarr.push(".template5{top:22px;left:14px;}");
    headarr.push(".template5 img{width:75px !important; height:75px !important;}");
    headarr.push(".template6{top:197px;left:41px;}");
    headarr.push(".template6 img{width:116px !important; height:96px !important;}");
    headarr.push("</style>");
    headarr.push("</head><body>");
    var headstr = headarr.join('');
    var footstr = "</body></html>";
    var newstr = document.all('PrintArea').innerHTML; 
    var printWin = open('', 'printWindow', 'left=50000,top=50000,width=220,height=375');
    printWin.document.write(headstr + newstr + footstr); 
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
    $('#btnPrint').attr("disabled", 'disabled');
    //if ($('#hidIsCapture').val() == '1')
    //    setTimeout("$('#btnSave').click()", 1000);
    return false;
}