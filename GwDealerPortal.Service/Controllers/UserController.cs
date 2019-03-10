using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using GwDealerPortal.DataAccess.Interfaces;
using GwDealerPortal.DataAccess;
using System.Data;
using GwDealerPortal.Service.Common;
using GwDealerPortal.DataAccess.Entities;

namespace GwDealerPortal.Service.Controllers
{
    [Authorize]
    [EnableCors("AllowAllHeaders")]
    //[Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private IUnitOfWork _uow;
        public UserController(IUnitOfWork _uow)
        {
            this._uow = _uow;
            //Utilities.Filters = HttpContext.Session.Get<List<Filter>>("Filter");
            //Utilities.EventAccess = HttpContext.Session.Get<List<EventAccess>>("EventAccess");
        }
        [AuthorizationFilterFactory(InterfaceName = "Interface",EventAccess = "AllowView")]
        [HttpGet("GetAllInterfaces", Name = "GetAllInterfaces")]
        public IActionResult GetAllInterfaces()
        {
            var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
            var _userCode =  Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
            var _interfaces = _uow.Repository<Interface>().Get(x=>x.IsDeleted == false).ToList();
                return Json(_interfaces);
        }
        [AuthorizationFilterFactory(InterfaceName = "Role", EventAccess = "AllowView")]
        [HttpGet("GetAllRoles", Name = "GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
            var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
            var _roles = _uow.Repository<UserRole>().Get(x => x.IsDeleted == false).ToList();
            return Json(_roles);
        }
        [AuthorizationFilterFactory(InterfaceName = "User", EventAccess = "AllowView")]
        [HttpGet("GetAllUsers", Name = "GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
            var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
            //var _roles = _uow.Repository<User>().Get(x => x.IsDeleted == false).ToList();
            var _query = "Select * from  [User]";
            var result = DbAccess.ExecuteQuery(DbAccess.DBPortal, _query, new Dictionary<string, System.Data.SqlClient.SqlParameter>());
            DataTable table = result.Tables[0];
            return Json(table.ToJson());
           // return Json(_roles);
        }
        [AuthorizationFilterFactory(InterfaceName = "FilterType", EventAccess = "AllowView")]
        [HttpGet("GetAllFilterTypes", Name = "GetAllFilterTypes")]
        public IActionResult GetAllFilterTypes()
        {
            var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
            var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
            var _filterTypes = _uow.Repository<FilterType>().Get(x => x.IsDeleted == false).ToList();
            return Json(_filterTypes);
        }
        [AuthorizationFilterFactory(InterfaceName = "Access", EventAccess = "AllowView")]
        [HttpGet("GetAllEventAccess", Name = "GetAllEventAccess")]
        public IActionResult GetAllEventAccess()
        {
            var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
            var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
            var _eventAccess = _uow.Repository<EventAccess>().Get().ToList();
            return Json(_eventAccess);
        }
        [AuthorizationFilterFactory(InterfaceName = "User", EventAccess = "AllowView")]
        [HttpGet("GetUserAccessByRoleID", Name = "GetUserAccessByRoleID")]
        public IActionResult GetUserAccessByRoleID(int RoleID)
        {
            var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
            var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
            var _roles = _uow.Repository<Filter>().Get(x => x.IsDeleted == false && x.UserID == null && x.UserRoleID == RoleID).ToList();
            return Json(_roles);
        }
        [AuthorizationFilterFactory(InterfaceName = "Filter", EventAccess = "AllowView")]
        [HttpGet("GetAllFilterByUserID", Name = "GetAllFilterByUserID")]
        public IActionResult GetAllFilterByUserID()
        {
            var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
            var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
            var _users = _uow.Repository<User>().Get().ToList();
            return Json(_users);
        }
        [AuthorizationFilterFactory(InterfaceName = "Interface", EventAccess = "AllowAdd")]
        [HttpPost("AddEditInterface", Name = "AddEditInterface")]
        public ActionResult AddEditInterface([FromBody]Interface interfacee)
        {
            try
            {
                var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
                var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
                if (interfacee != null)
                {
                    if(interfacee.InterfaceID < 1)
                    {
                        interfacee.CreatedById = Convert.ToInt32(_userCode.Value);
                        interfacee.CreatedDate = DateTime.Now;
                        _uow.Repository<Interface>().Insert(interfacee);
                    }
                    else
                    {
                        interfacee.UpdatedById = Convert.ToInt32(_userCode.Value);
                        interfacee.UpdatedDate = DateTime.Now;
                        _uow.Repository<Interface>().Update(interfacee);
                    }
                    _uow.Save();
                    return Json(true);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return null;
        }
        [AuthorizationFilterFactory(InterfaceName = "Interface", EventAccess = "AllowDelete")]
        [HttpPost("DeleteInterface", Name = "DeleteInterface")]
        public ActionResult DeleteInterface([FromBody] int interfaceID)
        {
            try
            {
                var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
                var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
                var _interface = _uow.Repository<Interface>().Get(x=> x.IsDeleted == false && x.InterfaceID == interfaceID).FirstOrDefault();
                if (interfaceID != 0)
                {
                    _interface.UpdatedById = Convert.ToInt32(_userCode.Value);
                    _interface.UpdatedDate = DateTime.Now;
                    _interface.IsDeleted = true;
                    _uow.Repository<Interface>().Update(_interface);
                    _uow.Save();
                    return Json(true);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return null;
        }
        [AuthorizationFilterFactory(InterfaceName = "Role", EventAccess = "AllowEdit")]
        [HttpPost("AddEditRole", Name = "AddEditRole")]
        public ActionResult AddEditRole([FromBody] UserRole role)
        {
            try
            {
                var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
                var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
                if (role != null)
                {
                    if (role.UserRoleID == 0)
                    {
                        role.CreatedById = Convert.ToInt32(_userCode.Value);
                        role.CreatedDate = DateTime.Now;
                        _uow.Repository<UserRole>().Insert(role);
                    }
                    else
                    {
                        role.UpdatedById = Convert.ToInt32(_userCode.Value);
                        role.UpdatedDate = DateTime.Now;
                        _uow.Repository<UserRole>().Update(role);
                    }
                    _uow.Save();
                    return Json(true);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return null;
        }
        [AuthorizationFilterFactory(InterfaceName = "Role", EventAccess = "AllowDelete")]
        [HttpPost("DeleteRole", Name = "DeleteRole")]
        public ActionResult DeleteRole([FromBody] int roleID)
        {
            try
            {
                var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
                var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
                var _role = _uow.Repository<UserRole>().Get(x => x.IsDeleted == false && x.UserRoleID == roleID).FirstOrDefault();
                if (roleID != 0)
                {
                    _role.UpdatedById = Convert.ToInt32(_userCode.Value);
                    _role.UpdatedDate = DateTime.Now;
                    _role.IsDeleted = true;
                    _uow.Repository<UserRole>().Update(_role);
                    _uow.Save();
                    return Json(true);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return null;
        }
        [AuthorizationFilterFactory(InterfaceName = "User", EventAccess = "AllowAdd")]
        [HttpPost("CreateUserAccess", Name = "CreateUserAccess")]
        //[AccessAuthenticationFilter(EventAccess = "Add", InterfaceName = "UserRights")]
        public ActionResult CreateUserAccess([FromBody]List<Filter> filter)
        {
            DbAccess.ExecuteQuery(DbAccess.DBPortal, "delete from filter where userroleid =" + filter[0].UserRoleID);
            var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
            var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
            //List<UserAccessDetail> _userAccessDetail = Mapper.Map<List<UserAccessDetailModel>, List<UserAccessDetail>>(userAccessDetailModel);
            var _filterType = _uow.Repository<FilterType>().Get(ft=> ft.IsDeleted == false && ft.FilterTypeName.ToLower().Contains("interface")).FirstOrDefault();
            if(_filterType == null)
            {
                return Json(false);
            }
            for (int i = 0; i < filter.Count; i++)
            {
                filter[i].CreatedById = Convert.ToInt32( _userCode.Value);
                filter[i].CreatedDate = DateTime.Now;
                filter[i].FilterTypeID = _filterType.FilterTypeID;
                filter[i].FilterID = 0;
            }
            _uow.Repository<Filter>().AddRange(filter);
            _uow.Save();
            return Json(true);
        }
        [AuthorizationFilterFactory(InterfaceName = "User", EventAccess = "AllowView")]
        [HttpGet("GetUserFilter", Name = "GetUserFilter")]
        public IActionResult GetUserFilter(int UserID,int FilterTypeID)
        {
            var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
            var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
            //var _userFilterDetail = _uow.Repository<Filter>().Get(x=>x.IsDeleted == false && x.FilterTypeID == FilterTypeID).ToList();
            var _dataset = DbAccess.ExecuteSP(DbAccess.DBPortal, "GetFilterByFilterTypeID", new Dictionary<string, System.Data.SqlClient.SqlParameter>(){
                { "ConfigID",new System.Data.SqlClient.SqlParameter{ ParameterName = "ConfigID" , Value = Convert.ToInt32(_configId.Value)} },
                { "FilterTypeID",new System.Data.SqlClient.SqlParameter{ ParameterName = "FilterTypeID" , Value = FilterTypeID } },
                { "UserID",new System.Data.SqlClient.SqlParameter { ParameterName = "UserID", Value = UserID } }
                });
            var _filters = _dataset.Tables[0].ToJson();
            var _userFilterDetail = _dataset.Tables[1].ToJson();
            return Json(new { UserFilterDetail = _userFilterDetail, Filters = _filters });
        }
        
         [HttpPost("CreateUserFilter", Name = "CreateUserFilter")]
        [AuthorizationFilterFactory(InterfaceName = "Filter", EventAccess = "AllowAdd")]
        public ActionResult CreateUserFilter([FromBody]List<Filter> filter)
        {
            var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
            var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
            //List<UserAccessDetail> _userAccessDetail = Mapper.Map<List<UserAccessDetailModel>, List<UserAccessDetail>>(userAccessDetailModel);
            //var _filters = _uow.Repository<Filter>().Get(ft => ft.IsDeleted == false && ft.FilterTypeID == filter[0].FilterTypeID && ft.UserID == filter[0].UserID).Select(x=>x.FilterTypeValue).ToList();
            //if (_filters == null)
            //{
            //    return Json(false);
            //}
            for (int i = 0; i < filter.Count; i++)
            {
                filter[i].CreatedById = Convert.ToInt32(_userCode.Value);
                filter[i].CreatedDate = DateTime.Now;
            }
            //var _filters = new List<Filter>();
            //for (int i = 0; i < filter.Count; i++)
            //{
            //    var _filter = filter.FirstOrDefault(x => _filters.Contains(x.FilterTypeValue));
            //    if(_filter != null)
            //    {
            //        filter.Remove(_filter);
            //    }
            //}
            DbAccess.ExecuteQuery(DbAccess.DBPortal, "delete from filter where filtertypeid =" + filter[0].FilterTypeID + " and userid = " + filter[0].UserID, new Dictionary<string, System.Data.SqlClient.SqlParameter>());
            _uow.Save();
            _uow.Repository<Filter>().AddRange(filter);
            _uow.Save();
            return Json(true);
        }
       
    }

}