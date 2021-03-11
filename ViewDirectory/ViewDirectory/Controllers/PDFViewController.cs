using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReportsWebUI.Utils;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ViewDirectory.Controllers
{
    public class PDFViewController : Controller
    {
        private readonly ILogger<PDFViewController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PDFViewController(ILogger<PDFViewController> logger, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<string> GetReportDetails(int reportNumber)
        {
            string staticResourcesPathBase = _webHostEnvironment.WebRootPath;
            string outFileName = $"{DateTime.Now.ToString("yymmssfff")}-report.pdf";
            string fullOutFileName = Path.Combine(staticResourcesPathBase, $"{DateTime.Now.ToString("yymmssfff")}-report.pdf");


            string sourceFilePath = string.Empty;
            switch (reportNumber)
            {
                case 0:
                    sourceFilePath = Path.Combine(staticResourcesPathBase, "team1Report.xlsx");
                    break;

                case 1:
                    sourceFilePath = Path.Combine(staticResourcesPathBase, "team2Report.xlsx");
                    break;

                case 2:
                    sourceFilePath = Path.Combine(staticResourcesPathBase, "team3Report.xlsx");
                    break;
            }


            var convertedFile = await ExcelToPDFConverter.GetConvertedResponseBySource(sourceFilePath, fullOutFileName);
            var phResult = new PhysicalFileResult(convertedFile.FullName, "application/pdf");

            return outFileName;
        }
    }
}
