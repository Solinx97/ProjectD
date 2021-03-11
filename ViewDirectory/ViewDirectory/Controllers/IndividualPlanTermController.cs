using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IO;
using ViewDirectory.Models;

namespace ViewDirectory.Controllers
{
    public class IndividualPlanTermController : Controller
    {
        private const string PathToData = @"Data\data-2.json";
        private readonly IndividualPlanOnYear[] _individualPlan;

        public IndividualPlanTermController()
        {
            var dataTransfer = System.IO.File.ReadAllText(Path.GetFullPath(PathToData));
            _individualPlan = JsonConvert.DeserializeObject<IndividualPlanOnYear[]>(dataTransfer);
        }

        [HttpGet]
        public ActionResult Show()
        {
            ViewBag.Teachers = new SelectList(_individualPlan, "TeacherName", "TeacherName");

            return View(_individualPlan);
        }

        [HttpGet]
        public ActionResult GetBids(int index)
        {
            var bids = _individualPlan[index].Bids;

            return PartialView(bids);
        }
    }
}