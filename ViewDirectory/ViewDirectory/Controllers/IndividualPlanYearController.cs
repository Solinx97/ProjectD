using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using ViewDirectory.Models;

namespace ViewDirectory.Controllers
{
    public class IndividualPlanYearController : Controller
    {
        private const string PathToData = @"Data\data-2.json";

        [HttpGet]
        public ActionResult Show()
        {
            var data = System.IO.File.ReadAllText(Path.GetFullPath(PathToData));
            var individualPlan = JsonConvert.DeserializeObject<IndividualPlanOnYear[]>(data);

            return View(individualPlan);
        }
    }
}