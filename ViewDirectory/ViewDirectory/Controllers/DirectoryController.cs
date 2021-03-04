using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ViewDirectory.Models;

namespace ViewDirectory.Controllers
{
    public class DirectoryController : Controller
    {
        [HttpGet]
        public ActionResult Show()
        {
            var dataTransfer = System.IO.File.ReadAllText(Path.GetFullPath(@"Data\data-0.json"));
            var result = JsonConvert.DeserializeObject<DataTransfer>(dataTransfer);

            return View(result);
        }

        [HttpGet]
        public ActionResult ShowLoads(int groupId)
        {
            var dataTransfer = System.IO.File.ReadAllText(Path.GetFullPath(@"Data\data-0.json"));
            var result = JsonConvert.DeserializeObject<DataTransfer>(dataTransfer);
            var groupLoads = result.GroupLoads.Where(val => val.GroupId == groupId);
            var unitOfLoads = result.UnitOfLoads.Where(val => groupLoads.Any(v => v.UnitOfLoadId == val.Id));

            var loads = new List<Load>();
            var subjects = new List<Subject>();
            var teachers = new List<Teacher>();

            foreach (var item in unitOfLoads)
            {
                loads.Add(result.Loads.FirstOrDefault(val => val.Id == item.LoadId));
                subjects.Add(result.Subjects.FirstOrDefault(val => val.Id == item.SubjectId));
                teachers.Add(result.Teachers.FirstOrDefault(val => val.Id == item.TeacherId));
            }

            ViewData["loads"] = loads;
            ViewData["subjects"] = subjects;
            ViewData["teachers"] = teachers;

            return PartialView(unitOfLoads.ToList());
        }
    }
}