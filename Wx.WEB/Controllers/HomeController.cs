using System.Net;
using WeChat.Models;
using WeChat.ServiceModel.Login;
using Wx.Utility.Extensions;
using Wx.Utility.Logging;
using Wx.Utility.Secutiry;
using Wx.WEB.Core.Common;
using Wx.WEB.Core.Controllers;
using Wx.Web.Core.Mvc.Filter;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web;
using System;
using System.Collections;
using Wx.WEB.Core.ViewModels;

namespace Wx.WEB.Controllers
{
    public class HomeController : BaseController
    {
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(HomeController));

        [AjaxOnly]
        public ActionResult GetMenuData()
        {
            List<MenuView> menus = (List<MenuView>)CommonHelper.GetCommonApi("Menus", 1);
            return Json(menus, JsonRequestBehavior.AllowGet);
        }



        [AjaxOnly]
        [HttpPost]
        public ActionResult LoginCheck(string id, string pwd)
        {
            Login request = new Login
            {
                RequestType = 0,
                LoginStaffNo = id,
                Pwd = DecryptPwdHelper.EncodeString(pwd)
            };
            LoginResponse response = WeChatHelper.PostService<Login, LoginResponse>("Login", request);
            if (response.ResponseStatus.ErrorCode=="OK")
            {
                Session["StaffNo"] = id;
                Session["DepartNo"] = response.DepartNo;
                Session["token"] = "0001";
                Session["OperateCard"] = "2150090110009004";
                Session["StaffName"] = response.StaffName;
                Session["deptname"] = response.DepartName;
                Session["type"] = "test";
            }
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        [ForeVerufyActionFilter]
        public ActionResult Index()
        {
            if (Session["StaffNo"] == null)
            {
                return RedirectToAction("Login", "Home");
                //return View("Login");
            }
            ViewBag.City = CommonHelper.GetCity();
            WriteCookie(CommonHelper.GetLoginIp());
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        public ActionResult LogOut()
        {
            Session.RemoveAll();
            Session.Clear();
            return View("Login");
        }


#if DEBUG
        public ActionResult LoginTestCard(string operateCard)
        {
            if (string.IsNullOrEmpty(operateCard))
            {
                operateCard = "2150999999999901";
            }
            Session["StaffNo"] = "999999";
            Session["DepartNo"] = "9001";
            Session["token"] = "9001";
            Session["OperateCard"] = operateCard;
            Session["StaffName"] = "测试用户";
            Session["type"] = "";
            WriteCookie(CommonHelper.GetLoginIp());
            return RedirectToAction("Index");
        }

        public ActionResult LoginTest()
        {
            Session["StaffNo"] = "010001";
            Session["DepartNo"] = "0001";
            Session["token"] = "0001";
            Session["OperateCard"] = "2150090110009004";
            Session["StaffName"] = "测试用户";
            Session["type"] = "test";
            WriteCookie(CommonHelper.GetLoginIp());
            return RedirectToAction("Index");
        }

        public ActionResult CardTest()
        {
            return View();
        }

#endif

        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult LoginSSo()
        {

            string type = Request.QueryString["type"];
            string staffno = Request.QueryString["staffno"];
            string staffname = Request.QueryString["staffname"];
            string token = Request.QueryString["token"];
            string deptno = Request.QueryString["deptno"];
            string deptname = Request.QueryString["deptname"];
            string operateCard = Request.QueryString["operateCard"];
            if (Request.Url != null)
            {
                string strIp = Request.Url.Host;
                //验证Token
                //DeptStaffResponse re = WeChatHelper.PostService<DeptStaff, DeptStaffResponse>("DeptStaff", new DeptStaff() { RequestType = 2, StaffNo = staffno, LinkToken = token });
                //if (re.LinkToken == null)
                //{
                //    return Redirect("/HtmlError.html");
                //}

                Session["StaffNo"] = staffno;
                //Session["token"] = re.LinkToken;
                Session["DepartNo"] = deptno;
                Session["OperateCard"] = operateCard;
                Session["type"] = type;
                Session["DeptName"] = deptname;
                Session["StaffName"] = staffname;
                WriteCookie(strIp);
            }
            return RedirectToAction("Index", "Home");
        }

        private void WriteCookie(string strIp)
        {
            HttpCookie cookie = new HttpCookie("strIp") { Value = strIp, Expires = DateTime.Now.AddDays(1) };
            Response.AppendCookie(cookie);
        }

        //public ActionResult GetToken(string cardno)
        //{
        //    GetTokenResponse rsp = OSCHelper.PostService<GetToken, GetTokenResponse>("GetToken", new GetToken() { CardNo = cardno });
        //    return Json(rsp.Token, JsonRequestBehavior.DenyGet);
        //}

        //public ActionResult WriteCard(WriteCard request)
        //{
        //    WriteCardResponse res = OSCHelper.PostService<WriteCard, WriteCardResponse>("WriteCard", request);
        //    return Json(res, JsonRequestBehavior.DenyGet);
        //}

        //public ActionResult PrintArea()
        //{
        //    return View();
        //}

        //清空缓存
        public ActionResult ClearCache()
        {
            IDictionaryEnumerator enumerator = HttpRuntime.Cache.GetEnumerator();

            while (enumerator.MoveNext())
            {

                HttpRuntime.Cache.Remove((string)enumerator.Key);
            }
            return Content("缓存已清空");
        }

    }
}
