using WeChat.ServiceModel.Base;

namespace Wx.WEB.ServiceModel
{
    public class PrintPicture : BaseRequest
    {
        public string BIPCODE { get; set; }
        public string CardNo { get; set; }
        public string TradeId { get; set; }
        public string ISSocial { get; set; }

    }

    public class PrintPictureResponse : BaseResponse
    {
    }
}
