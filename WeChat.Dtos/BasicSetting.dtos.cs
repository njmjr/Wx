/* Options:
Date: 2017-05-31 17:27:55
Version: 4.00
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://osc.com:8889

//GlobalNamespace: 
//MakePartial: True
//MakeVirtual: True
//MakeInternal: False
//MakeDataContractsExtensible: False
//AddReturnMarker: True
//AddDescriptionAsComments: True
//AddDataContractAttributes: False
//AddIndexesToDataMembers: False
//AddGeneratedCodeAttributes: False
//AddResponseStatus: False
//AddImplicitVersion: 
//InitializeCollections: True
//ExportValueTypes: False
//IncludeTypes: 
//ExcludeTypes: 
//AddNamespaces: 
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
using WeChat.ServiceModel.Login;
using WeChat.ServiceModel.PrivilegePR;
using WeChat.ServiceModel.Crawler;
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
//    public virtual bool? checked { get; set; }
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

    public partial class TfBMsg
    {
        public virtual int MSGID { get; set; }
        public virtual string MSGPOS { get; set; }
        public virtual string MSGTITLE { get; set; }
        public virtual string MSGBODY { get; set; }
        public virtual string MSGLEVEL { get; set; }
        public virtual DateTime MSGTIME { get; set; }
        public virtual string MSGDEPT { get; set; }
        public virtual string MSGGER { get; set; }
        public virtual string MSGATTACH { get; set; }
        public virtual string FILENO { get; set; }
        public virtual string STATE { get; set; }
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
        public virtual IEnumerable<InsideDepart> Departs { get; set; }
        public virtual IEnumerable<InsideStaff> Staffs { get; set; }
    }
}

namespace WeChat.ServiceModel.Crawler
{

    [Route("/CrawlerPan")]
    public partial class CrawlerPan
        : BaseRequest, IReturn<CrawlerPanResponse>
    {
        ///<summary>
        ///查询参数
        ///</summary>
        [ApiMember(Name="SearchData", Description="查询参数", DataType="string", IsRequired=true)]
        public virtual string SearchData { get; set; }

        ///<summary>
        ///页数
        ///</summary>
        [ApiMember(Name="pageIndex", Description="页数", DataType="int", IsRequired=true)]
        public virtual int pageIndex { get; set; }

        ///<summary>
        ///一页多少
        ///</summary>
        [ApiMember(Name="pageSize", Description="一页多少", DataType="int", IsRequired=true)]
        public virtual int pageSize { get; set; }

        ///<summary>
        ///查询总条数
        ///</summary>
        [ApiMember(Name="ResultNum", Description="查询总条数", DataType="int", IsRequired=true)]
        public virtual int ResultNum { get; set; }
    }

    public partial class CrawlerPanResponse
        : BaseResponse
    {
        ///<summary>
        ///返回查询结果
        ///</summary>
        [ApiMember(Name="Reports", Description="返回查询结果", DataType="List", IsRequired=true)]
        public virtual Report Reports { get; set; }
    }
}

namespace WeChat.ServiceModel.Login
{

    [Route("/Login")]
    public partial class Login
        : BaseRequest, IReturn<LoginResponse>
    {
        ///<summary>
        ///请求方法
        ///</summary>
        [ApiMember(Name="RequestType", Description="请求方法", DataType="short", IsRequired=true)]
        public virtual short RequestType { get; set; }

        ///<summary>
        ///登录员工号
        ///</summary>
        [ApiMember(Name="LoginStaffNo", Description="登录员工号", DataType="string", IsRequired=true)]
        public virtual string LoginStaffNo { get; set; }

        ///<summary>
        ///密码
        ///</summary>
        [ApiMember(Name="Pwd", Description="密码", DataType="string", IsRequired=true)]
        public virtual string Pwd { get; set; }
    }

    public partial class LoginResponse
        : BaseResponse
    {
        ///<summary>
        ///部门编号
        ///</summary>
        [ApiMember(Name="DepartNo", Description="部门编号", DataType="string", IsRequired=true)]
        public virtual string DepartNo { get; set; }

        ///<summary>
        ///员工姓名
        ///</summary>
        [ApiMember(Name="StaffName", Description="员工姓名", DataType="string", IsRequired=true)]
        public virtual string StaffName { get; set; }

        ///<summary>
        ///部门名称
        ///</summary>
        [ApiMember(Name="DepartName", Description="部门名称", DataType="string", IsRequired=true)]
        public virtual string DepartName { get; set; }
    }
}

namespace WeChat.ServiceModel.PrivilegePR
{

    [Route("/DepartConfig")]
    public partial class DepartConfig
        : BaseRequest, IReturn<DepartConfigResponse>
    {
        ///<summary>
        ///请求方法
        ///</summary>
        [ApiMember(Name="RequestType", Description="请求方法", DataType="string", IsRequired=true)]
        public virtual short RequestType { get; set; }

        ///<summary>
        ///部门编号
        ///</summary>
        [ApiMember(Name="DepartNo", Description="部门编号", DataType="string", IsRequired=true)]
        public virtual string DepartNo { get; set; }

        ///<summary>
        ///部门名称
        ///</summary>
        [ApiMember(Name="DepartName", Description="部门名称", DataType="string", IsRequired=true)]
        public virtual string DepartName { get; set; }

        ///<summary>
        ///更新员工
        ///</summary>
        [ApiMember(Name="Updatestaffno", Description="更新员工", DataType="string", IsRequired=true)]
        public virtual string Updatestaffno { get; set; }

        ///<summary>
        ///更新时间
        ///</summary>
        [ApiMember(Name="Updatetime", Description="更新时间", DataType="string", IsRequired=true)]
        public virtual DateTime Updatetime { get; set; }

        ///<summary>
        ///备注
        ///</summary>
        [ApiMember(Name="Remark", Description="备注", DataType="string", IsRequired=true)]
        public virtual string Remark { get; set; }

        ///<summary>
        ///有效标识
        ///</summary>
        [ApiMember(Name="Usetag", Description="有效标识", DataType="string", IsRequired=true)]
        public virtual string Usetag { get; set; }
    }

    public partial class DepartConfigResponse
        : BaseResponse
    {
        ///<summary>
        ///返回部门信息
        ///</summary>
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

    [Route("/Msg")]
    public partial class Msg
        : BaseRequest, IReturn<MsgResponse>
    {
        public Msg()
        {
            Roles = new List<string>{};
            Departs = new List<string>{};
            StaffNos = new List<string>{};
            UpLoadFile = new byte[]{};
            MsgIds = new List<string>{};
        }

        ///<summary>
        ///请求方法
        ///</summary>
        [ApiMember(Name="RequestType", Description="请求方法", DataType="short", IsRequired=true)]
        public virtual short RequestType { get; set; }

        ///<summary>
        ///部门编号
        ///</summary>
        [ApiMember(Name="DepartNo", Description="部门编号", DataType="string", IsRequired=true)]
        public virtual string DepartNo { get; set; }

        ///<summary>
        ///员工编号
        ///</summary>
        [ApiMember(Name="StaffNo", Description="员工编号", DataType="string", IsRequired=true)]
        public virtual string StaffNo { get; set; }

        ///<summary>
        ///页数
        ///</summary>
        [ApiMember(Name="PageIndex", Description="页数", DataType="int")]
        public virtual int PageIndex { get; set; }

        ///<summary>
        ///每页记录数
        ///</summary>
        [ApiMember(Name="PageSize", Description="每页记录数", DataType="int")]
        public virtual int PageSize { get; set; }

        ///<summary>
        ///消息Id
        ///</summary>
        [ApiMember(Name="MsgId", Description="消息Id", DataType="string")]
        public virtual string MsgId { get; set; }

        ///<summary>
        ///消息主题
        ///</summary>
        [ApiMember(Name="Title", Description="消息主题", DataType="string")]
        public virtual string Title { get; set; }

        ///<summary>
        ///消息内容
        ///</summary>
        [ApiMember(Name="Content", Description="消息内容", DataType="string")]
        public virtual string Content { get; set; }

        ///<summary>
        ///消息级别
        ///</summary>
        [ApiMember(Name="Level", Description="消息级别", DataType="string")]
        public virtual string Level { get; set; }

        ///<summary>
        ///查询类型
        ///</summary>
        [ApiMember(Name="MsgType", Description="查询类型", DataType="string")]
        public virtual string MsgType { get; set; }

        ///<summary>
        ///接收角色
        ///</summary>
        [ApiMember(Name="Roles", Description="接收角色", DataType="List<string>")]
        public virtual List<string> Roles { get; set; }

        ///<summary>
        ///接收部门
        ///</summary>
        [ApiMember(Name="Departs", Description="接收部门", DataType="List<string>")]
        public virtual List<string> Departs { get; set; }

        ///<summary>
        ///接收员工
        ///</summary>
        [ApiMember(Name="StaffNos", Description="接收员工", DataType="List<string>")]
        public virtual List<string> StaffNos { get; set; }

        ///<summary>
        ///上传附件名称
        ///</summary>
        [ApiMember(Name="FileName", Description="上传附件名称", DataType="string")]
        public virtual string FileName { get; set; }

        ///<summary>
        ///上传附件
        ///</summary>
        [ApiMember(Name="UpLoadFile", Description="上传附件", DataType="byte[]")]
        public virtual byte[] UpLoadFile { get; set; }

        ///<summary>
        ///附件编号
        ///</summary>
        [ApiMember(Name="FileNo", Description="附件编号", DataType="string")]
        public virtual string FileNo { get; set; }

        ///<summary>
        ///消息S
        ///</summary>
        [ApiMember(Name="MsgIds", Description="消息S", DataType="List<string>")]
        public virtual List<string> MsgIds { get; set; }

        ///<summary>
        ///收发0收1发
        ///</summary>
        [ApiMember(Name="Boxfrom", Description="收发0收1发", DataType="string")]
        public virtual string Boxfrom { get; set; }
    }

    public partial class MsgResponse
        : BaseResponse
    {
        public MsgResponse()
        {
            DownFile = new byte[]{};
        }

        ///<summary>
        ///返回信息
        ///</summary>
        [ApiMember(Name="QueryData", Description="返回信息", DataType="List", IsRequired=true)]
        public virtual Report QueryData { get; set; }

        ///<summary>
        ///消息:0下一条，1上一条
        ///</summary>
        [ApiMember(Name="Msg", Description="消息:0下一条，1上一条", DataType="int")]
        public virtual TfBMsg Msg { get; set; }

        ///<summary>
        ///下载附件
        ///</summary>
        [ApiMember(Name="DownFile", Description="下载附件", DataType="byte[]")]
        public virtual byte[] DownFile { get; set; }

        ///<summary>
        ///下载附件名称
        ///</summary>
        [ApiMember(Name="FileName", Description="下载附件名称", DataType="string")]
        public virtual string FileName { get; set; }

        ///<summary>
        ///收件箱个数
        ///</summary>
        [ApiMember(Name="InboxNums", Description="收件箱个数", DataType="int")]
        public virtual int InboxNums { get; set; }
    }

    [Route("/RoleConfig")]
    public partial class RoleConfig
        : BaseRequest, IReturn<RoleConfigResponse>
    {
        ///<summary>
        ///请求方法
        ///</summary>
        [ApiMember(Name="RequestType", Description="请求方法", DataType="string", IsRequired=true)]
        public virtual short RequestType { get; set; }

        ///<summary>
        ///角色编号
        ///</summary>
        [ApiMember(Name="RoleNo", Description="角色编号", DataType="string", IsRequired=true)]
        public virtual string RoleNo { get; set; }

        ///<summary>
        ///部门名称
        ///</summary>
        [ApiMember(Name="RoleName", Description="部门名称", DataType="string", IsRequired=true)]
        public virtual string RoleName { get; set; }

        ///<summary>
        ///更新员工
        ///</summary>
        [ApiMember(Name="Updatestaffno", Description="更新员工", DataType="string", IsRequired=true)]
        public virtual string Updatestaffno { get; set; }

        ///<summary>
        ///更新时间
        ///</summary>
        [ApiMember(Name="Updatetime", Description="更新时间", DataType="string", IsRequired=true)]
        public virtual DateTime Updatetime { get; set; }

        ///<summary>
        ///备注
        ///</summary>
        [ApiMember(Name="Remark", Description="备注", DataType="string", IsRequired=true)]
        public virtual string Remark { get; set; }

        ///<summary>
        ///有效标识
        ///</summary>
        [ApiMember(Name="Usetag", Description="有效标识", DataType="string", IsRequired=true)]
        public virtual string Usetag { get; set; }
    }

    public partial class RoleConfigResponse
        : BaseResponse
    {
        ///<summary>
        ///返回部门信息
        ///</summary>
        [ApiMember(Name="QueryData", Description="返回部门信息", DataType="List", IsRequired=true)]
        public virtual Report QueryData { get; set; }
    }

    [Route("/RolePower")]
    public partial class RolePower
        : BaseRequest, IReturn<RolePowerResponse>
    {
        ///<summary>
        ///请求方法
        ///</summary>
        [ApiMember(Name="RequestType", Description="请求方法", DataType="string", IsRequired=true)]
        public virtual short RequestType { get; set; }

        ///<summary>
        ///角色编号
        ///</summary>
        [ApiMember(Name="RoleNo", Description="角色编号", DataType="string", IsRequired=true)]
        public virtual string RoleNo { get; set; }

        ///<summary>
        ///菜单项
        ///</summary>
        [ApiMember(Name="Menus", Description="菜单项", DataType="IList<string>", IsRequired=true)]
        public virtual IList<string> Menus { get; set; }

        ///<summary>
        ///操作权限
        ///</summary>
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

        ///<summary>
        ///返回权限信息
        ///</summary>
        [ApiMember(Name="QueryData", Description="返回权限信息", DataType="List", IsRequired=true)]
        public virtual Report QueryData { get; set; }

        public virtual List<MenuPriView> Menus { get; set; }
    }

    [Route("/StaffConfig")]
    public partial class StaffConfig
        : BaseRequest, IReturn<StaffConfigResponse>
    {
        ///<summary>
        ///请求方法
        ///</summary>
        [ApiMember(Name="RequestType", Description="请求方法", DataType="string", IsRequired=true)]
        public virtual short RequestType { get; set; }

        ///<summary>
        ///员工编号
        ///</summary>
        [ApiMember(Name="StaffNo", Description="员工编号", DataType="string", IsRequired=true)]
        public virtual string StaffNo { get; set; }

        ///<summary>
        ///员工姓名
        ///</summary>
        [ApiMember(Name="StaffName", Description="员工姓名", DataType="string", IsRequired=true)]
        public virtual string StaffName { get; set; }

        ///<summary>
        ///操作员卡号
        ///</summary>
        [ApiMember(Name="OperatorCardNo", Description="操作员卡号", DataType="string", IsRequired=true)]
        public virtual string OperatorCardNo { get; set; }

        ///<summary>
        ///员工密码
        ///</summary>
        [ApiMember(Name="OperCardPwd", Description="员工密码", DataType="string", IsRequired=true)]
        public virtual string OperCardPwd { get; set; }

        ///<summary>
        ///部门编号
        ///</summary>
        [ApiMember(Name="DepartNo", Description="部门编号", DataType="string", IsRequired=true)]
        public virtual string DepartNo { get; set; }

        ///<summary>
        ///是否离职
        ///</summary>
        [ApiMember(Name="DimissionTag", Description="是否离职", DataType="string", IsRequired=true)]
        public virtual string DimissionTag { get; set; }
    }

    public partial class StaffConfigResponse
        : BaseResponse
    {
        ///<summary>
        ///返回员工信息
        ///</summary>
        [ApiMember(Name="QueryData", Description="返回员工信息", DataType="List", IsRequired=true)]
        public virtual Report QueryData { get; set; }
    }

    [Route("/StaffRole")]
    public partial class StaffRole
        : BaseRequest, IReturn<StaffRoleResponse>
    {
        ///<summary>
        ///请求方法
        ///</summary>
        [ApiMember(Name="RequestType", Description="请求方法", DataType="string", IsRequired=true)]
        public virtual short RequestType { get; set; }

        ///<summary>
        ///员工编号
        ///</summary>
        [ApiMember(Name="StaffNo", Description="员工编号", DataType="string", IsRequired=true)]
        public virtual string StaffNo { get; set; }

        ///<summary>
        ///权限
        ///</summary>
        [ApiMember(Name="Roles", Description="权限", DataType="IList<string>", IsRequired=true)]
        public virtual IList<string> Roles { get; set; }
    }

    public partial class StaffRoleResponse
        : BaseResponse
    {
        ///<summary>
        ///返回权限信息
        ///</summary>
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
        ///<summary>
        ///商品描述
        ///</summary>
        [ApiMember(Name="Body", Description="商品描述", DataType="string", IsRequired=true)]
        public virtual string Body { get; set; }

        ///<summary>
        ///商品详情
        ///</summary>
        [ApiMember(Name="Detail", Description="商品详情", DataType="string")]
        public virtual string Detail { get; set; }

        ///<summary>
        ///附加数据
        ///</summary>
        [ApiMember(Name="Attach", Description="附加数据", DataType="string")]
        public virtual string Attach { get; set; }

        ///<summary>
        ///商户订单号
        ///</summary>
        [ApiMember(Name="OutTradeNo", Description="商户订单号", DataType="string", IsRequired=true)]
        public virtual string OutTradeNo { get; set; }

        ///<summary>
        ///总金额
        ///</summary>
        [ApiMember(Name="TotalFee", Description="总金额", DataType="int", IsRequired=true)]
        public virtual int TotalFee { get; set; }

        ///<summary>
        ///终端IP
        ///</summary>
        [ApiMember(Name="SpbillCreateIp", Description="终端IP", DataType="string", IsRequired=true)]
        public virtual string SpbillCreateIp { get; set; }

        ///<summary>
        ///商品标记
        ///</summary>
        [ApiMember(Name="GoodsTag", Description="商品标记", DataType="string")]
        public virtual string GoodsTag { get; set; }

        ///<summary>
        ///用户标识
        ///</summary>
        [ApiMember(Name="Openid", Description="用户标识", DataType="string", IsRequired=true)]
        public virtual string Openid { get; set; }

        ///<summary>
        ///指定支付方式
        ///</summary>
        [ApiMember(Name="LimitPay", Description="指定支付方式", DataType="string", IsRequired=true)]
        public virtual string LimitPay { get; set; }

        ///<summary>
        ///商品ID
        ///</summary>
        [ApiMember(Name="ProductId", Description="商品ID", DataType="string")]
        public virtual string ProductId { get; set; }
    }

    public partial class CreateOrderResponse
        : BaseResponse
    {
        ///<summary>
        ///预支付交易会话标识
        ///</summary>
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

