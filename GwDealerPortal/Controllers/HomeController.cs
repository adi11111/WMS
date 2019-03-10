using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace GwDealerPortal.Controllers
{

    public class HomeController : Controller
    {
        private IHostingEnvironment _env;
        private readonly IHttpContextAccessor _accessor;
        public HomeController(IHostingEnvironment env)
        {
            _env = env;
           // _accessor = accessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
        //public void ShowReport(string Name, string StartDate, string EndDate, string InvoiceNumber)
        //{
        //    try
        //    {
        //        string webRootPath = _env.WebRootPath;
        //        string contentRootPath = _env.ContentRootPath;
        //        ReportDocument cryRpt = new ReportDocument();
        //        cryRpt.Load(contentRootPath + "//Reports//" + Name + ".rpt");

        //        if (Name.ToLower().Contains("crystalreport1"))
        //        {
        //            cryRpt.DataSourceConnections[0].SetConnection("DealerPortalLive", "DealerPortalLive", "sa", "gw5209");
        //        }
        //        else
        //        {
        //            cryRpt.DataSourceConnections[0].SetConnection("GWSQLSERVER\\GWSQLSERVER", "PR_WEMSPORTAL", "sa", "gw5209");
        //        }

        //        cryRpt.Refresh();
        //        if (Name.ToLower().Contains("crystalreport1"))
        //        {

        //        }
        //        else
        //        {
        //            //cryRpt.SetParameterValue("InvoiceNumber", InvoiceNumber);
        //        }
        //        //cryRpt.SetParameterValue("InvoiceNumber", InvoiceNumber);
        //        // cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, _accessor.HttpContext.Response, false, "crReport");
        //        //cryRpt.Refresh();
        //        if (System.IO.File.Exists(@"D:\" + Name + ".pdf"))
        //            System.IO.File.Delete(@"D:\" + Name + ".pdf");
        //        cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\" + Name + ".pdf");
        //    }


        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}



    }
}
