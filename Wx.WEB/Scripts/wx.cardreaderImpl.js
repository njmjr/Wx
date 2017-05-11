(function ($) {
    $.wx = $.wx || { version: 1.0 };
    $.wx.ocx = $.wx.ocx || {};
})(jQuery);
(function ($) {
    $.wx.ocx.IDCardInfo = function (name, sex, birth, addr, paperno, pic) {
        this.name = name;
        this.sex = sex;
        this.birth = birth;
        this.addr = addr;
        this.paperno = paperno;
        this.pic = pic
    }

    $.wx.ocx.CardInfo = function (cardNo, appType, appVersion, appSn,
    appStartDate, appEndDate, FCI, cardType, tradeNo, balance, staffTag, wallet2) {
        this.cardNo = cardNo;
        this.appType = appType;
        this.appVersion = appVersion;
        this.appSn = appSn;
        this.appStartDate = appStartDate;
        this.appEndDate = appEndDate;
        this.FCI = FCI;
        this.cardType = cardType;
        this.tradeNo = tradeNo;
        this.balance = balance;
        this.staffTag = staffTag;
        this.wallet2 = wallet2;
    }

    $.wx.ocx.CardRecord = function (tradeNo, tradeMoney, tradeType, tradeTerm,
tradeDate, tradeTime) {
        this.tradeNo = tradeNo;
        this.tradeMoney = tradeMoney;
        this.tradeType = tradeType;
        this.tradeTerm = tradeTerm;
        this.tradeDate = tradeDate;
        this.tradeTime = tradeTime;
    }

    $.wx.ocx.readDriverInfoImpl =  function (staffCtlId, cardNoId, taxiNoId, stateId, useTag) {
        cardReader.readCardFunc = cardReader.getDriverInfo;
        var driverInfo = TargetWindowReadCard();

        if (driverInfo == null) return null;

        $get(staffCtlId).value = driverInfo.baseInfo.substr(0, 6);

        if (taxiNoId != null) {
            var taxiNo = driverInfo.baseInfo.substr(6, 12);
            if (taxiNo == 'FFFFFFFFFF') {
                $get(taxiNoId).value = 'FFFFFFFFFF';
            }
            else {
                $get(taxiNoId).value =
                    // String.fromCharCode(parseInt(taxiNo.substr(0,2),16)) +
                    String.fromCharCode(parseInt(taxiNo.substr(2, 2), 16)) +
                    String.fromCharCode(parseInt(taxiNo.substr(4, 2), 16)) +
                    String.fromCharCode(parseInt(taxiNo.substr(6, 2), 16)) +
                    String.fromCharCode(parseInt(taxiNo.substr(8, 2), 16)) +
                    String.fromCharCode(parseInt(taxiNo.substr(10, 2), 16));
            }
        }

        if (stateId != null) {
            $get(stateId).value = driverInfo.specialInfo.substr(0, 2);
        }

        if (useTag != null) {
            cardReader.readCardFunc = cardReader.getCardInfo;
            var cardInfo = TargetWindowReadCard();
            if (cardInfo == null) {
                return false;
            }

            $get(useTag).value = cardInfo.staffTag;

            assignValue(cardNoId, cardInfo.cardNo);
        }
        else {
            if (cardNoId != null) {
                cardReader.readCardFunc = cardReader.getCardNo;
                var cardNo = TargetWindowReadCard();
                if (cardNo == null) {
                    return false;
                }
                $get(cardNoId).value = cardNo;
            }
        }

        return driverInfo;
    }

    $.wx.ocx.CardReader = {
        ErrInfo: null,
        ErrRet: null,
        OperateCardNo: '9150020184000581',
        readCardFunc: null,
        writeCardFunc: null,
        CardInfo: null,
        CardRecord:null,
        CardNo: null,
        IDInfo: null,
        testingMode: false,
        readCallback: null,
        preMoney: 0,
        chargeMoney: 0,
        targetWin : null,
        terminalNo: '112233445566',
        monthlyInfo: null,
        endDate:null,
        city: null,
        cardHolderName: null,
        cardHolderPaperno: null,
        ReadCard: function (targetWindow,showErr) {
            var ret = this.ReadCardImpl();
            if (this.ErrRet != 0) {
                targetWindow.showReadCardErr(this.ErrInfo, this.ErrRet, showErr == null ? true : showErr);
            }
            return ret;
        },
        ReadCardImpl: function () {
            var ret = null;
            if (this.readCardFunc == null) return null;
            try {
                //this.setToken(); 
                if (this.readCardFunc.length == null || this.readCardFunc.length == 0) {
                    ret = this.readCardFunc();
                }
                else {
                    var func;
                    for (var i = 0; i < this.readCardFunc.length; ++i) {
                        func = this.readCardFunc[i];
                        ret = func.call(this);
                        if (this.ErrRet != 0) break;
                    }
                }
            }
            catch (ex)//catch the ex 
            {
                this.ErrRet = ex.number;
                this.ErrInfo = ex.description;
            }
            return ret;
        },
        GetCardInfo: function () {
            return this.GetCardInfoImpl(false); //false
        },
        GetCardInfoImpl: function (ex) {
            this.ErrRet = ex
                ? CardCtrl.ReadInfoEx(this.OperateCardNo)
                : CardCtrl.ReadInfo(this.OperateCardNo);
            if (this.ErrRet != 0) {
                this.ErrInfo = CardCtrl.ErrInfo;
                this.CardInfo = null;
            }
            else {
                this.CardInfo = new $.wx.ocx.CardInfo(CardCtrl.CARDNO, CardCtrl.AppType, CardCtrl.AppVersion,
                    CardCtrl.AppSn, CardCtrl.AppStartDate, CardCtrl.AppEndDate, CardCtrl.FCI,
                    CardCtrl.CardType, CardCtrl.Tradeno, CardCtrl.Balance, CardCtrl.StaffTag);
                this.CardNo = CardCtrl.CARDNO;
            }

            return this.CardInfo;
        },
        GetIDCardInfo: function () {
            if (this.city == 'xz') {
                this.ErrRet = CardCtrl.ReadIdentifyCard(this.OperateCardNo);
            }
            else {
                this.ErrRet = CardCtrl.ReadIdentifyCard();
            }
            if (this.ErrRet != 0) {
                this.ErrInfo = CardCtrl.ErrInfo;
                this.IDInfo = null;
            }
            else {
                this.IDInfo = new $.wx.ocx.IDCardInfo(CardCtrl.Name,
                    CardCtrl.Gender, CardCtrl.Birth, CardCtrl.Addr, CardCtrl.Paperno, CardCtrl.Photo);
            }
            return this.IDInfo;
        },
        GetCardNo: function () {
            this.ErrRet = CardCtrl.ReadCardNo();
            if (this.ErrRet != 0) {
                this.ErrInfo = CardCtrl.ErrInfo;
                this.CardNo = null;
            }
            else {
                //this.CardInfo = new $.wx.ocx.CardInfo(CardCtrl.CARDNO, CardCtrl.AppType, CardCtrl.AppVersion,
                //  CardCtrl.AppSn, CardCtrl.AppStartDate, CardCtrl.AppEndDate, CardCtrl.FCI,
                //  CardCtrl.CardType, CardCtrl.Tradeno, CardCtrl.Balance, CardCtrl.StaffTag);
                this.CardInfo = new $.wx.ocx.CardInfo(CardCtrl.CARDNO,null, null,
                null,null, null, null, null, null, null, null);

                this.CardNo = CardCtrl.CardNo;
            }
            return this.CardNo;
        },
        ChargeCard: function () {
            try {
                this.ErrRet = CardCtrl.Load(this.OperateCardNo, this.CardNo,
                this.preMoney, this.chargeMoney, this.terminalNo);
                if (this.ErrRet != 0) {
                    this.ErrInfo = CardCtrl.ErrInfo;
                    return false;
                }
                return true;
            }
            catch (e) {
                this.ErrRet = "写卡不成功，请检查";
                return false;
            }
        },
        WriteCard: function (targetWindow) {
            this.targetWin = targetWindow;
            $.post('../Home/GetToken', { 'cardno': this.OperateCardNo }, function (result) {
                if (result) { 
                    CardCtrl.Token = result;
                    cardReader.WriteCardImpl();
                }
                else {
                    this.ErrRet = '001';
                    this.ErrInfo = '获取令牌失败';
                }
            }); 
        }, 
        WriteCardImpl: function () {
            var ret = null;
            if (this.writeCardFunc == null) return null;

            try {
                if (this.writeCardFunc.length == null || this.writeCardFunc.length == 0) {
                    ret = this.writeCardFunc();
                }
                else {
                    var func;
                    for (var i = 0; i < this.writeCardFunc.length; ++i) {
                        func = this.writeCardFunc[i];
                        ret = func.call(this);

                        if (this.ErrRet != 0) break;
                    }
                }
            }
            catch (ex)//catch the ex 
            {
                // alert(ex.number+"\n"+ex.description); 
                this.ErrRet = ex.number;
                this.ErrInfo = ex.description;
            }

            this.targetWin.writeCompleteCallBack();
            this.targetWin = null;
            this.CardNo = null;

            return ret;
        },
        GetOperCardNo: function () {
            if (this.city != 'sz' && this.city != 'WJ') {
                this.ErrRet = CardCtrl.ReadOperCardNo(this.city);
            }
            else {
                this.ErrRet = CardCtrl.ReadOperCardNo();
            }
            if (this.ErrRet != 0) {
                this.ErrInfo = CardCtrl.ErrInfo;
                this.OperCardNo = null;
            }
            else {
                this.OperCardNo = CardCtrl.OperCardNo;
            }
            return this.OperCardNo;
        },
        lockCard: function () {
            this.ErrRet = CardCtrl.Lock(this.OperateCardNo, this.CardNo);
            if (this.ErrRet != 0) {
                this.ErrInfo = CardCtrl.ErrInfo;
                return false;
            }

            return true;
        },
        unlockCard: function () {
            this.ErrRet = CardCtrl.UnLock(this.OperateCardNo);
            if (this.ErrRet != 0) {
                this.ErrInfo = CardCtrl.ErrInfo;
                return false;
            }

            return true;
        },
        unchargeCardEx : function() { return this.unchargeCardImpl(true); },
        unchargeCard: function () { return this.unchargeCardImpl(false); },
        unchargeCardImpl: function (ex) {
            //            alert(this.OperateCardNo + "," + this.CardNo + "," + 
            //                this.preMoney  + "," +  this.chargeMoney);
            this.ErrRet = ex
                ? CardCtrl.UnLoadEx(this.OperateCardNo, this.CardNo,
                this.preMoney, this.chargeMoney, this.terminalNo)
                : CardCtrl.UnLock(this.OperateCardNo, this.CardNo,
                this.preMoney, this.chargeMoney, this.terminalNo);
            if (this.ErrRet != 0) {
                this.ErrInfo = CardCtrl.ErrInfo;
                return false;
            }

            return true;
        },
        GetRecords : function() {
            this.ErrRet = CardCtrl.ReadRecord(this.OperateCardNo);
            if (this.ErrRet != 0) {
                this.ErrInfo = CardCtrl.ErrInfo;
                this.CardRecord = null;
            }
            else {
                this.CardRecord = new $.wx.ocx.CardRecord(CardCtrl.TradenoRec, CardCtrl.TradeMoneyRec, CardCtrl.TradeTypeRec,
                    CardCtrl.TradeTermRec, CardCtrl.TradeDateRec, CardCtrl.TradeTimeRec);
            }

            return this.CardRecord;
        },
        WriteMonthlyInfo : function() {
            var apptype = this.monthlyInfo;
            this.ErrRet = CardCtrl.StartYuepiao(this.OperateCardNo, this.CardNo, apptype);
            if (this.ErrRet != 0) {
                this.ErrInfo = CardCtrl.ErrInfo;
                return false;
            } 
            return true;
        },
        ModifyEndDate : function() {
            this.ErrRet = CardCtrl.ModifyEndDate(this.OperateCardNo, this.CardNo,
                this.endDate);
            if (this.ErrRet != 0) {
                this.ErrInfo = CardCtrl.ErrInfo;
                return false;
            } 
            return true;
        },
        ChangeCardHolder: function () {
            $.post('../Home/GetToken', { 'cardno': this.OperateCardNo }, function (result) {
                if (result) {
                    CardCtrl.Token = result;
                }
                else {
                    this.ErrRet = '001';
                    this.ErrInfo = '获取令牌失败';
                }
            });
             this.ErrRet = CardCtrl.WriteCardHolder(this.OperateCardNo, this.CardNo,
             this.cardHolderName,this.cardHolderPaperno);
             if (this.ErrRet != 0) {
                    this.ErrInfo = CardCtrl.ErrInfo;
                    return false;
             }
             return true;
           
        },
        startCard: function () {
            this.ErrRet = CardCtrl.StartCard(this.OperateCardNo, this.CardNo);
            if (this.ErrRet != 0) {
                this.ErrInfo = CardCtrl.ErrInfo;
                return false;
            }

            return true;
        }
    };
})(jQuery);

