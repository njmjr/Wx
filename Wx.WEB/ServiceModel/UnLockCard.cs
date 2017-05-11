using WeChat.ServiceModel.Base;

namespace Wx.WEB.ServiceModel
{
    public class UnLockCard : BaseRequest
    {
        public string BIPCODE { get; set; }
        public string CardNo { get; set; }

    }


    public class UnLockCardResponse : BaseResponse
    {
    }
}
