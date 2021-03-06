﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Wx.Web.Core.Mvc.Binders
{
    /// <summary>
    /// JSON数据绑定类
    /// </summary>
    public class JsonBinder<T> : IModelBinder
    {
        /// <summary>
        /// 使用指定的控制器上下文和绑定上下文将模型绑定到一个值。
        /// </summary>
        /// <returns>
        /// 绑定值。
        /// </returns>
        /// <param name="controllerContext">控制器上下文。</param><param name="bindingContext">绑定上下文。</param>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string json = controllerContext.HttpContext.Request.Form[bindingContext.ModelName];
            if (string.IsNullOrEmpty(json))
            {
                json = controllerContext.HttpContext.Request[bindingContext.ModelName];
            } 
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }
            JsonSerializer serializer = new JsonSerializer();
            if (json.StartsWith("{") && json.EndsWith("}"))
            {
                JObject jsonBody = JObject.Parse(json);
                object result = serializer.Deserialize(jsonBody.CreateReader(), typeof(T));
                return result;
            }
            if (json.StartsWith("[") && json.EndsWith("]"))
            {
                List<T> list = new List<T>();
                JArray jsonArray = JArray.Parse(json);
                if (jsonArray != null)
                {
                    list.AddRange(jsonArray.Select(jobj => serializer.Deserialize(jobj.CreateReader(), typeof(T))).Select(obj => (T)obj));
                }
                return list;
            }
            return null;
        }
    }
}