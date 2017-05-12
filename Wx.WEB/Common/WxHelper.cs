using System;
using System.Configuration;
using System.Web.Security;
using Wx.WEB.Model;

namespace Wx.WEB.Common
{
    /// <summary>
    /// 微信
    /// </summary>
    public static class WxHelper
    {
        public static bool CheckSignature(WeChatRequest model)
        {
            //获取请求来的参数
            string signature = model.msg_signature;
            string timestamp = model.timestamp;
            string nonce = model.nonce;
            //创建数组，将 Token, timestamp, nonce 三个参数加入数组
            string token = ConfigurationManager.AppSettings["WeChatToken"];
            string[] array = { token, timestamp, nonce };
            //进行排序
            Array.Sort(array);
            //拼接为一个字符串
            string tempStr = String.Join("", array);
            //对字符串进行 SHA1加密
            var hashPasswordForStoringInConfigFile = FormsAuthentication.HashPasswordForStoringInConfigFile(tempStr, "SHA1");
            if (hashPasswordForStoringInConfigFile != null)
                tempStr = hashPasswordForStoringInConfigFile.ToLower();
            //判断signature 是否正确
            return tempStr.Equals(signature);
        }
    }
}