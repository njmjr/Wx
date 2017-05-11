using System;
using System.Web;
using System.Web.Caching;
using System.Collections.Generic;
using System.Configuration;
using WeChat.Models;
using WeChat.ServiceModel.Base;
using Wx.Utility.Extensions;

namespace Wx.WEB.Core.Common
{
    /// <summary>
    /// 通用帮助类
    /// </summary>
    public static class CommonHelper
    {
        public static string GetCity()
        {
            return ConfigurationManager.AppSettings["City"];
        }

        public static string GetLoginIp()
        {
            return ConfigurationManager.AppSettings["LoginIP"];
        }


        /// <summary>
        /// 获取通用接口 -- 返回单个Common集合
        /// </summary>
        /// <param name="key">接口KEY字符串</param>
        /// <param name="skey">接口KEY数字</param>
        /// <returns>结果对象</returns>
        public static object GetCommonApi(string key, short skey = 0)
        {
            string staffNo = "";
            if (HttpContext.Current.Session["StaffNo"] != null)
            {
                staffNo = HttpContext.Current.Session["StaffNo"].ToString();
            }
            string keyCacheCode = key;
            if (key == "Menus")
            {
                keyCacheCode = key + staffNo;
            }
            Cache cache = HttpRuntime.Cache;
            if (cache.Get(keyCacheCode) != null)
            {
                return cache.Get(keyCacheCode);
            }

            CommonResponse commonResponse = WeChatHelper.CallService<WeChat.ServiceModel.Base.Common, CommonResponse>("",
                new WeChat.ServiceModel.Base.Common { CurrOper = staffNo, RequestType = skey }, ConfigurationManager.AppSettings["WeChat_CommonURI"]);

            object returnValue = commonResponse.GetType().GetProperty(key).GetValue(commonResponse, null);
            if (returnValue != null)
                cache.Insert(keyCacheCode, returnValue, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 180, 0));
            return returnValue;
        }

        /// <summary>
        /// 初始化服务，缓存参数
        /// </summary>
        public static void InitializeCache()
        {
            Cache cache = HttpRuntime.Cache;
            CommonResponse commonResponse = WeChatHelper.CallService<WeChat.ServiceModel.Base.Common, CommonResponse>("",
             new WeChat.ServiceModel.Base.Common { RequestType = 0 }, ConfigurationManager.AppSettings["WeChat_CommonURI"]);
            if (commonResponse.Services.IsEmpty())
            {
                throw new Exception("获取WeChat服务列表失败");
            }
            if (commonResponse.Services != null)
                cache.Insert("Services", commonResponse.Services, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 180, 0));
            //if (commonResponse.PaperTypes != null)
            //    cache.Insert("PaperTypes", commonResponse.PaperTypes, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 180, 0));
            //if (commonResponse.TradeFees != null)
            //    cache.Insert("TradeFees", commonResponse.TradeFees, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 180, 0));
            //if (commonResponse.TradeParameters != null)
            //    cache.Insert("TradeParameters", commonResponse.TradeParameters, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 180, 0));
            //if (commonResponse.CardTypes != null)
            //    cache.Insert("CardTypes", commonResponse.CardTypes, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 180, 0));
            //if (commonResponse.CardSurfaces != null)
            //    cache.Insert("CardSurfaces", commonResponse.CardSurfaces, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 180, 0));
            //if (commonResponse.CardCosTypes != null)
            //    cache.Insert("CardCosTypes", commonResponse.CardCosTypes, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 180, 0));
            //if (commonResponse.CardChipTypes != null)
            //    cache.Insert("CardChipTypes", commonResponse.CardChipTypes, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 180, 0));
            //if (commonResponse.Manus != null)
            //    cache.Insert("Manus", commonResponse.Manus, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 180, 0));
            //if (commonResponse.ReasonTypes != null)
            //    cache.Insert("ReasonTypes", commonResponse.ReasonTypes, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 180, 0));
            //if (commonResponse.TradeTypeShows != null)
            //    cache.Insert("TradeTypeShows", commonResponse.TradeTypeShows, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 180, 0));
        }



        //public static List<TradeFee> GetTradeFee(string tradeTypeCode)
        //{
        //    List<TradeFee> tradeFees = (List<TradeFee>)GetCommonApi("TradeFees", (short)CommonRequestType.TradeFee);
        //    return tradeFees.FindAll(t => t.TRADETYPECODE == tradeTypeCode);
        //}

        ///// <summary>
        ///// 获取业务参数信息
        ///// </summary>
        ///// <param name="tradeTypeCode">业务编码</param>
        ///// <returns></returns>
        //public static List<TradeParameter> GetTradeParameters(string tradeTypeCode)
        //{
        //    List<TradeParameter> tradeParameters = (List<TradeParameter>)GetCommonApi("TradeParameters", (short)CommonRequestType.TradeParameter);
        //    return tradeParameters.FindAll(t => t.TRADETYPECODE == tradeTypeCode);
        //}
        ///// <summary>
        ///// 获取退换卡原因信息
        ///// </summary>
        ///// <param name="tradeTypeCode">业务编码</param>
        //public static List<ReasonType> GetReasonTypes()
        //{
        //    List<ReasonType> reasonTypes = (List<ReasonType>)GetCommonApi("ReasonTypes", (short)CommonRequestType.ReasonType);
        //    return reasonTypes;
        //}
        /// <summary>
        /// 获取业务费用信息
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// 获取服务URI
        /// </summary>
        /// <param name="serviceId">服务ID</param>
        /// <returns>URI</returns>
        public static string GetWxUri(string serviceId)
        {
            List<WxService> services = (List<WxService>)GetCommonApi("Services", (short)CommonRequestType.WeChatService);
            string result = services.Find(s => s.SERVICEID == serviceId).URI;
            if (result.IsNullOrEmpty())
            {
                throw new Exception("未找到WeChat服务地址，请检查是否配置");
            }
            return result;
        }

        /// <summary>
        /// 调用接口（缓存180分钟）
        /// </summary>
        /// <typeparam name="TRequestDto">请求DTO</typeparam>
        /// <typeparam name="TResponseDto">响应DTO</typeparam>
        /// <param name="key">缓存KEY</param>
        /// <param name="serviceId">接口服务ID</param>
        /// <param name="request">请求DTO实例</param>
        /// <param name="action"></param>
        /// <returns>响应DTO实例</returns>
        public static TResponseDto GetCache<TRequestDto, TResponseDto>(string key, string serviceId,
            TRequestDto request, Action<TResponseDto> action = null)
            where TRequestDto : BaseRequest
        {
            Cache cache = HttpRuntime.Cache;
            if (cache.Get(key) != null)
            {
                return (TResponseDto)cache.Get(key);
            }
            var returnValue = WeChatHelper.PostService<TRequestDto, TResponseDto>(serviceId, request);
            if (action != null)
            {
                action(returnValue);
            }
            if (returnValue != null)
                cache.Insert(key, returnValue, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 180, 0));
            return returnValue;
        }
    }

    public enum CommonRequestType : short
    {
        All,
        PaperType,
        TradeFee,
        WeChatService,
        MenuView,
        TradeParameter,
        ReasonType,
        CardTypes,
        CardSurfaces,
        CardCosTypes,
        CardChipTypes,
        Manus,
        TradeTypeShow
    }

}