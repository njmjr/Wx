using System;
using ServiceStack;
using WeChat.ServiceModel.Base;
using Wx.Utility.Data;

namespace Wx.WEB.Core.Common
{
    /// <summary>
    /// 调用接口类
    /// </summary>
    public static class WeChatHelper
    {
        /// <summary>
        /// GET方式调用服务
        /// </summary>
        /// <typeparam name="TRequestDto">请求类</typeparam>
        /// <typeparam name="TResponseDto">响应类</typeparam>
        /// <param name="serviceId">服务ID</param>
        /// <param name="request">请求实例</param>
        /// <param name="url"></param>
        /// <returns>响应实例</returns>
        public static TResponseDto CallService<TRequestDto, TResponseDto>(string serviceId, TRequestDto request, string url = null) where TRequestDto : BaseRequest
        {
            if(url == null)
                url = CommonHelper.GetWxUri(serviceId);
            var client = new JsonServiceClient(url) {Timeout = new TimeSpan(0, 0, 90)};
            request.Token = TokenHelper.GetSignStr(request);
            TResponseDto responseDto = client.Get<TResponseDto>(request); 
            return responseDto;
        }

        /// <summary>
        /// POST方式调用服务
        /// </summary>
        /// <typeparam name="TRequestDto">请求类</typeparam>
        /// <typeparam name="TResponseDto">响应类</typeparam>
        /// <param name="serviceId">服务ID</param>
        /// <param name="request">请求实例</param>
        /// <returns>响应实例</returns>
        public static TResponseDto PostService<TRequestDto, TResponseDto>(string serviceId, TRequestDto request) where TRequestDto : BaseRequest
        {
            string url = CommonHelper.GetWxUri(serviceId);
            var client = new JsonServiceClient(url) {Timeout = new TimeSpan(0, 0, 90)};
            request.Token = TokenHelper.GetSignStr(request);
            TResponseDto responseDto = client.Post<TResponseDto>(request);
            return responseDto;
        }
          
        /// <summary>
        /// POST方式调用服务 直接返回JSON
        /// </summary>
        /// <typeparam name="TRequestDto">请求类</typeparam>
        /// <param name="serviceId">服务ID</param>
        /// <param name="request">请求实例</param>
        /// <returns>响应实例</returns>
        public static string PostService<TRequestDto>(string serviceId, TRequestDto request) where TRequestDto : BaseRequest
        {
            string url = CommonHelper.GetWxUri(serviceId);
            var client = new JsonServiceClient(url) {Timeout = new TimeSpan(0, 0, 90)};
            request.Token = TokenHelper.GetSignStr(request);
            string responseJson = client.Post<string>(request);
            return responseJson;
        }
          
    }
}