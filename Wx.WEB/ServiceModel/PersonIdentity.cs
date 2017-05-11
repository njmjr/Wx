using WeChat.ServiceModel.Base;

namespace Wx.WEB.ServiceModel
{
    public class PersonIdentity : BaseRequest
    {
        public string BIPCODE { get; set; }
        public string CUSTNAME { get; set; }
        public string PaperNo { get; set; }

        public string PaperTypeCode { get; set; }

        public string OldBankCardNo { get; set; }

        public string ApplyType { get; set; }

    }
    public class PersonIdentityResponse : BaseResponse
    {
    }
}