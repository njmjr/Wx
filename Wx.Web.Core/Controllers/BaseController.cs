using System.Web.Mvc;
using System;
using ServiceStack;
using NLog;
namespace Wx.WEB.Core.Controllers
{
    public class BaseController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger(); 
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception exception = filterContext.Exception;
            string message;
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                message = "Ajax访问时引发异常：";
                if (exception is HttpAntiForgeryException)
                {
                    message += "安全性验证失败。<br>请刷新页面重试，详情请查看系统日志。";
                }
                else
                {
                    message += exception.Message;
                }
                logger.Error(message, exception);
                filterContext.Result = Json(new ResponseStatus() { ErrorCode = "ERROR", Message = message }, JsonRequestBehavior.AllowGet);
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                filterContext.ExceptionHandled = true;
            }
        }
    }
}
