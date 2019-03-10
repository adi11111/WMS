using GwDealerPortal.DataAccess;
using GwDealerPortal.DataAccess.Entities;
using GwDealerPortal.DataAccess.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace GwDealerPortal.Service.Common
{
    public class AuthorizationFilter : ActionFilterAttribute //, System.Web.Http.Filters.IAuthenticationFilter
    {
        private const int DefaultMaxRequestPerSecond = 3;
        private readonly IHttpContextAccessor _accessor;
        public int MaxRequestPerSecond { get; set; } = DefaultMaxRequestPerSecond;
        //public AuthorizationFilter(IHttpContextAccessor accessor)
        //{
        //    _accessor = accessor;
        //}
        public IUnitOfWork _uow;
        //public AuthorizationFilter()
        //{
        //}
        public AuthorizationFilter(IUnitOfWork _uow)
        {
            this._uow = _uow;
        }
        public string InterfaceName { get; set; }
        public string EventAccess { get; set; }
        public int RoleCode { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
        try{ 
            //var _interfaceName = InterfaceName;
            //var _eventAccess = EventAccess;
            //var _eventAccess = _uow.Repository<EventAccess>().Get();
            var _roleId = context.HttpContext.Request.Headers.Where(x => x.Key.ToLower() == "roleid").FirstOrDefault();
            var _userCode = context.HttpContext.Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
            // var _filters = _uow.Repository<Filter>().Get(f => f.IsDeleted == false);
            var _adminUserIDs = Startup.adminUserIDs.Split(',').ToList();
            if (!_adminUserIDs.Contains(_userCode.Value))
            {
                var _dataset = DbAccess.ExecuteSP(DbAccess.DBPortal, "filter_GetByRoleID", new Dictionary<string, System.Data.SqlClient.SqlParameter>(){
                { "RoleID",new System.Data.SqlClient.SqlParameter { ParameterName = "RoleID", Value = Convert.ToInt32( _roleId.Value)} },
                { "EventAccessName",new System.Data.SqlClient.SqlParameter { ParameterName = "EventAccessName", Value = EventAccess } },
                { "InterfaceName",new System.Data.SqlClient.SqlParameter { ParameterName = "InterfaceName", Value = InterfaceName} }
                });
                //var _eventAccess = _dataset.Tables[0].ToJson();
                if (_dataset != null)
                {
                    var _filterss = _dataset.Tables[0];//.ToJson();
                    if (_filterss.Rows.Count == 0)
                    {
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
            }
            catch (Exception ex)
            {
                context.Result = new BadRequestResult();
                throw;
            }
            //var _filters = _accessor.HttpContext.Session.Get<Filter>("Filter");
            //var aa = context.HttpContext.Session.Get<Filter>("Filters");
            //var aaa = HttpContext.Session.Get<Filter>("Filters");
            //var aaaa = Utilities.Filters;
            //context.Result = new ContentResult()
            //{
            //    Content = "Short circuit filter"
            //};
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }
        //void IAuthenticationFilter.OnAuthentication(AuthenticationContext filterContext)
        //{

        //    //var Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
        //    //var Action = filterContext.ActionDescriptor.ActionName;
        //    //var User = filterContext.HttpContext.User;
        //    //var IP = filterContext.HttpContext.Request.UserHostAddress;
        //    if ("AdminRole".GetConfigByKey<int>() != CurrentUser.UserRoleId)
        //    {
        //        //var _interfaces = InterfaceName.Split(',');
        //        //for (int i = 0; i <  _interfaces.Count(); i++)
        //        //{
        //        var _userAccess = Utilities.UserAccess.Where(ua => ua.EventAccess == EventAccess.GetConfigByKey<int>() && ua.InterfaceID == Utilities.GetInterfaceIdByName(InterfaceName) && ua.UserRoleID == CurrentUser.UserRoleId).FirstOrDefault();
        //        if (_userAccess == null)
        //        {

        //            filterContext.HttpContext.Response.StatusCode = 403;
        //            filterContext.Result = new EmptyResult();
        //        }
        //        //}

        //    }

        //    // throw new NotImplementedException();
        //}

        //void IAuthenticationFilter.OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        //{
        //    if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
        //    {
        //        filterContext.Result = new RedirectToRouteResult("Default",
        //        new System.Web.Routing.RouteValueDictionary{
        //        {"controller", "Account"},
        //        {"action", "Login"},
        //        {"returnUrl", filterContext.HttpContext.Request.RawUrl}
        //        });
        //    }
        //}
    }

    public class AuthorizationFilterFactory : Attribute, IFilterFactory
    {
        public string InterfaceName { get; set; }
        public string EventAccess { get; set; }
        public int MaxRequestPerSecond { get; set; }

        public bool IsReusable => false;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var filter = serviceProvider.GetService<AuthorizationFilter>();

            //if (MaxRequestPerSecond > 0)
            //{
                filter.MaxRequestPerSecond = MaxRequestPerSecond;
                filter.EventAccess = EventAccess;
                filter.InterfaceName = InterfaceName;
            //}

            return filter;
        }
    }
}
