using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using GwDealerPortal.DataAccess.Entities;
using GwDealerPortal.DataAccess.Interfaces;
using GwDealerPortal.Model;
using AutoMapper;
using System.Net.Http;
using System.Data;
using GwDealerPortal.DataAccess;
using GwDealerPortal.Service.Common;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;

namespace GwDealerPortal.Service.Controllers
{
    [Authorize]
    [EnableCors("AllowAllHeaders")]
    //[Produces("application/json")]
    [Route("api/Claim")]
    public class ClaimController : Controller
    {
        private IUnitOfWork _uow;
        public ClaimController(IUnitOfWork _uow)
        {
            this._uow = _uow;
        }
        [AuthorizationFilterFactory(InterfaceName = "Policy", EventAccess = "AllowView")]
        [HttpGet("GetPolicies", Name = "GetPolicies")]
        public IActionResult GetPolicies(string policyNumber, string slNumber = "", string clientRefNo = "")
        {
            var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
            var _userCode = 151;// Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
            if (!string.IsNullOrEmpty(policyNumber) || !string.IsNullOrEmpty(slNumber) || !string.IsNullOrEmpty(clientRefNo))
            {
                var _query = "Select * from  PR_WEMS.dbo.vw_policyInfo_NissanPortal where (policyno='" + policyNumber + "' or vino='" + slNumber + "' or clientrefno='" + clientRefNo + "') and configid=" + _configId.Value;
                var result = DbAccess.ExecuteQuery(DbAccess.DbWems, _query, new Dictionary<string, System.Data.SqlClient.SqlParameter>());
                DataTable table = result.Tables[0];
                return Json(table.ToJson());
            }
            return null;
        }
        [AuthorizationFilterFactory(InterfaceName = "Claim", EventAccess = "AllowView")]
        [HttpGet("GetClaimByPolicyNum", Name = "GetClaimByPolicyNum")]
        public IActionResult GetClaimByPolicyNum(string inputCode)
        {
            var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
            var _userCode = 151;// Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
            if (!string.IsNullOrEmpty(inputCode))
            {
                var _query = "Select * from  PR_WEMS.dbo.vw_ClaimsInfo_NissanPortal where inputcode=" + inputCode +
                " and configid=" + _configId.Value;
                //+ "' or vino='" + slNumber + "' or clientrefno='" + clientRefNo + "') and configid=" + _configId.Value;
                var result = DbAccess.ExecuteQuery(DbAccess.DbWems, _query, new Dictionary<string, System.Data.SqlClient.SqlParameter>());
                return Json(result.Tables[0].ToJson());
            }
            return null;
        }
        [AuthorizationFilterFactory(InterfaceName = "Claim", EventAccess = "AllowView")]
        [HttpGet("GetClaimDrpData", Name = "GetClaimDrpData")]
        public IActionResult GetClaimDrpData()
        {
            var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
            if (!string.IsNullOrEmpty(_configId.Value))
            {
                var result = DbAccess.ExecuteSP(DbAccess.DBPortal, "claims_getDrpData", new Dictionary<string, System.Data.SqlClient.SqlParameter>() {
                { "ConfigId",new System.Data.SqlClient.SqlParameter{ ParameterName = "ConfigId" , Value = Convert.ToInt32( _configId.Value) } }
                });
                dynamic _partsCategories = null;
                dynamic _parts = null;
                dynamic _claimBranches = null;
                dynamic _faults = null;
                dynamic _workshops = null;
                if (result != null)
                {
                    if(result.Tables.Count > 0)
                    {
                        for (int i = 0; i < result.Tables.Count; i++)
                        {
                            if(result.Tables[i].Rows.Count > 0)
                            {
                                if(result.Tables[i].Rows[0][0].ToString() == "PartsCategories")
                                {
                                    _partsCategories = result.Tables[i].ToJson();
                                }
                                else if (result.Tables[i].Rows[0][0].ToString() == "Parts")
                                {
                                    _parts = result.Tables[i].ToJson();
                                }
                                else if (result.Tables[i].Rows[0][0].ToString() == "ClaimBranches")
                                {
                                    _claimBranches = result.Tables[i].ToJson();
                                }
                                else if (result.Tables[i].Rows[0][0].ToString() == "Faults")
                                {
                                    _faults = result.Tables[i].ToJson();
                                }
                                else if (result.Tables[i].Rows[0][0].ToString() == "Workshops")
                                {
                                    _workshops = result.Tables[i].ToJson();
                                }
                            }
                        }
                    }
                }
                return Json(new { PartsCategories = _partsCategories , Parts = _parts , ClaimBranches = _claimBranches , Faults = _faults , Workshops = _workshops });
            }
            return null;
        }

        [AuthorizationFilterFactory(InterfaceName = "Claim", EventAccess = "AllowView")]
        [HttpGet("GetClaimByClaimCode", Name = "GetClaimByClaimCode")]
        public IActionResult GetClaimByClaimCode(int claimCode)
        {
            try
            {
                dynamic _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
                if (!string.IsNullOrEmpty(_configId.Value))
                {
                    _configId = Convert.ToInt32( _configId.Value);
                    //var result = DbAccess.ExecuteSP(DbAccess.DBPortal, "claims_getByClaimCode", new Dictionary<string, System.Data.SqlClient.SqlParameter>() {
                    //{ "ClaimCode",new System.Data.SqlClient.SqlParameter{ ParameterName = "ClaimCode" , Value = claimCode } }
                    //});
                    var result = DbAccess.ExecuteSP(DbAccess.DBPortal, "claim_UpdateStatus", new Dictionary<string, System.Data.SqlClient.SqlParameter>() { });
                    //var _processClaim = result.Tables[0].ToJson();
                    //var _processClaimDetails = result.Tables[1].ToJson();
                    var _processClaim = _uow.Repository<ProcessClaim>().Get(pc => (pc.IsDeleted == false) && pc.ClaimCode == claimCode).FirstOrDefault();

                    dynamic _processClaimDetails = _uow.Repository<ProcessClaimDetail>().Get(pc => (pc.IsDeleted == false) && pc.ClaimCode == claimCode);
                    var _query = "Select top 1 * from  PR_WEMS.dbo.vw_policyInfo_NissanPortal where inputcode=" + _processClaim.PolicyCode;
                    //+ "' or vino='" + slNumber + "' or clientrefno='" + clientRefNo + "') and configid=" + _configId.Value;
                    result = DbAccess.ExecuteQuery(DbAccess.DbWems, _query, new Dictionary<string, System.Data.SqlClient.SqlParameter>());
                    var _path = System.IO.Directory.GetCurrentDirectory();
                    _path = _path.Substring(0, _path.LastIndexOf('\\'));
                    _path += @"\GwDealerPortal\wwwroot\Content\ClaimForms\";

                DirectoryInfo directoryInfo = new DirectoryInfo(_path);
                    FileInfo[] filesInDir = directoryInfo.GetFiles((_processClaim.ClaimNo) + "*.*");

                    //foreach (FileInfo foundFile in filesInDir)
                    //{
                    //    string fullName = foundFile.FullName;
                    //    Console.WriteLine(fullName);
                    //}
                    return Json(new { ProcessClaim = _processClaim, ProcessClaimDetails = _processClaimDetails, Policy = result.Tables[0].ToJson(), Files = filesInDir.Select(f=> new { path = f.FullName, name = f.Name }) });
                }

                }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return null;
        }
        // [HttpGet("GetClaimByPolicyNum", Name = "GetClaimByPolicyNum")]

        [AuthorizationFilterFactory(InterfaceName = "Claim", EventAccess = "AllowEdit")]
        [HttpPost("EditClaim", Name = "EditClaim"), DisableRequestSizeLimit]
        public async Task<ActionResult> EditClaim([FromForm] string model, string claimFaults)
        {
            return await AddClaim(model, claimFaults);
        }
        
        [AuthorizationFilterFactory(InterfaceName = "Claim", EventAccess = "AllowAdd")]
        [HttpPost("AddClaim", Name = "AddClaim"), DisableRequestSizeLimit]
        public async Task<ActionResult> AddClaim([FromForm] string model,string claimFaults)
        {
            try
            {
                var files = Request.Form.Files;
                ClaimModel claim = Newtonsoft.Json.JsonConvert.DeserializeObject<ClaimModel>(System.Uri.UnescapeDataString(model));
                List<ProcessClaimDetailModel> claimDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProcessClaimDetailModel>>(System.Uri.UnescapeDataString(claimFaults));
                // ClaimModel claimm = ((JObject) model).ToObject<ClaimModel>();
                //ClaimModel claim = ((JObject)model).ToObject<ClaimModel>();
                //  IFormCollection filess = (IFormCollection)files;
                var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
                var _userCode = Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();

                var _path = System.IO.Directory.GetCurrentDirectory();
                _path = _path.Substring(0, _path.LastIndexOf('\\'));
                _path += @"\GwDealerPortal\wwwroot\Content\ClaimForms\";
                DirectoryInfo directoryInfo = new DirectoryInfo(_path);

                //foreach (FileInfo file in directoryInfo.GetFiles())
                //{
                //    file.Delete();
                //}
                //foreach (DirectoryInfo dir in di.GetDirectories())
                //{
                //    dir.Delete(true);
                //}
                long size = files.Sum(f => f.Length);
                for (int i = 0; i < files.Count; i++)
                {
                    if (files[i].Length > 0)
                    {
                        FileInfo[] filesInDir = directoryInfo.GetFiles(claim.ClaimNumber + "-*.*");
                        var _ext = Path.GetExtension(_path + files[i].FileName);
                        var _fileName = Path.GetFileNameWithoutExtension(_path + files[i].FileName);
                        using (var stream = new FileStream(_path + claim.ClaimNumber + "-" + _fileName + "-" + (filesInDir.Count() + i + 1) + _ext, FileMode.Create))
                        {
                            await files[i].CopyToAsync(stream);
                        }
                    }
                }
        
                if (claim != null && claimDetails != null)
                {
                    var _claim = new ProcessClaim
                    {
                        PolicyCode = claim.PolicyCode.ToString(),
                        ClaimNo = claim.ClaimNumber.ToString(),
                        DateOfFailure = claim.DateOfFailure,
                        BranchCode = claim.ClaimBranch,
                        JobCardNo = claim.JobCardNo, // add this column to procesClaim table
                        RepairerID = claim.Workshop,
                        IsMfgAssistance = claim.MfgAssistance,
                        ContactPerson = claim.ContactPerson,
                        ContactPhone = claim.ContactPhone,
                        LastServiceDate = claim.LastServiceDate,
                        LastServiceMileage = claim.LastServiceMileage,
                        SPDetails = claim.ServiceProofDetails,
                        LastBreakdownMileage = claim.BreakdownMileage,
                        RequestedAmount = claim.RequestedAmount,
                        TotalAmount = claim.TotalAmount,
                        EnteredOn = claim.EnteredOn,
                        AuthorizedAmount = claim.AuthorizedAmount,
                        GwAuthNo = claim.GwAuthNo,
                        AuthorizedBy = claim.AuthorizedBy,
                    
                        DeductableAmount = claim.DeductableAmount,
                        Remarks = claim.Remarks,
                        AuthorisedOn = claim.AuthorisedOn,
                        Status = claim.Status,
                        CreatedById = Convert.ToInt32( _userCode.Value),
                        CreatedDate = DateTime.Now,
                        IsDeleted = false,
                        ConfigID = Convert.ToInt32(_configId.Value)
                    };
                    var _claimCode = 0;
                    if (claim.ClaimCode > 0)
                    {
                        _claim.ClaimCode = claim.ClaimCode;
                        _claim.UpdatedById = Convert.ToInt32(_userCode.Value);
                        _claim.UpdatedDate = DateTime.Now;
                        _uow.Repository<ProcessClaim>().Update(_claim);
                        _claimCode = claim.ClaimCode;
                        var _previousClaimDetailIDs = _uow.Repository<ProcessClaimDetail>().Get(x => x.ClaimCode == _claimCode).Select(x => x.ProcessClaimDetailID).ToList();
                        for (int i = 0; i < _previousClaimDetailIDs.Count(); i++)
                        {
                            _uow.Repository<ProcessClaimDetail>().Delete(_previousClaimDetailIDs[i]);
                        }
                        _uow.Save();
                    }
                    else
                    {
                        _uow.Repository<ProcessClaim>().Insert(_claim);
                        _uow.Save();
                        var dataSet = DbAccess.ExecuteQuery(DbAccess.DBPortal, "SELECT IDENT_CURRENT('ProcessClaim')", new Dictionary<string, System.Data.SqlClient.SqlParameter>());
                    
                        if (dataSet != null)
                        {
                            _claimCode = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
                        }
                    }
                
                    //var _claim = _uow.Repository<ProcessClaim>().ExecSql("SELECT IDENT_CURRENT('ProcessClaim')").FirstOrDefault();
                    _uow.Repository<ClaimsStatus>().Insert(new ClaimsStatus {
                        ClaimCode = _claimCode,
                        ClaimStatus = claim.Status
                    });
                    for (int i = 0; i < claimDetails.Count; i++)
                    {
                        var _claimDetail = new ProcessClaimDetail
                        {
                            ClaimCode = _claimCode,
                            ActualCost = claimDetails[i].ActualCost,
                            Remarks = claimDetails[i].Remarks,
                            CreatedById = Convert.ToInt32(_userCode.Value),
                            FaultCode = claimDetails[i].FaultCode,
                            CreatedDate = DateTime.Now,
                            FinalCost = claimDetails[i].FinalCost,
                            Inspection = claimDetails[i].Inspection,
                            InspectionNo = claimDetails[i].InspectionNo,
                            IsDeleted = false,
                            IsInspectionDone = claimDetails[i].IsInspectionDone,
                            IsService = claimDetails[i].IsService,
                            LaborCost = claimDetails[i].LaborCost,
                            LaborDisPer = claimDetails[i].LaborDisPer,
                            MfgDisPer = claimDetails[i].MfgDisPer,
                            OtherCost = claimDetails[i].OtherCost,
                            PartCategory = claimDetails[i].PartCategory,
                            PartCode = claimDetails[i].PartCode,
                            PartSRNumber = claimDetails[i].PartSRNumber,
                            Total = claimDetails[i].Total,
                            RepairerDisPer = claimDetails[i].RepairerDisPer,
                            ServiceDisPerc = claimDetails[i].ServiceDisPerc
                        };
                        //if(claimDetails[i].ProcessClaimDetailID  > 0)
                        //{
                        //    _claimDetail.ProcessClaimDetailID = claimDetails[i].ProcessClaimDetailID;
                        //    _uow.Repository<ProcessClaimDetail>().Update(_claimDetail);
                        //}
                        //else
                        //{
                            _uow.Repository<ProcessClaimDetail>().Insert(_claimDetail);
                        //}
                    }
                    _uow.Save();
                    return Json(true);
                        //_processClaimDetailRepository.Insert(new ProcessClaimDetail { });

                        //var result = DbAccess.ExecuteSP(DbAccess.DBPortal, "claims_getDrpData", new Dictionary<string, System.Data.SqlClient.SqlParameter>() {
                        //{ "ConfigId",new System.Data.SqlClient.SqlParameter{ ParameterName = "ConfigId" , Value = Convert.ToInt32( _configId.Value) } }
                        //});
                        //return Json(result.Tables[0].ToJson());
                    }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return null;
        }
        [AuthorizationFilterFactory(InterfaceName = "Claim", EventAccess = "AllowDelete")]
        [HttpGet("DeleteClaimFile", Name = "DeleteClaimFile")]
        public IActionResult DeleteClaimFile(string fileName)
        {
            var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
            var _userCode = 151;// Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
            if (!string.IsNullOrEmpty(fileName))
            {
                var _path = System.IO.Directory.GetCurrentDirectory();
                _path = _path.Substring(0, _path.LastIndexOf('\\'));
                _path += @"\GwDealerPortal\wwwroot\Content\ClaimForms\";
                DirectoryInfo directoryInfo = new DirectoryInfo(_path);
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    if(file.Name == fileName)
                    {
                        file.Delete();
                        return Json(true);
                    }
                }
                //foreach (DirectoryInfo dir in di.GetDirectories())
                //{
                //    dir.Delete(true);
                //}
                
            }
            return null;
        }
        [AuthorizationFilterFactory(InterfaceName = "Claim", EventAccess = "AllowView")]
        [HttpGet("GetClaims", Name = "GetClaims")]
        public IActionResult GetClaims(string policyNumber = "", string slNumber = "", string clientRefNo = "")
        {
            var _configId = Request.Headers.Where(x => x.Key.ToLower() == "configid").FirstOrDefault();
            var _userCode = 151;// Request.Headers.Where(x => x.Key.ToLower() == "usercode").FirstOrDefault();
            if (!string.IsNullOrEmpty(policyNumber) || !string.IsNullOrEmpty(slNumber) || !string.IsNullOrEmpty(clientRefNo))
            {
                //var _query = "Select * from  PR_WEMS.dbo.claim_getbycriteria where (policyno='" + policyNumber + "' or vino='" + slNumber + "' or clientrefno='" + clientRefNo + "') and configid=" + _configId.Value;
                var result = DbAccess.ExecuteSP(DbAccess.DBPortal, "claim_getbycriteria", new Dictionary<string, System.Data.SqlClient.SqlParameter>() {
                { "PolicyNumber",new System.Data.SqlClient.SqlParameter{ ParameterName = "PolicyNumber" , Value = Convert.ToInt32( policyNumber) } },
                { "ClaimNumber",new System.Data.SqlClient.SqlParameter{ ParameterName = "ClaimNumber" , Value = Convert.ToInt32( slNumber) } },
                { "ClientRefNumber",new System.Data.SqlClient.SqlParameter{ ParameterName = "ClientRefNumber" , Value = clientRefNo } }
                });
                DataTable table = result.Tables[0];
                // var result = _uow.Repository<ProcessClaim>().Get(pc=>pc.IsDeleted == false && pc.ConfigID == Convert.ToInt32( _configId.Value)).ToList();
                return Json(table.ToJson());
            }
            return null;
        }
    }
    }