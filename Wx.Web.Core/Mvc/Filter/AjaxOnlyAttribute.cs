﻿using System;
using System.Web.Mvc;

namespace Wx.Web.Core.Mvc.Filter
{
    /// <summary>
    /// 限制当前功能只允许以Ajax的方式来访问
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AjaxOnlyAttribute : ActionFilterAttribute
    {
        #region Implementation of IActionFilter

        /// <summary>
        /// Called before an action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new ContentResult
                {
                    Content = "指定功能只支持使用Ajax的方式来调用。"
                };
            }
        }

        #endregion
    }
}
