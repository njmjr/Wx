using WeChat.ServiceModel.Base;


namespace Wx.WEB.ServiceModel
{
    /// <summary>
    /// 补卡接口
    /// </summary>
    public class MakeUpCard : BaseRequest
    {
        public string BIPCODE { get; set; }
        public string RequestType { get; set; }
        public string BankCardNo { get; set; }
        public string CardNo { get; set; }
        public string CustName { get; set; }
        public string OldCardNo { get; set; }
        public string OldBankCardNo { get; set; }
        public string PaperNo { get; set; }
        public string TermNo { get; set; }
        public string CardTradeNo { get; set; }
        public string CardCost { get; set; }
        public string CardAccMoney { get; set; }
        public string PaperTypeCode { get; set; }
        public string ACPTSIDE { get; set; }


    }

    public class MakeUpCardResponse : BaseResponse
    {
    }
}
