using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GwDealerPortal.Service.Common
{
    public static class CurrentUser
    {

        
        //public static int UserId
        //{
        //    get
        //    {
        //        var userId = 0;
        //        if (!string.IsNullOrEmpty(System.Web HttpContext.Current.User.Identity.Name))
        //        {
        //            userId = Convert.ToInt32(HttpContext.Current.User.Identity.Name.Split('|')[0]);
        //        }
        //        return userId;
        //    }
        //}
        //public static string UserName
        //{
        //    get
        //    {
        //        var userName = "";
        //        if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
        //        {
        //            userName = HttpContext.Current.User.Identity.Name.Split('|')[1];
        //        }
        //        return userName;
        //    }
        //}
        //public static int UserRoleId
        //{
        //    get
        //    {
        //        var userRoleId = 0;
        //        if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
        //        {
        //            userRoleId = Convert.ToInt32(HttpContext.Current.User.Identity.Name.Split('|')[2]);
        //        }
        //        return userRoleId;
        //    }
        //}
        ////public static List<UserAccessDetailModel> UserAccess
        ////{
        ////    get
        ////    {
        ////        var userAccess = new List<UserAccessDetailModel>();
        ////        if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
        ////        {
        ////            userAccess = JsonConvert.DeserializeObject<List<UserAccessDetailModel>>( HttpContext.Current.User.Identity.Name.Split('|')[3]);
        ////        }
        ////        return userAccess;
        ////    }
        ////}
        //public static int EmployeeId
        //{
        //    get
        //    {
        //        var employeeId = 0;
        //        if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
        //        {
        //            employeeId = Convert.ToInt32(HttpContext.Current.User.Identity.Name.Split('|')[3]);
        //        }
        //        return employeeId;
        //    }
        //}
        //public static string Image
        //{
        //    get
        //    {
        //        var image = "";
        //        if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
        //        {
        //            image = HttpContext.Current.User.Identity.Name.Split('|')[4];
        //        }
        //        return image;
        //    }
        //}
        //public static string UserRoleName
        //{
        //    get
        //    {
        //        var userRoleName = "";
        //        if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
        //        {
        //            userRoleName = HttpContext.Current.User.Identity.Name.Split('|')[5];
        //        }
        //        return userRoleName;
        //    }
        //}
        //public static int ReportingToID
        //{
        //    get
        //    {
        //        var reportingToID = 0;
        //        if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
        //        {
        //            reportingToID = Convert.ToInt32(HttpContext.Current.User.Identity.Name.Split('|')[6]);
        //        }
        //        return reportingToID;
        //    }
        //}
    }
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
                                  JsonConvert.DeserializeObject<T>(value);
        }
    }
    public class SessionUtility
    {
        public static IHttpContextAccessor HttpContextAccessor;

        public SessionUtility(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public static void SetSession(string key, object value)
        {
            HttpContextAccessor.HttpContext.Session.Set(key, value);
        }

        public static object GetSession(string key)
        {
            return HttpContextAccessor.HttpContext.Session.Get(key);
        }
    }
}
