using System.Web.Mvc;
using WeChat.ServiceModel.Crawler;
using Wx.Utility.Logging;
using Wx.WEB.Core.Common;
using Wx.WEB.Core.Controllers;
using Wx.Web.Core.Mvc.Filter;

namespace Wx.WEB.Controllers
{
    public class CrawlerController : BaseController
    {
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(CrawlerController));

        /// <summary>
        /// 消费信息查询初始化
        /// </summary>
        /// <returns></returns>
        [ForeVerufyActionFilter]
        public ActionResult CrawlerPan()
        {
            return View();
        }

        /// <summary>
        /// 百度网盘抓取
        /// </summary>
        /// <param name="searchData"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="resultNum"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult GridData(string searchData, int pageIndex, int pageSize, int resultNum)
        {
            CrawlerPan request = new CrawlerPan
            {
                SearchData = searchData,
                pageIndex = pageIndex,
                pageSize = 10,
                ResultNum = resultNum
                
            };
            string response = WeChatHelper.PostService("CrawlerPan", request);
            return JavaScript(response);
        }
        
    }
}
