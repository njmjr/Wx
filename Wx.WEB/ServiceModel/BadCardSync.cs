using WeChat.ServiceModel.Base;

namespace Wx.WEB.ServiceModel
{
    public class BadCardSync : BaseRequest
    {
        public string BIPCODE { get; set; }
        public string CardNo { get; set; }
        public string BankCardNo { get; set; }
        public string Remark { get; set; }

    }

    public class BadCardSyncResponse : BaseResponse
    {
    }
}
