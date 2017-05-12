using System;
using System.Collections;
using System.IO;
using Wx.Utility.Data;
using Wx.Utility.Logging;
using Wx.WEB.Common;
using Wx.WEB.Core.Controllers;
using Wx.WEB.Model;

namespace Wx.WEB.Controllers
{
    public class WxController : BaseController
    {
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(WxController));

        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            WeChatRequest model = new WeChatRequest
            {
                nonce = filterContext.HttpContext.Request.QueryString["nonce"],
                signature = filterContext.HttpContext.Request.QueryString["signature"],
                timestamp = filterContext.HttpContext.Request.QueryString["timestamp"]
            };
            //验证
            if (WxHelper.CheckSignature(model))
            {
                base.OnActionExecuting(filterContext);
            }
        }

        public void Valid(WeChatRequest model)
        {
            Logger.Info(Json(model));
            string respMessage = "";
            //获取请求来的 echostr 参数
            string echoStr = model.echostr;
            //通过验证
            if (WxHelper.CheckSignature(model))
            {
                respMessage = echoStr;
            }
            if (HttpContext.Request.HttpMethod.ToUpper() == "POST")
            {
                //从请求的数据流中获取请求信息
                using (Stream stream = HttpContext.Request.InputStream)
                {
                    byte[] postBytes = new byte[stream.Length];
                    stream.Read(postBytes, 0, (int)stream.Length);
                    string postString = System.Text.Encoding.UTF8.GetString(postBytes);
                    Handle(postString, model);
                }
            }
            if (string.IsNullOrEmpty(respMessage)) return;
            //将随机生成的 echostr 参数 原样输出
            Response.Write(respMessage);
            //截止输出流
            Response.End();
        }


        private void Handle(string postData, WeChatRequest model)
        {
            Hashtable hh = XmlAndJsonToHash.XmlToHashTable(postData);
            Logger.Info(hh.ToString());
            // 消息MsgId
            String msgId = hh["MsgId"].ToString();
            // 发送方帐号（open_id）
            String fromUserName = hh["FromUserName"].ToString();
            // 公众帐号
            String toUserName = hh["ToUserName"].ToString();
            // 消息类型
            String msgType = hh["MsgType"].ToString(); 
            // 消息内容
            String content = hh["Content"].ToString(); 
            // 发送时间
            String createTime = hh["CreateTime"].ToString();
            String eventType;
            String eventKey;
            if (Constants.ReqMessageTypeEvent.Equals(msgType))
            {
                eventType = hh["EventKey"].ToString();
                if (Constants.EventTypeClick.Equals(eventType))
                {
                    // 事件KEY值，与创建自定义菜单时指定的KEY值对应
                    eventKey = hh["EventKey"].ToString();
                    content = "click_" + eventKey;
                }
                else if (Constants.EventTypeTemplatesendjobfinish.Equals(eventType))
                {
                    eventKey = hh["EventKey"].ToString();
                    content = "click_" + eventKey;
                }
            }
            
        }
    }
}
