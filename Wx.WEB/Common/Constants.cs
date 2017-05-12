using System;

namespace Wx.WEB.Common
{
    public static class Constants
    {
        /// <summary>
        /// 返回消息类型：文本
        /// </summary>
        public static String RespMessageTypeText = "text";

        /// <summary>
        /// 返回消息类型：音乐
        /// </summary>
        public static String RespMessageTypeMusic = "music";

        /// <summary>
        /// 返回消息类型：图文
        /// </summary>
        public static String RespMessageTypeNews = "news";

        /// <summary>
        /// 返回消息类型：单图文
        /// </summary>
        public static String RespMessageTypeNewsSingle = "singlePhoto";

        /// <summary>
        /// 返回消息类型：多图文
        /// </summary>
        public static String RespMessageTypeNewsMultiple = "multiplePhoto";

        /// <summary>
        /// 请求消息类型：文本
        /// </summary>
        public static String ReqMessageTypeText = "text";

        /// <summary>
        /// 请求消息类型：图片
        /// </summary>
        public static String ReqMessageTypeImage = "image";

        /// <summary>
        /// 请求消息类型：链接
        /// </summary>
        public static String ReqMessageTypeLink = "link";

        /// <summary>
        /// 请求消息类型：地理位置
        /// </summary>
        public static String ReqMessageTypeLocation = "location";

        /// <summary>
        /// 请求消息类型：音频
        /// </summary>
        public static String ReqMessageTypeVoice = "voice";

        /// <summary>
        /// 请求消息类型：推送
        /// </summary>
        public static String ReqMessageTypeEvent = "event";

        /// <summary>
        /// 事件类型：subscribe(订阅)
        /// </summary>
        public static String EventTypeSubscribe = "subscribe";

        /// <summary>
        /// 事件类型：unsubscribe(取消订阅)
        /// </summary>
        public static String EventTypeUnsubscribe = "unsubscribe";

        /// <summary>
        /// 事件类型：CLICK(自定义菜单点击事件)
        /// </summary>
        public static String EventTypeClick = "CLICK";

        public static  String EventTypeTemplatesendjobfinish ="TEMPLATESENDJOBFINISH";

    }
}