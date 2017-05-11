using WeChat.ServiceModel.Base;

namespace Wx.WEB.ServiceModel
{
    public class DestroyCard : BaseRequest
    {
        public string CardNo { get; set; }
        public int CardMoney { get; set; }
        public int RefundMoney { get; set; }
        public int RefundDepost { get; set; }
        public string CardTradeno { get; set; }

        public string BIPCODE { get; set; }
        public string Termno { get; set; }

    }

    public class DestroyCardResponse : BaseResponse
    {
    }
}
