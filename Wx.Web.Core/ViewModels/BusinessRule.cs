namespace Wx.WEB.Core.ViewModels
{
    public abstract class BusinessRule
    {
        //操作员工号
        public string UserID { get; set; }

        //操作员卡号
        public string CardID { get; set; }

        //测试模式
        public bool Debugging { get; set; }

    }
}