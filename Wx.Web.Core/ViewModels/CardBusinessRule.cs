namespace Wx.WEB.Core.ViewModels
{
    /// <summary>
    /// 读卡相关业务业务规则
    /// dongx
    /// 20150825
    /// </summary>
    public class CardBusinessRule : BusinessRule
    {
        public CardBusinessRule(string tradeName, string tradeTypeCode)
        {
            TradeName = tradeName;
            TradeTypeCode = tradeTypeCode;
            PageInit = string.Empty;
            IsShowCardInfoPanel = true;
            IsShowQueryDbButton = false;
            IsShowReadCardButton = true;
            IsShowOpenFunc = true;
            ReadCardRquest = "null"; 
            SubmitRquest = "null";
            BeginReadCardFunc = string.Empty;
            ReadCardFunc = string.Empty;
            EndReadCardFunc = string.Empty;
            IsShowAccountInfoPanel = true;
            IsEditAccountInfoPanel = false;
            ShowSaleCardDateTime = false; 
            PrintMode = "1";
            //CostList = GetCostListStr();
            //BusinessInfo = GetTradeParameters();
            IsCustomBusinessInfo = false;
            IsShowReasonType = false;
            IsShowReportlossDate = false;
            IsShowlossmessage = false;
            //ReasonTypeList = GetReasonTypes();
            IsPrint = true;

        }

        /// <summary>
        /// 业务名称
        /// </summary>
        public string TradeName { get; set; }

        /// <summary>
        /// 业务编码
        /// </summary>
        public string TradeTypeCode { get; set; }

        /// <summary>
        /// 页面初始化业务
        /// </summary>
        public string PageInit { get; set; }

        /// <summary>
        /// 是否显示卡信息区域
        /// </summary>
        public bool IsShowCardInfoPanel {get;set;}

        /// <summary>
        /// 是否显示读数据库按钮
        /// </summary>
        public bool IsShowQueryDbButton { get; set; }

        /// <summary>
        /// 是否显示开通功能
        /// </summary>
        public bool IsShowOpenFunc { get; set; }

        //显示售卡时间
        public bool ShowSaleCardDateTime { get; set; }

        /// <summary>
        /// 是否显示读卡按钮
        /// </summary>
        public bool IsShowReadCardButton { get; set; }

        /// <summary>
        /// 读卡请求JSON
        /// </summary>
        public string ReadCardRquest { get; set; }

        /// <summary>
        /// 读卡按钮点击JS事件
        /// </summary>
        public string BeginReadCardFunc { get; set; } 

        /// <summary>
        /// 读卡按钮业务(服务ID)
        /// </summary>
        public string ReadCardFunc { get; set; }

        /// <summary>
        /// 读卡按钮结束JS事件
        /// </summary>
        public string EndReadCardFunc { get; set; }

        /// <summary>
        /// 是否显示用户信息
        /// </summary>
        public bool IsShowAccountInfoPanel { get; set; }

        /// <summary>
        /// 用户信息是否可编辑
        /// </summary>
        public bool IsEditAccountInfoPanel { get; set; } 
        
        /// <summary>
        /// JSON格式费用列表
        /// </summary>
        public string CostList { get; set; }

        /// <summary>
        ///业务信息
        /// </summary>
        //public List<TradeParameter> BusinessInfo { get; set; }

        /// <summary>
        /// 自定义业务信息
        /// </summary>
        public bool IsCustomBusinessInfo { get; set; }

        /// <summary>
        /// 提交请求JSON
        /// </summary>
        public string SubmitRquest { get; set; }

        /// <summary>
        /// 提交按钮点击JS事件
        /// </summary>
        public string BeginSubmitFunc { get; set; }

        /// <summary>
        /// 提交按钮业务URL
        /// </summary> 
        public string SubmitFunc { get; set; } 

        /// <summary>
        /// 提交按钮结束JS事件
        /// </summary>
        public string EndSubmitFunc { get; set; }

        /// <summary>
        /// 打印方式  1：针式打印 2：热敏
        /// </summary>
        public string PrintMode { get; set; }
        /// <summary>
        /// 是否打印
        /// </summary>
        public bool IsPrint { get; set; }

        /// <summary>
        /// 是否显示退换卡原因
        /// </summary>
        public bool IsShowReasonType { get; set; }

        /// <summary>
        /// 退换卡原因列表
        /// </summary>
        //public List<ReasonType> ReasonTypeList { get; set; } 

        //获取费用列表
        //private string GetCostListStr()
        //{
        //    string result = string.Empty;
        //    List<TradeFee> costlist = Common.CommonHelper.GetTradeFee(TradeTypeCode);
        //    if (costlist.Count > 0)
        //    {
        //        if (costlist.Count > 1)
        //        {
        //        int total = costlist.Sum(t => t.BASEFEE);
        //        costlist.Add(new TradeFee() { TRADETYPECODE = TradeTypeCode, FEETYPENAME = "合计", FEETYPECODE = "TT", BASEFEE = total });
        //        }
                    
        //        result = JsonConvert.SerializeObject(costlist);
        //    }
        //    return result;
        //}

        ////获取业务参数列表
        //private List<TradeParameter> GetTradeParameters()
        //{
        //     List<TradeParameter> result =  new List<TradeParameter>() ;
        //    List<TradeParameter> tradeParameterlist = Common.CommonHelper.GetTradeParameters(TradeTypeCode);
        //    result = tradeParameterlist;
        //    return result;
        //}

        ////获取退换卡原因列表
        //private List<ReasonType> GetReasonTypes()
        //{
        //    List<ReasonType> result = new List<ReasonType>();
        //    List<ReasonType> reasonTypeList = Common.CommonHelper.GetReasonTypes();
        //    result = reasonTypeList;
        //    return result;
        //}

        /// <summary>
        /// 是否显示挂失时间
        /// </summary>
        public bool IsShowReportlossDate  { get; set; }
        /// <summary>
        /// 是否显示挂失详细消息
        /// </summary>
        public bool IsShowlossmessage { get; set; }
        
    }
}