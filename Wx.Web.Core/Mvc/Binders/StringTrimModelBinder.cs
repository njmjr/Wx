using System.Web.Mvc;

namespace Wx.Web.Core.Mvc.Binders
{
    /// <summary>
    /// 模型字符串处理类，处理传入字符串的前后空格
    /// </summary>
    public class StringTrimModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            object value = base.BindModel(controllerContext, bindingContext);
            if (value is string)
            {
                return (value as string).Trim();
            }
            return value;
        }
    }
}