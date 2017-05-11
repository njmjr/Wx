using WeChat.ServiceModel.Base;


namespace Wx.WEB.ServiceModel
{
    /// <summary>
    /// 挂失解挂接口
    /// </summary>
    public class ReportLoss : BaseRequest
    {
        public string BIPCODE { get; set; }
        public string RequestType { get; set; }
        public string BankCardNo { get; set; }
        public string CardNo { get; set; }
        public string BankCode { get; set; }
        public string CustName { get; set; }
        public string PaperTypeCode { get; set; }
        public string PaperNo { get; set; }
    }

    public class ReportLossResponse : BaseResponse
    {
    }
}
