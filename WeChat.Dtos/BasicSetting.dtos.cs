/* Options:
Date: 2017-05-11 15:50:29
Version: 1
BaseUrl: http://osc.com:8889

//GlobalNamespace: 
//MakePartial: True
//MakeVirtual: True
//MakeDataContractsExtensible: False
//AddReturnMarker: True
//AddDescriptionAsComments: True
//AddDataContractAttributes: False
//AddIndexesToDataMembers: False
//AddResponseStatus: False
//AddImplicitVersion: 
//InitializeCollections: True
//IncludeTypes: 
//ExcludeTypes: 
//AddDefaultXmlNamespace: http://schemas.servicestack.net/types
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using ServiceStack.DataAnnotations;
using WeChat.ServiceModel.Base;
using WeChat.Models;
using WeChat.ServiceModel.PrivilegePR;
using WeChat.ServiceModel.Wx;


namespace WeChat.Models
{

    public partial class Attributes
    {
        public virtual string Pid { get; set; }
    }

    public partial class InsideDepart
    {
        public virtual string DEPARTNO { get; set; }
        public virtual string DEPARTNAME { get; set; }
        public virtual string UPDATESTAFFNO { get; set; }
        public virtual DateTime UPDATETIME { get; set; }
        public virtual string REMARK { get; set; }
        public virtual string USETAG { get; set; }
    }

    public partial class InsideStaff
    {
        public virtual string STAFFNO { get; set; }
        public virtual string STAFFNAME { get; set; }
        public virtual string OPERCARDPWD { get; set; }
        public virtual string DEPARTNO { get; set; }
        public virtual string DIMISSIONTAG { get; set; }
        public virtual string UPDATESTAFFNO { get; set; }
        public virtual DateTime UPDATETIME { get; set; }
        public virtual string REMARK { get; set; }
        public virtual DateTime LAST_ACTIVE_TIME { get; set; }
        public virtual string TOKEN { get; set; }
    }

    public partial class MenuPriView
    {
        public MenuPriView()
        {
            children = new List<MenuPriView>{};
        }

        public virtual string id { get; set; }
        public virtual string text { get; set; }
        public virtual string state { get; set; }
//    public virtual bool checked { get; set; }
        public virtual List<MenuPriView> children { get; set; }
        public virtual Attributes attributes { get; set; }
        public virtual string Pid { get; set; }
    }

    public partial class MenuView
    {
        public virtual string MenuNo { get; set; }
        public virtual string MenuName { get; set; }
        public virtual string PMenuNo { get; set; }
        public virtual string Url { get; set; }
        public virtual ICollection<MenuView> Children { get; set; }
    }

    public partial class Report
    {
        public virtual int total { get; set; }
        public virtual IEnumerable<Object> rows { get; set; }
        public virtual IEnumerable<Object> footer { get; set; }
    }

    public partial class Role
    {
        public virtual string ROLENO { get; set; }
        public virtual string ROLENAME { get; set; }
        public virtual string UPDATESTAFFNO { get; set; }
        public virtual DateTime UPDATETIME { get; set; }
        public virtual string REMARK { get; set; }
        public virtual string USETAG { get; set; }
    }

    public partial class WxService
    {
        public virtual string SERVICEID { get; set; }
        public virtual string URI { get; set; }
        public virtual string VERBS { get; set; }
        public virtual string DESCRIPTION { get; set; }
        public virtual string IP { get; set; }
        public virtual string PORT { get; set; }
        public virtual string VHOST { get; set; }
        public virtual string CALLCOUNT { get; set; }
        public virtual string RUNNINGSTATES { get; set; }
    }
}

namespace WeChat.ServiceModel.Base
{

    public partial class BaseRequest
    {
        public virtual string Token { get; set; }
        public virtual string CurrOper { get; set; }
        public virtual string CurrDept { get; set; }
    }

    public partial class BaseResponse
    {
        public virtual ResponseStatus ResponseStatus { get; set; }
        public virtual string TradeId { get; set; }
    }

    [Route("/common")]
    public partial class Common
        : BaseRequest, IReturn<CommonResponse>
    {
        public virtual short RequestType { get; set; }
    }

    public partial class CommonResponse
        : BaseResponse
    {
        public CommonResponse()
        {
            Menus = new List<MenuView>{};
        }

        public virtual List<MenuView> Menus { get; set; }
        public virtual IEnumerable<WxService> Services { get; set; }
        public virtual IEnumerable<Role> Roles { get; set; }
    }
}

namespace WeChat.ServiceModel.PrivilegePR
{

    [Route("/DepartConfig")]
    public partial class DepartConfig
        : BaseRequest, IReturn<DepartConfigResponse>
    {
        [ApiMember(Name="RequestType", Description="请求方法", DataType="string", IsRequired=true)]
        public virtual short RequestType { get; set; }

        [ApiMember(Name="DepartNo", Description="部门编号", DataType="string", IsRequired=true)]
        public virtual string DepartNo { get; set; }

        [ApiMember(Name="DepartName", Description="部门名称", DataType="string", IsRequired=true)]
        public virtual string DepartName { get; set; }

        [ApiMember(Name="Updatestaffno", Description="更新员工", DataType="string", IsRequired=true)]
        public virtual string Updatestaffno { get; set; }

        [ApiMember(Name="Updatetime", Description="更新时间", DataType="string", IsRequired=true)]
        public virtual DateTime Updatetime { get; set; }

        [ApiMember(Name="Remark", Description="备注", DataType="string", IsRequired=true)]
        public virtual string Remark { get; set; }

        [ApiMember(Name="Usetag", Description="有效标识", DataType="string", IsRequired=true)]
        public virtual string Usetag { get; set; }
    }

    public partial class DepartConfigResponse
        : BaseResponse
    {
        [ApiMember(Name="QueryData", Description="返回部门信息", DataType="List", IsRequired=true)]
        public virtual Report QueryData { get; set; }
    }

    [Route("/DeptStaff")]
    public partial class DeptStaff
        : BaseRequest, IReturn<DeptStaffResponse>
    {
        public virtual short RequestType { get; set; }
        public virtual string StaffNo { get; set; }
        public virtual string LinkToken { get; set; }
    }

    public partial class DeptStaffResponse
        : BaseResponse
    {
        public virtual IEnumerable<InsideStaff> Staffs { get; set; }
        public virtual IEnumerable<InsideDepart> Departs { get; set; }
        public virtual string LinkToken { get; set; }
        public virtual string Result { get; set; }
    }

    [Route("/ForeVerify")]
    public partial class ForeVerify
        : BaseRequest, IReturn<ForeVerifyResponse>
    {
        public virtual string StaffNo { get; set; }
        public virtual string DepartNo { get; set; }
        public virtual string Url { get; set; }
    }

    public partial class ForeVerifyResponse
        : BaseResponse
    {
    }

    [Route("/RoleConfig")]
    public partial class RoleConfig
        : BaseRequest, IReturn<RoleConfigResponse>
    {
        [ApiMember(Name="RequestType", Description="请求方法", DataType="string", IsRequired=true)]
        public virtual short RequestType { get; set; }

        [ApiMember(Name="RoleNo", Description="角色编号", DataType="string", IsRequired=true)]
        public virtual string RoleNo { get; set; }

        [ApiMember(Name="RoleName", Description="部门名称", DataType="string", IsRequired=true)]
        public virtual string RoleName { get; set; }

        [ApiMember(Name="Updatestaffno", Description="更新员工", DataType="string", IsRequired=true)]
        public virtual string Updatestaffno { get; set; }

        [ApiMember(Name="Updatetime", Description="更新时间", DataType="string", IsRequired=true)]
        public virtual DateTime Updatetime { get; set; }

        [ApiMember(Name="Remark", Description="备注", DataType="string", IsRequired=true)]
        public virtual string Remark { get; set; }

        [ApiMember(Name="Usetag", Description="有效标识", DataType="string", IsRequired=true)]
        public virtual string Usetag { get; set; }
    }

    public partial class RoleConfigResponse
        : BaseResponse
    {
        [ApiMember(Name="QueryData", Description="返回部门信息", DataType="List", IsRequired=true)]
        public virtual Report QueryData { get; set; }
    }

    [Route("/RolePower")]
    public partial class RolePower
        : BaseRequest, IReturn<RolePowerResponse>
    {
        [ApiMember(Name="RequestType", Description="请求方法", DataType="string", IsRequired=true)]
        public virtual short RequestType { get; set; }

        [ApiMember(Name="RoleNo", Description="角色编号", DataType="string", IsRequired=true)]
        public virtual string RoleNo { get; set; }

        [ApiMember(Name="Menus", Description="菜单项", DataType="IList<string>", IsRequired=true)]
        public virtual IList<string> Menus { get; set; }

        [ApiMember(Name="Handles", Description="操作权限", DataType="IList<string>", IsRequired=true)]
        public virtual IList<string> Handles { get; set; }
    }

    public partial class RolePowerResponse
        : BaseResponse
    {
        public RolePowerResponse()
        {
            Menus = new List<MenuPriView>{};
        }

        [ApiMember(Name="QueryData", Description="返回权限信息", DataType="List", IsRequired=true)]
        public virtual Report QueryData { get; set; }

        public virtual List<MenuPriView> Menus { get; set; }
    }

    [Route("/StaffConfig")]
    public partial class StaffConfig
        : BaseRequest, IReturn<StaffConfigResponse>
    {
        [ApiMember(Name="RequestType", Description="请求方法", DataType="string", IsRequired=true)]
        public virtual short RequestType { get; set; }

        [ApiMember(Name="StaffNo", Description="员工编号", DataType="string", IsRequired=true)]
        public virtual string StaffNo { get; set; }

        [ApiMember(Name="StaffName", Description="员工姓名", DataType="string", IsRequired=true)]
        public virtual string StaffName { get; set; }

        [ApiMember(Name="OperatorCardNo", Description="操作员卡号", DataType="string", IsRequired=true)]
        public virtual string OperatorCardNo { get; set; }

        [ApiMember(Name="OperCardPwd", Description="员工密码", DataType="string", IsRequired=true)]
        public virtual string OperCardPwd { get; set; }

        [ApiMember(Name="DepartNo", Description="部门编号", DataType="string", IsRequired=true)]
        public virtual string DepartNo { get; set; }

        [ApiMember(Name="DimissionTag", Description="是否离职", DataType="string", IsRequired=true)]
        public virtual string DimissionTag { get; set; }
    }

    public partial class StaffConfigResponse
        : BaseResponse
    {
        [ApiMember(Name="QueryData", Description="返回员工信息", DataType="List", IsRequired=true)]
        public virtual Report QueryData { get; set; }
    }

    [Route("/StaffRole")]
    public partial class StaffRole
        : BaseRequest, IReturn<StaffRoleResponse>
    {
        [ApiMember(Name="RequestType", Description="请求方法", DataType="string", IsRequired=true)]
        public virtual short RequestType { get; set; }

        [ApiMember(Name="StaffNo", Description="员工编号", DataType="string", IsRequired=true)]
        public virtual string StaffNo { get; set; }

        [ApiMember(Name="Roles", Description="权限", DataType="IList<string>", IsRequired=true)]
        public virtual IList<string> Roles { get; set; }
    }

    public partial class StaffRoleResponse
        : BaseResponse
    {
        [ApiMember(Name="QueryData", Description="返回权限信息", DataType="List", IsRequired=true)]
        public virtual Report QueryData { get; set; }
    }
}

namespace WeChat.ServiceModel.Wx
{

    [Route("/AccessToken")]
    public partial class AccessToken
        : BaseRequest, IReturn<AccessTokenResponse>
    {
    }

    public partial class AccessTokenResponse
        : BaseResponse
    {
        public virtual string AccessToken { get; set; }
        public virtual string ExpiresIn { get; set; }
    }

    [Route("/CreateOrder")]
    public partial class CreateOrder
        : BaseRequest, IReturn<CreateOrderResponse>
    {
        [ApiMember(Name="Body", Description="商品描述", DataType="string", IsRequired=true)]
        public virtual string Body { get; set; }

        [ApiMember(Name="Detail", Description="商品详情", DataType="string")]
        public virtual string Detail { get; set; }

        [ApiMember(Name="Attach", Description="附加数据", DataType="string")]
        public virtual string Attach { get; set; }

        [ApiMember(Name="OutTradeNo", Description="商户订单号", DataType="string", IsRequired=true)]
        public virtual string OutTradeNo { get; set; }

        [ApiMember(Name="TotalFee", Description="总金额", DataType="int", IsRequired=true)]
        public virtual int TotalFee { get; set; }

        [ApiMember(Name="SpbillCreateIp", Description="终端IP", DataType="string", IsRequired=true)]
        public virtual string SpbillCreateIp { get; set; }

        [ApiMember(Name="GoodsTag", Description="商品标记", DataType="string")]
        public virtual string GoodsTag { get; set; }

        [ApiMember(Name="Openid", Description="用户标识", DataType="string", IsRequired=true)]
        public virtual string Openid { get; set; }

        [ApiMember(Name="LimitPay", Description="指定支付方式", DataType="string", IsRequired=true)]
        public virtual string LimitPay { get; set; }

        [ApiMember(Name="ProductId", Description="商品ID", DataType="string")]
        public virtual string ProductId { get; set; }
    }

    public partial class CreateOrderResponse
        : BaseResponse
    {
        [ApiMember(Name="PrepayId", Description="预支付交易会话标识", DataType="string", IsRequired=true)]
        public virtual string PrepayId { get; set; }
    }

    [Route("/AccessToken")]
    public partial class TemplateMessage
        : BaseRequest, IReturn<TemplateMessageResponse>
    {
        public virtual string touser { get; set; }
        public virtual string template_id { get; set; }
        public virtual string url { get; set; }
        public virtual string keynote1 { get; set; }
        public virtual string keynote2 { get; set; }
    }

    public partial class TemplateMessageResponse
        : BaseResponse
    {
        public virtual string errcode { get; set; }
        public virtual string errmsg { get; set; }
    }
}

