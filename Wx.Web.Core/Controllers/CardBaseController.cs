using System.Collections.Generic;
using Wx.WEB.Core.ViewModels;
using Wx.WEB.Core.Common;

namespace Wx.WEB.Core.Controllers
{
    /// <summary>
    /// 读卡相关页面控制器
    /// dongx 20150815
    /// </summary>
    public class CardBaseController : BaseController
    {
        public CardBusinessRule CardBusinessRule { get; set; }

        //[AjaxOnly]
        //[HttpPost]
        ////读卡
        //public ActionResult ReadCard(GetCardInfo request)
        //{
        //    request.OperCardNo = Session["OperateCard"].CastTo<string>("");
        //    request.CurrOper = Session["StaffNo"].CastTo<string>("");
        //    request.CurrDept = Session["DepartNo"].CastTo<string>("");
        //    GetCardInfoResponse response = WeChatHelper.PostService<GetCardInfo, GetCardInfoResponse>("GetCardInfo",
        //       request);
        //    return Json(response, JsonRequestBehavior.DenyGet);
        //}


        /// <summary>
        /// 获取业务费用信息
        /// </summary>
        /// <param name="tradeTypeCode"></param>
        /// <returns></returns>
        protected static List<object> GetTradeFee(string tradeTypeCode)
        {
            List<object> tradeFees = (List<object>)CommonHelper.GetCommonApi("TradeFees", 2);
            var result = tradeFees.FindAll(m => (string) m == tradeTypeCode);
            return result;
        }
         
    }
}
