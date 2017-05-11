using System;
using System.Configuration;
using System.Web.Mvc;

namespace Wx.Web.Core.Mvc.Filter
{
    /// <summary>
    /// 权限认证
    /// dongx
    /// 20151009
    /// </summary>

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ForeVerufyActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session != null && filterContext.HttpContext.Session["StaffNo"] == null)
            {
                string strIp = ConfigurationManager.AppSettings["LoginIP"];
                if (filterContext.HttpContext.Request.Cookies["strIp"] != null)
                {
                    strIp = filterContext.HttpContext.Request.Cookies["strIp"].Value;
                }
                //string script = "window.top.location.href=http://'" + filterContext.HttpContext.Session["strIp"] + ConfigurationManager.AppSettings["LoginURI"].ToString() + "';";
                string script = "window.top.location.href= 'http://" + strIp + ConfigurationManager.AppSettings["LoginURI"] + "';";
                filterContext.HttpContext.Response.Write("<script language=\"javascript\">" + script + "</script>");
                return;
            }
            if (filterContext.HttpContext.Request.Url != null)
            {
                string url = filterContext.HttpContext.Request.Url.AbsolutePath.Substring(1).ToLower();
                if (url != "")
                {
                    //ForeVerify request = new ForeVerify()
                    //{
                    //    StaffNo = filterContext.HttpContext.Session["StaffNo"].ToString(),
                    //    DepartNo = filterContext.HttpContext.Session["DepartNo"].ToString(),
                    //    Url = url
                    //};
                    //ForeVerifyResponse response = WeChatHelper.PostService<ForeVerify, ForeVerifyResponse>("ForeVerify", request);
                    //if (response.ResponseStatus.ErrorCode != "OK")
                    //{
                    //    filterContext.Result = new ContentResult
                    //    {
                    //        Content = "权限错误"
                    //    };
                    //}
                }
            }
        }

    }
}