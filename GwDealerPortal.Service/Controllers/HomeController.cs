using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GwDealerPortal.DataAccess.Interfaces;
using GwDealerPortal.DataAccess.Entities;
using System.Data;
using GwDealerPortal.DataAccess;
using GwDealerPortal.Service.Common;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;

namespace GwDealerPortal.Service.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Home")]
    public class HomeController : Controller
    {
       
 
        public HomeController()
        {
        }
       // [Authorize]
        [HttpGet("GetDashboardData", Name = "GetDashboardData")]
        public IActionResult GetDashboardData(int RoleID)
        {
            var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
            var _userCode = 151;// Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
            //var _claimStatus = _claimStatusRepository.Get();
            //var _pendingClaimStatus = _claimStatus.Where(cs => cs.)
            //var _yearPolicies = _policyRepository.Get(pc=> pc.IssueDate > new DateTime(DateTime.Now.Year,1,1) && pc.IsDeleted == false);
            //var _yearClaims = _processClaimRepository.Get(pc => pc.ClaimDate > new DateTime(DateTime.Now.Year, 1, 1) && pc.IsDeleted == false);
            //var _currentMonthPoliciesCount = _yearPolicies.Where(p => p.IssueDate.Value.Month == DateTime.Now.Month).Count();
            //var _currentMonthClaims = _processClaimRepository.Get(p => p.ClaimDate.Value.Month == DateTime.Now.Month && p.IsDeleted == false);
            //var _currentMonthClaimsCount = _currentMonthClaims.Count();
            //var _currentMonthPendingClaims = _currentMonthClaims.Where(c => c.Status == 5);
            //var _currentMonthRejectedClaims = _currentMonthClaims.Where(c => c.Status == 3);

            //var _currentYearPolicies = Enumerable.Range(1, 12)
            //.Select(x => new { Month = x , Policies = _yearPolicies.Where(p => p.IssueDate.Value.Month == x).Count() }).ToList();
            //var _currentYearClaims = Enumerable.Range(1, 12)
            //.Select(x => new { Month = x, Claims = _yearClaims.Where(p => p.ClaimDate.Value.Month == x).Count() }).ToList();
            //var _currentYearModels = _currentYearPolicies;
            //var _currentYearFaults = _currentYearPolicies;
            var _lastYearDate = new DateTime(DateTime.Now.AddYears(-1).Year, DateTime.Now.AddMonths(1).Month, 1);
            var _query = "Select * from  PR_WEMS.dbo.vw_policyInfo_NissanPortal where dealercode in (select dealercode from WEMS_UserDealerFilter where usercode = '" + _userCode + "') and invoicedate >= '"+  _lastYearDate +"' and configid=" + _configId.Value + " ";
            _query += " SELECT * FROM dbo.Claims_CurrentStatus_Final WHERE FaxReceivedDate >= '" + _lastYearDate + "' and configid=" + _configId.Value + "";
            _query += " Select top 10 * from  PR_WEMS.dbo.vw_Claimsinfo_MostBurningMake_Final_NissanPortal where configid=" + _configId.Value;
            _query += " Select top 5 * from  PR_WEMS.dbo.vw_ClaimsInfo_MostBurningParts_NissanPortal where configid=" + _configId.Value;
            _query += " UNION Select top 5 * from  PR_WEMS.dbo.vw_ClaimsInfo_MostBurningParts_NissanPortal where configid=" + _configId.Value;
            var result = DbAccess.ExecuteQuery(DbAccess.DbWems, _query, new Dictionary<string, System.Data.SqlClient.SqlParameter>());
            var policies = result.Tables[0].ToJson();//.ToList<Policy>();
            var claims = result.Tables[1].ToJson();//.ToList<ProcessClaim>();
            var models = result.Tables[2].ToJson();
            var faults = result.Tables[3].ToJson();
            
            var _yearPolicies = policies;
            var _yearClaims = claims;
            var _currentMonthPoliciesCount = _yearPolicies.Where(p => p.Value<DateTime>("InvoiceDate").Month == DateTime.Now.Month).Count();
            var _currentMonthClaims = _yearClaims.Where(p => p.Value<DateTime>("FaxReceivedDate").Month == DateTime.Now.Month);
            var _currentMonthClaimsCount = _currentMonthClaims.Count();
            var _currentMonthPendingClaimsCount = _currentMonthClaims.Where(c => c.Value<int>("ClaimStatus") == 5).Count();
            var _currentMonthRejectedClaimsCount = _currentMonthClaims.Where(c => c.Value<int>("ClaimStatus") == 3).Count();

            var _currentYearPolicies = Enumerable.Range(1, 12)
            .Select(x => new { 
            Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(_lastYearDate.AddMonths(x - 1).Month), 
            Policies = _yearPolicies.Count(p => p.Value<DateTime>("InvoiceDate").Month == _lastYearDate.AddMonths(x - 1).Month)
            }).ToList();
            var _currentYearClaims = Enumerable.Range(1, 12)
            .Select(x => new { 
            Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(_lastYearDate.AddMonths(x - 1).Month),
            Claims = _yearClaims.Count(p => p.Value<DateTime>("FaxReceivedDate").Month == _lastYearDate.AddMonths(x - 1).Month) }).ToList();
            var _currentYearModels = models;
            var _currentYearFaults = faults;




            return Json(new {
                    CurrentYearPolicies = _currentYearPolicies,
                    CurrentYearClaims = _currentYearClaims,
                    CurrentYearModels = _currentYearModels,
                    CurrentYearFaults = _currentYearFaults,
                    CurrentMonthPolicies = _currentMonthPoliciesCount,
                    CurrentMonthClaims = _currentMonthClaimsCount,
                    CurrentMonthPendingClaims = _currentMonthPendingClaimsCount,
                    CurrentMonthRejectedClaims = _currentMonthRejectedClaimsCount
            });
           // return null;
        }
    }
}