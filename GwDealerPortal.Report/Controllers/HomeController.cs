using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GwDealerPortal.Report.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ShowReport(string Name, string StartDate, string EndDate, string InvoiceNumber = "",
        int branchID = 0, int userID = 0, int dealerID = 0, int productGroupID = 0, int productSubGroupID=0,bool isExcel = false)
        {
            try
            {
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(Server.MapPath("~/") + "//Reports//" + Name + ".rpt");
                if (Name.ToLower().Contains("crystalreport1"))
                {
                    cryRpt.DataSourceConnections[0].SetConnection("DealerPortalLive", "DealerPortalLive", "sa", "gw5209");
                }
                else
                {
                    cryRpt.DataSourceConnections[0].SetConnection("GWSQLSERVER\\GWSQLSERVER", "PR_WEMSPORTAL", "sa", "gw5209");
                }
                cryRpt.Refresh();
                if (Name.ToLower().Contains("policyprint"))
                {
                    cryRpt.SetParameterValue("InvoiceNumber", InvoiceNumber);
                }
                else if (Name.ToLower().Contains("pc"))
                {
                    cryRpt.SetParameterValue("PolicyNumber", Convert.ToInt32(InvoiceNumber));
                    //cryRpt.SetParameterValue("InvoiceNumber", InvoiceNumber);
                }
                else if (Name.ToLower().Contains("sale"))
                {
                    cryRpt.SetParameterValue("prmBranchID", branchID);
                    cryRpt.SetParameterValue("prmUserID", userID);
                    cryRpt.SetParameterValue("prmDealerID", dealerID);
                    cryRpt.SetParameterValue("prmProductGroupID", productGroupID);
                    cryRpt.SetParameterValue("prmProductSubGroupID", productSubGroupID);
                    cryRpt.SetParameterValue("prmFromDate", StartDate);
                    cryRpt.SetParameterValue("prmToDate", EndDate);
                    //cryRpt.SetParameterValue("InvoiceNumber", InvoiceNumber);
                }
                if(isExcel)
                {
                    cryRpt.ExportToHttpResponse(ExportFormatType.Excel, System.Web.HttpContext.Current.Response, false, "crReport");
                }
                else
                {
                    cryRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "crReport");
                }
                
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }
            return null;
        }
    }
}