namespace Wx.WEB.Core.ViewModels
{
    public class CommonBusinessRule :BusinessRule
    { 

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
    }
}