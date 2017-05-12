using System;

namespace Wx.WEB.ServiceModel
{
    public class BaseMessage
    {
        private String ToUserName { get;set;}
        /// <summary>
        /// 开发者微信号
        /// </summary>
        private String FromUserName{ get;set;}

        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        private long CreateTime{ get;set;}

        /// <summary>
        /// 消息类型（text/music/news）
        /// </summary>
        private String MsgType{ get;set;}
        
        /// <summary>
        /// 位0x0001被标志时，星标刚收到的消息
        /// </summary>
        private int FuncFlag{ get;set;}
    }
}