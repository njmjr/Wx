using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Reflection;
using System.Collections;
using System.Configuration;

namespace Wx.Utility.Data
{
    /// <summary>
    /// 签名相关帮助类
    /// dongx
    /// 20150723
    /// </summary>
    public class TokenHelper
    {
        /// <summary>
        /// 生成签名,无私钥
        /// </summary>
        /// <param name="requetbody">报文体</param> 
        /// <returns>签名</returns>
        public static string GetSignStr(object requetbody)
        {
            string tokenKey = ConfigurationManager.AppSettings["TokenKey"];
            return GetSignStr(requetbody, tokenKey);
        }


        /// <summary>
        /// 生成签名，有私钥
        /// </summary>
        /// <param name="requetbody">报文体</param>
        /// <param name="key">私钥</param>
        /// <returns>签名</returns>
        public static string GetSignStr(object requetbody, string key)
        {
            if (requetbody == null)
                return string.Empty;

            List<MySort> list = new List<MySort>();
            ObjToKeyValue(requetbody, ref list);
            //先根据key,再根据value排序
            list.Sort();

            if (!string.IsNullOrEmpty(key))
                list.Add(new MySort { Key = "CHANNELKEY", Value = key });

            string sign = String.Join("&", list.Select(p => p.Key + "=" + p.Value)).ToUpper();
            return Md5Encrypt(sign, Encoding.UTF8);
        }

        //遍历属性,生成字典
        public static void ObjToKeyValue(object obj, ref List<MySort> list)
        {
            PropertyInfo[] props = obj.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                //如果是值类型或者string
                if (prop.PropertyType.IsValueType || (prop.PropertyType == typeof(string)))
                {
                    //去除空值和请求报文中的TOKEN
                    if (prop.GetValue(obj, null) != null && prop.Name.ToUpper() != "TOKEN")
                    {
                        MySort sort = new MySort();
                        sort.Key = prop.Name;
                        sort.Value = prop.GetValue(obj, null);
                        list.Add(sort);
                    }
                }
                else if (prop.GetValue(obj, null) is IEnumerable)//迭代
                {
                    foreach (var item in (IEnumerable)prop.GetValue(obj, null))
                    {
                        if (item != null)
                        {
                            if (item.GetType().IsValueType || item is string)
                            {
                                MySort sort = new MySort();
                                sort.Key = prop.Name;
                                sort.Value = item;
                                list.Add(sort);
                            }
                            else
                            {
                                ObjToKeyValue(item, ref list);
                            }
                        }
                    }
                }
                else //类对象
                {
                    if (prop.GetValue(obj, null) != null)
                    {
                        ObjToKeyValue(prop.GetValue(obj, null), ref list);
                    }
                }
            }
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input">需要加密的字符串</param>
        /// <param name="encode">字符的编码</param>
        /// <returns></returns>
        public static string Md5Encrypt(string input, Encoding encode)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(encode.GetBytes(input));
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            return sb.ToString();
        }
    }
    public class MySort : IComparable<MySort>
    {
        public string Key { get; set; }

        public object Value { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}",
                  Key, Value);
        }

        public int CompareTo(MySort other)
        {
            if (other == null) throw new ArgumentNullException("other");

            int result = String.Compare(Key, other.Key, StringComparison.Ordinal);
            if (result == 0)
            {
                result = String.Compare(Value.ToString(), other.Value.ToString(), StringComparison.Ordinal);
            }

            return result;
        }
    }
}
