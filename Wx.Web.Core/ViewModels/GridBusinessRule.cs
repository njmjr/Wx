namespace Wx.WEB.Core.ViewModels
{
    /// <summary>
    /// 增删改查业务规则
    /// dongx
    /// 20151203
    /// </summary>
    public class GridBusinessRule : BusinessRule
    {
        public GridBusinessRule(string title)
        {
            Title = title;
            AutoSearch = true;
            ToolbarItem = "search,add,edit,delete";
            IsPaging = "true";
            FitGrid = "true";
            GridHeight = "400";
            IsClosedQueryModal = "true";
            IsPrint = false;
            PrintName = "凭证";
        }

        /// <summary>
        /// 业务名称
        /// </summary>
        public string Title { get; set; } 
        /// <summary>
        /// datagird ID
        /// </summary>
        public string GridId { get; set; } 
        /// <summary>
        /// 查询数据URL
        /// </summary>
        public string GridDataUrl { get; set; } 
        /// <summary>
        /// 是否自动查询数据
        /// </summary>
        public bool AutoSearch { get; set; } 
        /// <summary>
        /// 功能：search,add,delete,edit
        /// </summary>
        public string ToolbarItem { get; set; } 
        /// <summary>
        /// 是否分页
        /// </summary>
        public string IsPaging { get; set; }
        /// <summary>
        /// 是否全页面表格
        /// </summary>
        public string FitGrid { get; set; }
        /// <summary>
        /// 表格高度
        /// </summary>
        public string GridHeight { get; set; }
        /// <summary>
        /// 表格主键
        /// </summary>
        public string PrimaryKey { get; set; }
        /// <summary>
        /// 新增URL
        /// </summary>
        public string AddUrl { get; set; }
        /// <summary>
        /// 新增业务说明
        /// </summary>
        public string AddText { get; set; }
        /// <summary>
        /// 删除URL
        /// </summary>
        public string DeleteUrl { get; set; }
        /// <summary>
        /// 修改Url
        /// </summary>
        public string EditUrl { get; set; }
        /// <summary>
        /// 修改业务说明
        /// </summary>
        public string EditText { get; set; }
        /// <summary>
        /// 删除业务说明
        /// </summary>
        public string DeleteText { get; set; }
        /// <summary>
        /// 提交Model json字符串
        /// </summary>
        public string SubmitModel { get; set; }
        /// <summary>
        ///审核URL
        /// </summary>
        public string PermmitUrl { get; set; }
        /// <summary>
        ///审核业务说明
        /// </summary>
        public string PermmitText { get; set; }
        /// <summary>
        /// 是否显示查询框
        /// </summary>
        public string IsClosedQueryModal { get; set; }
        /// <summary>
        /// 是否显示打印按钮
        /// </summary>
        public bool IsPrint { get; set; }
        /// <summary>
        /// 凭证名称
        /// </summary>
        public string PrintName { get; set; }

        /// <summary>
        /// 菜单URL
        /// </summary>
        public string TreeUrl { get; set; }

        /// <summary>
        /// 回复URL
        /// </summary>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// 转发URL
        /// </summary>
        public string TransferUrl { get; set; }

        public string DownUrl { get; set; }
    }
}