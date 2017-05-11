using WeChat.ServiceModel.Base;

namespace Wx.WEB.ServiceModel
{
    public class TransitBalance : BaseRequest
    {
        public string BIPCODE { get; set; }
        public string NewCardNo { get; set; }
        public string OldCardNo { get; set; }
        public int CardMoney { get; set; }
        public int CurrentMoney { get; set; }
        public string CardTradeNo { get; set; }
        public string Termno { get; set; }

    }

    public class TransitBalanceResponse : BaseResponse
    {
        public string CardNo { get; set; }

    }
}
