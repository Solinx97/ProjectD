using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ViewDirectory.Models;

namespace ViewDirectory.Controllers
{
    public class IndividualPlanYearController : Controller
    {
        private const string PathToData = @"Data\data-1.json";
        private readonly IndividualPlanOnTerm _individualPlan;

        public IndividualPlanYearController()
        {
            var data = System.IO.File.ReadAllText(Path.GetFullPath(PathToData));
            _individualPlan = JsonConvert.DeserializeObject<IndividualPlanOnTerm>(data);
        }

        [HttpGet]
        public ActionResult Show()
        {
            var months = new List<string>();
            var planTimeTypes = new List<string>();
            var subjects = new List<string>();
            foreach (var item in _individualPlan.Months)
            {
                months.Add(item.Name);
            }

            foreach (var item in _individualPlan.PlanTimeTypes)
            {
                planTimeTypes.Add(item.Name);
            }

            foreach (var item in _individualPlan.Subjects)
            {
                subjects.Add(item.Name);
            }

            ViewBag.Months = new SelectList(months.Distinct());
            ViewBag.PlanTimeTypes = new SelectList(planTimeTypes.Distinct());
            ViewBag.Subjects = new SelectList(subjects.Distinct());

            return View(_individualPlan);
        }

        [HttpGet]
        public ActionResult GetPlanTimes(string monthName, string planTimeTypeName, string subjectName)
        {
            var months = _individualPlan.Months.Where(val => val.Name == monthName).ToList();
            var subjects = _individualPlan.Subjects.Where(val => val.Name == subjectName).ToList();
            var planTimeTypes = _individualPlan.PlanTimeTypes.Where(val => val.Name == planTimeTypeName).ToList();
            var planTimes = _individualPlan.PlanTimes.Where(val => months.Any(x => x.Id == val.MonthId)
                                && subjects.Any(z => z.Id == val.SubjectId) && planTimeTypes.Any(y => y.Id == val.PlanTimeTypeId)).ToList();

            return PartialView(planTimes);
        }

        [HttpGet]
        public ActionResult GetGroups(string subjectName)
        {
            var subjects = _individualPlan.Subjects.Where(val => val.Name == subjectName).ToList();
            var groups = _individualPlan.Groups.Where(val => subjects.Any(x => x.GroupId == val.Id)).ToList();

            return PartialView(groups);
        }

        [HttpGet]
        public ActionResult GetPlanTimeType(string planTimeTypeName)
        {
            var planTimeTypes = _individualPlan.PlanTimeTypes.Where(val => val.Name == planTimeTypeName).ToList();

            return PartialView(planTimeTypes);
        }
    }
}