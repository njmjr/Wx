using WeChat.ServiceModel.Base;

namespace Wx.WEB.ServiceModel
{
    public class ReturnCard : BaseRequest
    {
        public string CardNo { get; set; }
        public string ReasonCode { get; set; }
        public int CardMoney { get; set; }
        public int RefundMoney { get; set; }
        public int RefundDepost { get; set; }
        public int OtherFee { get; set; }
        public int TradeProFee { get; set; }
        public string CardTradeno { get; set; }
        public string Termno { get; set; }
        public string BIPCODE { get; set; }
        public string CheckCardNo { get; set; }
        public string BankCardNo { get; set; }

        public string CUSTNAME { get; set; }

        public string PAPERNO { get; set; }

    }

    public class ReturnCardResponse : BaseResponse
    {
    }
}
