using WeChat.ServiceModel.Base;

namespace Wx.WEB.ServiceModel
{
    public class GetBankPic : BaseRequest
    {
        public string BIPCODE { get; set; }
        public string CardNo { get; set; }
        public string PAPERNO { get; set; }
        public string CUSTNAME { get; set; }
    }

    public class GetBankPicResponse : BaseResponse
    {
    }
}
