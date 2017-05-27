using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WeChat.Models;
using WeChat.ServiceModel.PrivilegePR;
using Wx.Utility.Extensions;
using Wx.WEB.Core.Common;
using Wx.WEB.Core.Controllers;
using Wx.Web.Core.Mvc.Filter;
using Wx.WEB.Core.ViewModels;

namespace Wx.WEB.Controllers
{
    public class PrivilegePrController : BaseController
    {

        /// <summary>
        /// 初始化员工信息维护页面
        /// </summary>
        /// <returns></returns>
        [ForeVerufyActionFilter]
        public ActionResult PrStaffConfig()
        {
            var rsp = WeChatHelper.PostService<DeptStaff, DeptStaffResponse>("DeptStaff", new DeptStaff { RequestType = 0, CurrDept = Session["DepartNo"].CastTo(""), CurrOper = Session["StaffNo"].CastTo("") });
            List<InsideDepart> departList = rsp.Departs.ToList();
            departList.Add(new InsideDepart { DEPARTNO = "", DEPARTNAME = "--请选择--" });

            List<InsideStaff> staffList = rsp.Staffs.ToList();
            staffList.Add(new InsideStaff { STAFFNO = "", STAFFNAME = "--请选择--", DEPARTNO = "" });

            ViewBag.Staffs = JsonConvert.SerializeObject(staffList.OrderBy(p => p.STAFFNO));
            ViewBag.Departs = JsonConvert.SerializeObject(departList.OrderBy(p => p.DEPARTNO));

            GridBusinessRule girdBusinessRule = new GridBusinessRule("员工信息维护")
            {
                GridId = "PrStaffConfig",
                ToolbarItem = "search,add,edit,delete",
                PrimaryKey = "STAFFNO",
                AutoSearch = false,
                IsClosedQueryModal = "false",
                AddUrl = Url.Action("AddPrStaffConfig"),
                EditUrl = Url.Action("ModifyPrStaffConfig"),
                DeleteUrl = Url.Action("DeletePrStaffConfig"),
                GridDataUrl = Url.Action("QueryPrStaffConfig")
            };
            return View(girdBusinessRule);
        }

        /// <summary>
        /// 员工信息查询
        /// </summary>
        /// <param name="searchDeptId"></param>
        /// <param name="searchStaffNo"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult QueryPrStaffConfig(string searchDeptId, string searchStaffNo)
        {
            StaffConfig request = new StaffConfig
            {
                RequestType = 0,
                DepartNo = searchDeptId,
                StaffNo = searchStaffNo
            };
            string response = WeChatHelper.PostService("StaffConfig", request);
            return JavaScript(response);
        }

        /// <summary>
        /// 新增员工信息
        /// </summary>
        /// <param name="staffNo"></param>
        /// <param name="staffName"></param>
        /// <param name="departNo"></param>
        /// <param name="dimissionTag"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult AddPrStaffConfig(string staffNo, string staffName, string departNo, string dimissionTag)
        {
            StaffConfig request = new StaffConfig
            {
                RequestType = 1,
                StaffNo = staffNo,
                StaffName = staffName,
                DepartNo = departNo,
                DimissionTag = dimissionTag,
                CurrOper = Session["StaffNo"].CastTo(""),
            };
            StaffConfigResponse response = WeChatHelper.PostService<StaffConfig, StaffConfigResponse>("StaffConfig", request);
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="staffNo"></param>
        /// <param name="staffName"></param>
        /// <param name="departNo"></param>
        /// <param name="dimissionTag"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult ModifyPrStaffConfig(IEnumerable<string> ids, string staffNo, string staffName, string departNo, string dimissionTag)
        {
            StaffConfig request = new StaffConfig
            {
                RequestType = 2,
                StaffNo = ids.First(),
                StaffName = staffName,
                DepartNo = departNo,
                DimissionTag = dimissionTag,
                CurrOper = Session["StaffNo"].CastTo(""),
            };
            StaffConfigResponse response = WeChatHelper.PostService<StaffConfig, StaffConfigResponse>("StaffConfig", request);
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult DeletePrStaffConfig(IEnumerable<string> ids)
        {
            StaffConfig request = new StaffConfig
            {
                RequestType = 3,
                StaffNo = ids.First()
            };
            StaffConfigResponse response = WeChatHelper.PostService<StaffConfig, StaffConfigResponse>("StaffConfig", request);
            return Json(response, JsonRequestBehavior.DenyGet);
        }


        /// <summary>
        /// 初始化部门信息维护页面
        /// </summary>
        /// <returns></returns>
        [ForeVerufyActionFilter]
        public ActionResult PrDepartConfig()
        {
            GridBusinessRule girdBusinessRule = new GridBusinessRule("部门信息维护")
            {
                GridId = "PrDepartConfig",
                ToolbarItem = "add,edit,delete",
                PrimaryKey = "DEPARTNO",
                AutoSearch = true,
                IsClosedQueryModal = "true",
                AddUrl = Url.Action("AddPrDepartConfig"),
                EditUrl = Url.Action("ModifyPrDepartConfig"),
                DeleteUrl = Url.Action("DeletePrDepartConfig"),
                GridDataUrl = Url.Action("QueryPrDepartConfig")
            };
            return View(girdBusinessRule);
        }

        /// <summary>
        /// 部门信息查询
        /// </summary>
        /// <param name="searchDeptId"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult QueryPrDepartConfig(string searchDeptId)
        {
            DepartConfig request = new DepartConfig
            {
                RequestType = 0,
                DepartNo = searchDeptId
            };
            string response = WeChatHelper.PostService("DepartConfig", request);
            return JavaScript(response);
        }

        /// <summary>
        /// 新增部门信息
        /// </summary>
        /// <param name="departNo"></param>
        /// <param name="departName"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult AddPrDepartConfig(string departNo, string departName, string remark)
        {
            DepartConfig request = new DepartConfig
            {
                RequestType = 1,
                DepartNo = departNo,
                DepartName = departName,
                Remark = remark,
                CurrOper = Session["StaffNo"].CastTo(""),
            };
            DepartConfigResponse response = WeChatHelper.PostService<DepartConfig, DepartConfigResponse>("DepartConfig", request);
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="departName"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult ModifyPrDepartConfig(IEnumerable<string> ids, string departName, string remark)
        {
            DepartConfig request = new DepartConfig
            {
                RequestType = 2,
                DepartNo = ids.First(),
                DepartName = departName,
                Remark = remark,
                CurrOper = Session["StaffNo"].CastTo(""),
            };
            DepartConfigResponse response = WeChatHelper.PostService<DepartConfig, DepartConfigResponse>("DepartConfig", request);
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult DeletePrDepartConfig(IEnumerable<string> ids)
        {
            DepartConfig request = new DepartConfig
            {
                RequestType = 3,
                DepartNo = ids.First()
            };
            DepartConfigResponse response = WeChatHelper.PostService<DepartConfig, DepartConfigResponse>("DepartConfig", request);
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 初始化角色信息维护页面
        /// </summary>
        /// <returns></returns>
        [ForeVerufyActionFilter]
        public ActionResult PrRoleConfig()
        {
            GridBusinessRule girdBusinessRule = new GridBusinessRule("角色信息维护")
            {
                GridId = "PrRoleConfig",
                ToolbarItem = "add,edit,delete",
                PrimaryKey = "ROLENO",
                AutoSearch = true,
                IsClosedQueryModal = "true",
                AddUrl = Url.Action("AddPrRoleConfig"),
                EditUrl = Url.Action("ModifyPrRoleConfig"),
                DeleteUrl = Url.Action("DeletePrRoleConfig"),
                GridDataUrl = Url.Action("QueryPrRoleConfig")
            };
            return View(girdBusinessRule);
        }

        /// <summary>
        /// 角色信息查询
        /// </summary>
        /// <param name="searchRoleId"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult QueryPrRoleConfig(string searchRoleId)
        {
            RoleConfig request = new RoleConfig
            {
                RequestType = 0,
                RoleNo = searchRoleId
            };
            string response = WeChatHelper.PostService("RoleConfig", request);
            return JavaScript(response);
        }

        /// <summary>
        /// 新增角色信息
        /// </summary>
        /// <param name="roleNo"></param>
        /// <param name="roleName"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult AddPrRoleConfig(string roleNo, string roleName, string remark)
        {
            RoleConfig request = new RoleConfig
            {
                RequestType = 1,
                RoleNo = roleNo,
                RoleName = roleName,
                Remark = remark,
                CurrOper = Session["StaffNo"].CastTo(""),
            };
            RoleConfigResponse response = WeChatHelper.PostService<RoleConfig, RoleConfigResponse>("RoleConfig", request);
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="roleName"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult ModifyPrRoleConfig(IEnumerable<string> ids, string roleName, string remark)
        {
            RoleConfig request = new RoleConfig
            {
                RequestType = 2,
                RoleNo = ids.First(),
                RoleName = roleName,
                Remark = remark,
                CurrOper = Session["StaffNo"].CastTo(""),
            };
            RoleConfigResponse response = WeChatHelper.PostService<RoleConfig, RoleConfigResponse>("RoleConfig", request);
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult DeletePrRoleConfig(IEnumerable<string> ids)
        {
            RoleConfig request = new RoleConfig
            {
                RequestType = 3,
                RoleNo = ids.First()
            };
            RoleConfigResponse response = WeChatHelper.PostService<RoleConfig, RoleConfigResponse>("RoleConfig", request);
            return Json(response, JsonRequestBehavior.DenyGet);
        }


        /// <summary>
        /// 初始化员工角色信息维护页面
        /// </summary>
        /// <returns></returns>
        [ForeVerufyActionFilter]
        public ActionResult PrStaffRoleConfig()
        {
            var rsp = WeChatHelper.PostService<DeptStaff, DeptStaffResponse>("DeptStaff", new DeptStaff { RequestType = 0, CurrDept = Session["DepartNo"].CastTo(""), CurrOper = Session["StaffNo"].CastTo("") });
            List<InsideDepart> departList = rsp.Departs.ToList();
            departList.Add(new InsideDepart { DEPARTNO = "", DEPARTNAME = "--请选择--" });

            List<InsideStaff> staffList = rsp.Staffs.ToList();
            staffList.Add(new InsideStaff { STAFFNO = "", STAFFNAME = "--请选择--", DEPARTNO = "" });

            ViewBag.Staffs = JsonConvert.SerializeObject(staffList.OrderBy(p => p.STAFFNO));
            ViewBag.Departs = JsonConvert.SerializeObject(departList.OrderBy(p => p.DEPARTNO));

            GridBusinessRule girdBusinessRule = new GridBusinessRule("员工角色信息维护");
            girdBusinessRule.GridId = "PrStaffRoleConfig";
            girdBusinessRule.ToolbarItem = "search";
            girdBusinessRule.PrimaryKey = "ROLENO";
            girdBusinessRule.AutoSearch = false;
            girdBusinessRule.IsClosedQueryModal = "false";
            girdBusinessRule.GridDataUrl = Url.Action("QueryPrStaffNoRole");
            girdBusinessRule.PermmitUrl = Url.Action("ModifyPrStaffRole");
            return View(girdBusinessRule);
        }

        /// <summary>
        /// 员工角色信息查询
        /// </summary>
        /// <param name="searchStaffNo"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult QueryPrStaffNoRole(string searchStaffNo)
        {
            StaffRole request = new StaffRole
            {
                RequestType = 0,
                StaffNo = searchStaffNo
            };
            string response = WeChatHelper.PostService("StaffRole", request);
            return JavaScript(response);
        }

        /// <summary>
        /// 员工角色信息修改
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="staffNo"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult ModifyPrStaffRole(IEnumerable<string> ids, string staffNo)
        {
            StaffRole request = new StaffRole
            {
                RequestType = 1,
                Roles = ids.ToList(),
                StaffNo = staffNo,
                CurrOper = Session["StaffNo"].CastTo(""),
            };
            StaffRoleResponse response = WeChatHelper.PostService<StaffRole, StaffRoleResponse>("StaffRole", request);
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        [ForeVerufyActionFilter]
        public ActionResult PrRolePriConfig()
        {
            List<Role> roles = (List<Role>)CommonHelper.GetCommonApi("Roles", 3);
            Role role = roles.Find(p => p.ROLENAME == "---请选择---");
            if (role == null)
            {
                roles.Add(new Role { ROLENO = "", ROLENAME = "---请选择---" });
            }
            ViewBag.Roles = JsonConvert.SerializeObject(roles.OrderBy(p => p.ROLENO));
            GridBusinessRule girdBusinessRule = new GridBusinessRule("角色操作权限维护")
            {
                GridId = "PrRolePriConfig",
                PrimaryKey = "POWERNO",
                AutoSearch = true,
                IsPaging = "false",
                GridDataUrl = Url.Action("QueryRolePrHandleConfig"),
                TreeUrl = Url.Action("QueryRolePrMenusConfig"),
                EditUrl = Url.Action("ModifyRolePower")
            };
            return View(girdBusinessRule);
        }

        /// <summary>
        /// 角色操作权限查询
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult QueryRolePrHandleConfig(string roleId)
        {
            RolePower request = new RolePower
            {
                RequestType = 1,
                RoleNo = roleId
            };
            string response = WeChatHelper.PostService("RolePower", request);
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 角色菜单权限查询
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult QueryRolePrMenusConfig(string roleId)
        {
            RolePower request = new RolePower
            {
                RequestType = 0,
                RoleNo = roleId
            };
            string response = WeChatHelper.PostService("RolePower", request);
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 修改角色权限
        /// </summary>
        /// <param name="menus"></param>
        /// <param name="handles"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult ModifyRolePower(IEnumerable<string> menus, IEnumerable<string> handles, string roleId)
        {
            RolePower request = new RolePower
            {
                RequestType = 2,
                RoleNo = roleId,
                Menus = menus.ToList(),
                Handles = handles.ToList(),
                CurrOper = Session["StaffNo"].CastTo(""),
            };
            string response = WeChatHelper.PostService("RolePower", request);
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        [ForeVerufyActionFilter]
        public ActionResult PrMsg()
        {
            return View();
        }

        [ForeVerufyActionFilter]
        public ActionResult PrMsgInbox()
        {
            GridBusinessRule girdBusinessRule = new GridBusinessRule("收件箱")
            {
                GridId = "PrMsgInbox",
                ToolbarItem = "delete,transfer,returnmsg",
                PrimaryKey = "MSGID",
                AutoSearch = true,
                IsClosedQueryModal = "true",
                DeleteUrl = Url.Action("DelMsg"),
                GridDataUrl = Url.Action("QueryInbox"),
                PermmitUrl = Url.Action("InboxCheck")
            };
            return View(girdBusinessRule);
        }

        [AjaxOnly]
        [HttpPost]
        public ActionResult QueryInbox(int pageIndex, int pageSize)
        {
            Msg request = new Msg
            {
                RequestType = 0,
                PageIndex = pageIndex,
                PageSize = pageSize,
                DepartNo = Session["DepartNo"].CastTo(""),
                StaffNo = Session["StaffNo"].CastTo("")
            };
            string response = WeChatHelper.PostService("Msg", request);
            return JavaScript(response);
        }

        [ForeVerufyActionFilter]
        public ActionResult PrMsgSentItems()
        {
            GridBusinessRule girdBusinessRule = new GridBusinessRule("已发送消息")
            {
                GridId = "PrMsgSentItems",
                ToolbarItem = "delete,transfer",
                PrimaryKey = "MSGID",
                AutoSearch = true,
                IsClosedQueryModal = "true",
                DeleteUrl = Url.Action("DelMsg"),
                GridDataUrl = Url.Action("QuerySentItems")
            };
            return View(girdBusinessRule);
        }

        [AjaxOnly]
        [HttpPost]
        public ActionResult QuerySentItems(int pageIndex, int pageSize)
        {
            Msg request = new Msg
            {
                RequestType = 1,
                PageIndex = pageIndex,
                PageSize = pageSize,
                DepartNo = Session["DepartNo"].CastTo(""),
                StaffNo = Session["StaffNo"].CastTo("")
            };
            string response = WeChatHelper.PostService("Msg", request);
            return JavaScript(response);
        }

        [ForeVerufyActionFilter]
        public ActionResult PrMsgNewMsg(string id, string level, string state, string body, string time, string title, string sender, string fileNo,string isPage,string boxfrom)
        {
            List<Role> roles = (List<Role>)CommonHelper.GetCommonApi("Roles", 3);
            List<InsideDepart> departs = (List<InsideDepart>)CommonHelper.GetCommonApi("Departs", 4);
            List<InsideStaff> staffs = (List<InsideStaff>)CommonHelper.GetCommonApi("Staffs", 5);

            List<RoleExt> roleExts = roles.Select(role => new RoleExt() { id = role.ROLENO, text = role.ROLENAME, desc = role.ROLENO + ":" + role.ROLENAME }).ToList();
            List<DepartExt> departExts = departs.Select(depart => new DepartExt() { id = depart.DEPARTNO, text = depart.DEPARTNAME, desc = depart.DEPARTNO + ":" + depart.DEPARTNAME }).ToList();
            List<StaffExt> staffExts = staffs.Select(staff => new StaffExt() { id = staff.STAFFNO, text = staff.STAFFNAME, desc = staff.STAFFNO + ":" + staff.STAFFNAME }).ToList();
            //删除当前用户
            staffExts.Remove(staffExts.Where(r => r.id == Session["StaffNo"].CastTo("")).Single());

            ViewBag.Roles = JsonConvert.SerializeObject(roleExts.OrderBy(p => p.id));
            ViewBag.Departs = JsonConvert.SerializeObject(departExts.OrderBy(p => p.id));
            ViewBag.Staffs = JsonConvert.SerializeObject(staffExts.OrderBy(p => p.id));
            if (!string.IsNullOrEmpty(id))
            {
                ViewBag.Id = id;
                ViewBag.Title = title;
                ViewBag.Level = level;
                ViewBag.State = state;
                ViewBag.Body = body;
                ViewBag.Time = " 发送于:" + time;
                ViewBag.Sender = sender;
                ViewBag.FileNo = fileNo;
                ViewBag.IsPage = isPage;
                ViewBag.Boxfrom = boxfrom;
            }

            GridBusinessRule girdBusinessRule = new GridBusinessRule("写新消息")
            {
                AutoSearch = false,
                IsClosedQueryModal = "true",
                EditUrl = Url.Action("QueryBeforeOrNext"),
                DownUrl = Url.Action("DownLoadFile"),
                PermmitUrl = Url.Action("SendMsg")
            };
            return View(girdBusinessRule);
        }

        [AjaxOnly]
        [HttpPost]
        public ActionResult QueryBeforeOrNext(string msgType, string msgId, string boxfrom)
        {
            Msg request = new Msg
            {
                RequestType = 4,
                MsgType = msgType,
                MsgId = msgId,
                Boxfrom = boxfrom,
                DepartNo = Session["DepartNo"].CastTo(""),
                StaffNo = Session["StaffNo"].CastTo("")
            };
            string response = WeChatHelper.PostService("Msg", request);
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        [ForeVerufyActionFilter]
        public void DownLoadFile(string fileNo)
        {
            Msg request = new Msg
            {
                RequestType = 5,
                FileNo = fileNo
            };
            MsgResponse response = WeChatHelper.PostService<Msg, MsgResponse>("Msg", request);
            if (response.DownFile.Length != 0)
            {
                Response.Clear();
                Response.Buffer = true;
                string strTemp = HttpUtility.UrlEncode(response.FileName, System.Text.Encoding.UTF8);
                Response.AppendHeader("Content-Disposition", String.Format("attachment;filename={0}", strTemp));
                Response.AppendHeader("Content-Length", response.DownFile.Length.ToString(CultureInfo.InvariantCulture));
                Response.BinaryWrite(response.DownFile);
                Response.Flush();
                Response.End();
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="roleNos"></param>
        /// <param name="departNos"></param>
        /// <param name="staffNos"></param>
        /// <param name="grade"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="fileName"></param>
        /// <param name="fileData"></param>
        /// <param name="fileNo"></param>
        /// <returns></returns>
        [AjaxOnly]
        [HttpPost]
        public ActionResult SendMsg(string roleNos, string departNos, string staffNos, string grade, string title, string content, string fileName, string fileData, string fileNo)
        {
            if (fileNo == "undefined")
            {
                fileNo = "";
            }
            byte[] myByte = null;
            if (string.IsNullOrEmpty(fileNo) && !string.IsNullOrEmpty(fileData))
            {
                myByte = Convert.FromBase64String(fileData.Split(",")[1]);
            }

            List<string> roleList = roleNos.Split(",").ToList();
            List<string> departList = departNos.Split(",").ToList();
            List<string> staffList = staffNos.Split(",").ToList();

            Msg request = new Msg
            {
                RequestType = 6,
                Roles = roleList,
                Departs = departList,
                StaffNos = staffList,
                Level = grade,
                Title = title.Split("发送于")[0].Trim(),
                Content = content,
                FileName = fileName,
                UpLoadFile = myByte,
                FileNo = fileNo,
                DepartNo = Session["DepartNo"].CastTo(""),
                StaffNo = Session["StaffNo"].CastTo("")
            };
            string response = WeChatHelper.PostService("Msg", request);
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        [AjaxOnly]
        [HttpPost]
        public ActionResult DelMsg(List<string> msgIds, string msgType)
        {
            Msg request = new Msg
            {
                RequestType = 7,
                MsgIds = msgIds,
                MsgType = msgType,
                DepartNo = Session["DepartNo"].CastTo(""),
                StaffNo = Session["StaffNo"].CastTo("")
            };
            string response = WeChatHelper.PostService("Msg", request);
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        [AjaxOnly]
        [HttpPost]
        public ActionResult InboxCheck(string msgId)
        {
            Msg request = new Msg
            {
                RequestType = 9,
                MsgId = msgId,
                DepartNo = Session["DepartNo"].CastTo(""),
                StaffNo = Session["StaffNo"].CastTo("")
            };
            string response = WeChatHelper.PostService("Msg", request);
            return Json(response, JsonRequestBehavior.DenyGet);
        }
    }
}
