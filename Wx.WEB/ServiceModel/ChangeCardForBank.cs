using WeChat.ServiceModel.Base;

namespace Wx.WEB.ServiceModel
{
    public class ChangeCardForBank : BaseRequest
    {
        public string BIPCODE { get; set; }
        public string TradeTypeCode { get; set; }
        public string NewCardNo { get; set; }
        public string OldCardNo { get; set; }

        public string BankCardNo { get; set; }
        public string ChangeTypeCode { get; set; }
        public int CurrentMoney { get; set; }
        //public string CardTradeNo { get; set; }
        //public string Termno { get; set; }
        //public string CheckCardNo { get; set; }
        //public int Deposit { get; set; }
        //public int CardCost { get; set; }

        public string Name { get; set; }


        public string PaperTypeCode { get; set; }
        public string PaperNo { get; set; }

        public string Birth { get; set; }

        public string Sex { get; set; }

        public string Phone { get; set; }

        public string CustPost { get; set; }

        public string CustAddr { get; set; }

        public string CustEmail { get; set; }


        public int CardaccMoney { get; set; }


        public string ACPTSIDE { get; set; }

        public string OldBankCardNo { get; set; }

       


    }

    public class ChangeCardForBankResponse : BaseResponse
    {
        public string CardNo { get; set; }

    }
}
