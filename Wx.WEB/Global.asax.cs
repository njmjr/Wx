using Wx.WEB.Core.Common;
using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

namespace Wx.WEB
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Application["WXURI"] = ConfigurationManager.AppSettings["WeChat_CommonURI"];
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            CommonHelper.InitializeCache();
        }
        protected void Application_Error(object sender, EventArgs e)
        {

        }
    }
}