using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GwDealerPortal.Model;
using GwDealerPortal.DataAccess.Interfaces;
using Microsoft.AspNetCore.Cors;
using GwDealerPortal.DataAccess.Entities;
using System.Globalization;
using Newtonsoft.Json.Converters;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using GwDealerPortal.Service.Common;
using GwDealerPortal.DataAccess;
using System.Data;
using System.IO;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Hosting;
using System.Text;

namespace GwDealerPortal.Service.Controllers
{
    [EnableCors("AllowAllHeaders")]
    //[Produces("application/json")]
    [Route("api/policy")]
    public class PolicyController : BaseController
    {
        private IHostingEnvironment _env;
        private IUnitOfWork _uow;
        public PolicyController(IUnitOfWork uow, IHostingEnvironment env) : base(env)
        {
            _uow = uow;
            _env = env;
        }



        //[Authorize]
        // [HttpPost]
        //[HttpPost("Add", Name = "Add")]
        //// GET: Policy/Create
        //public JsonResult Create([FromBody]BWDealerPolicy policy)
        //{
        //    //var format = "yyyy/MM/dd"; // your datetime format
        //    //var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
        //    try
        //    {
        //        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        //        {
        //            DateParseHandling = DateParseHandling.None
        //        };
        //        var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
        //        var _userCode =  Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
        //        //BWDealerPolicy policy = JsonConvert.DeserializeObject<BWDealerPolicy>(System.Uri.UnescapeDataString(model));
        //        //DateTime dt = DateTime.Now;
        //        //List<int> _error = new List<int>();
        //        //bool _extStartDate, _extEndDate, _manuStartDate, _manuEndDate, _invoiceDate;
        //        //_extStartDate = DateTime.TryParse(policy.ExtendedWarrantyStartDate.ToString(), out dt);
        //        //_extEndDate = DateTime.TryParse(policy.ExtendedWarrantyEndDate.ToString(),  out dt);
        //        //_manuStartDate = DateTime.TryParse(policy.ManufacturerWarrantyStartDate.ToString(), out dt);
        //        //_manuEndDate = DateTime.TryParse(policy.ManufacturerWarrantyEndDate.ToString(), out dt);
        //        //_invoiceDate = DateTime.TryParse(policy.InvoiceDate.ToString(), out dt);

        //        //if(!_extStartDate)
        //        //{
        //        //    _error.Add(701);
        //        //}
        //        //if (!_extEndDate)
        //        //{
        //        //    _error.Add(702);
        //        //}
        //        //if (!_manuStartDate)
        //        //{
        //        //    _error.Add(703);
        //        //}
        //        //if (!_manuEndDate)
        //        //{
        //        //    _error.Add(704);
        //        //}
        //        //if (!_invoiceDate)
        //        //{
        //        //    _error.Add(705);
        //        //}
        //        //if(_error.Count == 0)
        //        //{
        //        //policy.ExtendedWarrantyEndDate = DateTime.ParseExact(policy.ExtendedWarrantyEndDate.ToString("yyyy/MM/dd"), "yyyy/MM/dd", CultureInfo.InvariantCulture);
        //        //policy.ExtendedWarrantyStartDate = DateTime.ParseExact(policy.ExtendedWarrantyEndDate.ToString("yyyy/MM/dd"), "yyyy/MM/dd", CultureInfo.InvariantCulture);
        //        //policy.InvoiceDate = DateTime.ParseExact(policy.ExtendedWarrantyEndDate.ToString("yyyy/MM/dd"), "yyyy/MM/dd", CultureInfo.InvariantCulture);
        //        //policy.ManufacturerWarrantyEndDate = DateTime.ParseExact(policy.ExtendedWarrantyEndDate.ToString("yyyy/MM/dd"), "yyyy/MM/dd", CultureInfo.InvariantCulture);
        //        //policy.ManufacturerWarrantyStartDate = DateTime.ParseExact(policy.ExtendedWarrantyEndDate.ToString("yyyy/MM/dd"), "yyyy/MM/dd", CultureInfo.InvariantCulture);
        //        policy.CreatedDate = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));
        //        policy.CreatedById = Convert.ToInt32(_userCode.Value);
        //        _uow.Repository<BWDealerPolicy>().Insert(policy);
        //        _uow.Save();
        //        return Json("success");
        //        //}
        //        //else
        //        //{
        //        //    return Json(_error);
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(ex.Message);
        //    }

        //}

        
        [AuthorizationFilterFactory(InterfaceName = "Policy", EventAccess = "AllowView")]
        [HttpGet("GetPolicyByCriteria", Name = "GetPolicyByCriteria")]
        public IActionResult GetPolicyByCriteria(int PolicyCode, string ChasisNo = "")
        {
            try
            {
                dynamic _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
                var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
                var _userID = Convert.ToInt32(_userCode.Value);
                if (!string.IsNullOrEmpty(_configId.Value))
                {
                    System.Linq.Expressions.Expression<Func<Policy, bool>> expression = (p) => (p.IsDeleted == false) && (p.SINum == PolicyCode);
                    if (!string.IsNullOrEmpty(ChasisNo))
                    {
                        expression = (p) => (p.IsDeleted == false) && (p.SINum == PolicyCode || p.UINumber.Contains(ChasisNo));
                    }

                    _configId = Convert.ToInt32(_configId.Value);
                    var _policy = _uow.Repository<Policy>().Get(expression).FirstOrDefault();
                    var _isEmail = false;
                    var _emailFilter = _uow.Repository<Filter>().Get(x=>x.FilterTypeID == Startup.EmailFilterTypeID && x.UserID == _userID).FirstOrDefault();
                    if(_emailFilter != null)
                    {
                        _isEmail = true;
                    }
                    var _path = "";
                    FileInfo[] filesInDir = new FileInfo[0];// directoryInfo.GetFiles((_policy.PolNumber) + "-*.*");
                    //_path = System.IO.Directory.GetCurrentDirectory();

                    string webRootPath = _env.WebRootPath;
                    _path = _env.ContentRootPath;
                    //_path = _path.Substring(0, _path.LastIndexOf('\\'));
                    _path += @"\wwwroot\Content\PolicyForms\";
                    DirectoryInfo directoryInfo = new DirectoryInfo(_path);
                    filesInDir = directoryInfo.GetFiles((_policy.PolNumber) + "-*.*");

                    var _policyServices = _uow.Repository<PolicyService>().Get(x => x.PolicyID == _policy.SINum);
                    //foreach (FileInfo foundFile in filesInDir)
                    //{
                    //    string fullName = foundFile.FullName;
                    //    Console.WriteLine(fullName);
                    //}
                    //Newtonsoft.Json.Serialization.DefaultContractResolver contractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver
                    //{
                    //    NamingStrategy = new Newtonsoft.Json.Serialization.CamelCaseNamingStrategy()
                    //};

                    //string json = JsonConvert.SerializeObject(_policy, new JsonSerializerSettings
                    //{
                    //    ContractResolver = contractResolver,
                    //    Formatting = Formatting.Indented
                    //});
                    var policyString = JsonConvert.SerializeObject(_policy);
                    var otherServicesString = "";
                    if (_policyServices != null)
                    {
                        if (_policyServices.Count > 0)
                        {
                            var _policyServiceIDs = _policyServices.Select(p => p.OtherServiceID).ToArray();
                            var _otherServices = _uow.Repository<OtherService>().Get(x => _policyServiceIDs.Contains(x.OtherServiceID));
                            otherServicesString = JsonConvert.SerializeObject(_otherServices);
                        }
                    }
                    return Json(new { Policy = policyString, Files = filesInDir.Select(f => new { path = f.FullName, name = f.Name }), OtherServices = otherServicesString,IsEmail = _isEmail });
                }

            }
            catch (Exception ex)
            {
                return Json(new { Error = ex.Message });
            }
            return null;
        }


        // POST: Policy/Create

        // [ValidateAntiForgeryToken]
        [AuthorizationFilterFactory(InterfaceName = "Policy", EventAccess = "AllowAdd")]
        [HttpPost("Add", Name = "Add")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult> Add([FromForm] string policymodel, string otherservicesmodel = "")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Function Started");
            try
            {
                sb.Append("Before policy deserialize");
                Policy policy = Newtonsoft.Json.JsonConvert.DeserializeObject<Policy>(System.Uri.UnescapeDataString(policymodel));
                sb.Append("After policy deserialize");
                // Policy policy = Newtonsoft.Json.JsonConvert.DeserializeObject<Policy>(System.Uri.UnescapeDataString(policymodel));

                List<PolicyService> policyServices = null;
                if (!string.IsNullOrEmpty(otherservicesmodel))
                {
                    sb.Append("Before policy service");
                    policyServices = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PolicyService>>(System.Uri.UnescapeDataString(otherservicesmodel));
                    sb.Append("After policy service");
                }
                var _configId =  Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
                var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
                sb.Append("after getting usercode");
                // TODO: Add insert logic here
                await CreateFilesAsync("PolicyForms", Request.Form.Files, policy.PolNumber);
                sb.Append("after adding files");
                policy.ConfigID = Convert.ToInt32(_configId.Value);
                if (policy.SINum > 0)
                {
                    policy.UpdatedDate = DateTime.Now;
                    //policy.UpdatedDate = DateTime.ParseExact(DateTime.Now.ToString(), "dd/MM/yyyy", null); 
                    policy.UpdatedById = Convert.ToInt32(_userCode.Value);
                    _uow.Repository<Policy>().Update(policy);
                    sb.Append("after updating policy");
                }
                else
                {
                    var _policyno = _uow.Repository<Policy>().Get(x => x.ConfigID == policy.ConfigID).Max(x => x.PolNumber);
                    if (_policyno != null)
                    {
                        policy.PolNumber = _policyno + 1;
                    }
                    policy.CreatedDate = DateTime.Now;
                    //policy.CreatedDate = DateTime.ParseExact(DateTime.Now.ToString(), "dd/MM/yyyy", null);
                    policy.CreatedById = Convert.ToInt32(_userCode.Value);
                    //policy.ApprovalDate = DateTime.Now;
                    //policy.Description = "";
                    //policy.RefNumber = "";
                    _uow.Repository<Policy>().Insert(policy);
                }
                _uow.Save();
                var result = DbAccess.ExecuteQuery(DbAccess.DBPortal, "delete from policyservice where policyid=" + policy.SINum, new Dictionary<string, System.Data.SqlClient.SqlParameter>() { });
                _uow.Save();
                if (policyServices != null)
                {
                    for (int i = 0; i < policyServices.Count; i++)
                    {
                        policyServices[i].PolicyID = policy.SINum;
                    }
                    _uow.Repository<PolicyService>().AddRange(policyServices);
                    _uow.Save();
                }
                return Json("success");
            }
            catch (ValidationException ex)
            {
                return Json(new { error = ex.Message, stacktrace = ex.StackTrace, inner = ex.InnerException, logs = sb.ToString() });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message, stacktrace = ex.StackTrace, inner = ex.InnerException, logs = sb.ToString() });
            }
        }

        [AuthorizationFilterFactory(InterfaceName = "Policy", EventAccess = "AllowEdit")]
        [HttpPost("Edit", Name = "Edit")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult> Edit([FromForm] string policymodel, string otherservicesmodel)
        {
            return await Add(policymodel, otherservicesmodel);
        }
        [AuthorizationFilterFactory(InterfaceName = "Policy", EventAccess = "AllowView")]
        [HttpGet("GetPremium", Name = "GetPremium")]
        public IActionResult GetPremium()
        {
            try
            {
                var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
                var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();

                var _query = "PR_WEMSPORTAL.dbo.fn_premium_getbypolicy";
                var result = DbAccess.ExecuteSP(DbAccess.DBPortal, _query, new Dictionary<string, System.Data.SqlClient.SqlParameter>()
                {{ "@UserID",new System.Data.SqlClient.SqlParameter {ParameterName = "UserID",DbType = System.Data.DbType.Int32 , Value = Convert.ToInt32( _userCode.Value)} }
                });
                DataTable table = result.Tables[0];
                //var _policies = _uow.Repository<Policy>().Get().ToList();
                //    return Json(_policies);
                return Json(table.ToJson());
            }
            catch (ValidationException ex)
            {
                return Json(new { error = ex.Message, stacktrace = ex.StackTrace, inner = ex.InnerException });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message, stacktrace = ex.StackTrace, inner = ex.InnerException });
            }
            //return null;
        }
        [AuthorizationFilterFactory(InterfaceName = "Policy", EventAccess = "AllowView")]
        [HttpGet("GetAllPolicies", Name = "GetAllPolicies")]
        public IActionResult GetAllPolicies()
        {
            try{ 

                var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
                var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();

                var _query = "PR_WEMSPORTAL.dbo.policies_all";
                var result = DbAccess.ExecuteSP(DbAccess.DBPortal, _query, new Dictionary<string, System.Data.SqlClient.SqlParameter>()
                {{ "@UserID",new System.Data.SqlClient.SqlParameter {ParameterName = "UserID",DbType = System.Data.DbType.Int32 , Value = Convert.ToInt32( _userCode.Value)} }
                });
                DataTable table = result.Tables[0];
                //var _policies = _uow.Repository<Policy>().Get().ToList();
                //    return Json(_policies);
                return Json(table.ToJson());
            }
            catch (ValidationException ex)
            {
                return Json(new { error = ex.Message, stacktrace = ex.StackTrace, inner = ex.InnerException });
            }
            catch (Exception ex)
            {

                return Json(new { error = ex.Message, stacktrace = ex.StackTrace, inner = ex.InnerException });
            }
            //return null;
        }
        [AuthorizationFilterFactory(InterfaceName = "Policy", EventAccess = "AllowView")]
        [HttpGet("GetDropdownsData", Name = "GetDropdownsData")]
        public IActionResult GetDropdownsData(bool isAllPolicy = false,bool isReport = false)
        {
            try
            {
            var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
            var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();

            var _query = "PR_WEMSPORTAL.dbo.gethomedataForVehicle";
            var ds = DbAccess.ExecuteSP(DbAccess.DBPortal, _query, new Dictionary<string, System.Data.SqlClient.SqlParameter>()
            { { "@ConfigID",new System.Data.SqlClient.SqlParameter { ParameterName = "ConfigID" ,DbType = System.Data.DbType.Int32 , Value = Convert.ToInt32( _configId.Value)} },
             { "@UserID",new System.Data.SqlClient.SqlParameter {ParameterName = "UserID",DbType = System.Data.DbType.Int32 , Value = Convert.ToInt32( _userCode.Value)} },
             { "@isAllPolicy",new System.Data.SqlClient.SqlParameter { ParameterName = "IsAllPolicy" ,DbType = System.Data.DbType.Boolean , Value = isAllPolicy} },
             { "@IsReport",new System.Data.SqlClient.SqlParameter { ParameterName = "IsReport" ,DbType = System.Data.DbType.Boolean , Value = isReport} }
            });
            var tableNames = new List<string>();
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                if (ds.Tables[i].Rows.Count > 0)
                {
                    tableNames.Add(ds.Tables[i].Rows[0][0].ToString());
                }
                else
                {
                    tableNames.Add("-");
                }
            }
            var _makes = new DataTable().ToJson();
            if (tableNames.IndexOf("Make") > -1)
            {
                _makes = ds.Tables[tableNames.IndexOf("Make")].ToJson();
            }
            var _models = new DataTable().ToJson();
            if (tableNames.IndexOf("Model") > -1)
            {
                _models = ds.Tables[tableNames.IndexOf("Model")].ToJson();
            }
            var _modelYears = new DataTable().ToJson();
            if (tableNames.IndexOf("ModelYear") > -1)
            {
                _modelYears = ds.Tables[tableNames.IndexOf("ModelYear")].ToJson();
            }
            var _categories = new DataTable().ToJson();
            if (tableNames.IndexOf("Category") > -1)
            {
                _categories = ds.Tables[tableNames.IndexOf("Category")].ToJson();
            }
            var _productGroups = new DataTable().ToJson();
            if (tableNames.IndexOf("ProductGroup") > -1)
            {
                 _productGroups = ds.Tables[tableNames.IndexOf("ProductGroup")].ToJson();
            }
            var _productSubGroups = new DataTable().ToJson();
            if (tableNames.IndexOf("ProductSubGroup") > -1)
            {
                _productSubGroups = ds.Tables[tableNames.IndexOf("ProductSubGroup")].ToJson();
            }
            var _ccRanges = new DataTable().ToJson();
            if (tableNames.IndexOf("CCRange") > -1)
            {
                _ccRanges = ds.Tables[tableNames.IndexOf("CCRange")].ToJson();
            }
            var _dealers = new DataTable().ToJson();
            if (tableNames.IndexOf("Dealer") > -1)
            {
                _dealers = ds.Tables[tableNames.IndexOf("Dealer")].ToJson();
            }
            var _dealerBranches = new DataTable().ToJson();
            if (tableNames.IndexOf("DealerBranch") > -1)
            {
                _dealerBranches = ds.Tables[tableNames.IndexOf("DealerBranch")].ToJson();
            }
            var _warrantyTypes = new DataTable().ToJson();
            if (tableNames.IndexOf("WarrantyType") > -1)
            {
                _warrantyTypes = ds.Tables[tableNames.IndexOf("WarrantyType")].ToJson();
            }
            var _otherServices = new DataTable().ToJson();
            if (tableNames.IndexOf("OtherService") > -1)
            {
                _otherServices = ds.Tables[tableNames.IndexOf("OtherService")].ToJson();
            }
            var _printFilters = new DataTable().ToJson();
            if (tableNames.IndexOf("PrintFilter") > -1)
            {
                _printFilters = ds.Tables[tableNames.IndexOf("PrintFilter")].ToJson();
            }
            var _entryEligibilities = new DataTable().ToJson();
            if (tableNames.IndexOf("EntryEligibility") > -1)
            {
                _entryEligibilities = ds.Tables[tableNames.IndexOf("EntryEligibility")].ToJson();
            }
            var _durations = new DataTable().ToJson();
            if (tableNames.IndexOf("Duration") > -1)
            {
                _durations = ds.Tables[tableNames.IndexOf("Duration")].ToJson();
            }
            var _claimLimits = new DataTable().ToJson();
            if (tableNames.IndexOf("ClaimLimit") > -1)
            {
                _claimLimits = ds.Tables[tableNames.IndexOf("ClaimLimit")].ToJson();
            }
            var _users = new DataTable().ToJson();
            if (tableNames.IndexOf("User") > -1)
            {
                _users = ds.Tables[tableNames.IndexOf("User")].ToJson();
            }
            return Json(new { Makes = _makes, Models = _models, ModelYears = _modelYears, Categories = _categories, ProductGroups = _productGroups, ProductSubGroups = _productSubGroups, CCRanges = _ccRanges, Dealers = _dealers, DealerBranches = _dealerBranches, WarrantyTypes = _warrantyTypes, OtherService = _otherServices, PrintFilters = _printFilters, Durations = _durations, EntryEligibilities = _entryEligibilities, ClaimLimits = _claimLimits,Users = _users });
                //return null;
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.ToString() });
            }
        }
        [AuthorizationFilterFactory(InterfaceName = "Policy", EventAccess = "AllowView")]
        [HttpGet("GetNextPolicyNumber", Name = "GetNextPolicyNumber")]
        public IActionResult GetNextPolicyNumber()
        {
            var _configId = Convert.ToInt32(Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault().Value);
            var _userCode = 151;// Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
            var _policyno = _uow.Repository<Policy>().Get(x => x.ConfigID == _configId).Max(x=>x.PolNumber);
            var _policyNumber = 0;
            if (_policyno != null)
            {
                _policyNumber = _policyno + 1;
            }
            return Json(new { PolicyNumber = _policyNumber });
            //return null;
        }
        [AuthorizationFilterFactory(InterfaceName = "Policy", EventAccess = "AllowDelete")]
        [HttpPost("DeletePolicyFile", Name = "DeletePolicyFile")]
        public IActionResult DeletePolicyFile(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                var _path = _env.ContentRootPath;
                _path += @"\wwwroot\Content\PolicyForms\";
                DirectoryInfo directoryInfo = new DirectoryInfo(_path);
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    if (file.Name == fileName)
                    {
                        file.Delete();
                        return Json(true);
                    }
                }
            }
            return null;
        }
        [AuthorizationFilterFactory(InterfaceName = "Policy", EventAccess = "AllowEdit")]
        [HttpPost("SendEmail", Name = "SendEmail")]
        public IActionResult SendEmail(string policystring,string reportpath)
        {
            try{
                if (policystring != null)
                {
                    Policy policy = Newtonsoft.Json.JsonConvert.DeserializeObject<Policy>(System.Uri.UnescapeDataString(policystring));
                    var _body = _uow.Repository<PolicyStatus>().Get(x => x.StatusID == policy.Status).FirstOrDefault().EmailText;
                    Utilities.SendEmail("Your Policy Details",
                    //"Dear Customer,<br>Good Day,<br><br> This is to inform you that your policy has been registered with us and the current status of your policy is #status#. To view your certificate please click on the below link.<br> Thank you for choosing our service"+

                    _body + "<br><br> <a href='" + reportpath + "?name=pc82_" + policy.ProductSubGroupId + "&invoicenumber=" + policy.PolNumber + "'>View Service Contract</a>",
                    Startup.Email, Startup.Password, policy.Email);
                }
                return Json(true) ;
            }
            catch(Exception ex)
            {

            }
            
            return null;
        }
    }
}