using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ViewDirectory.Models;

namespace ViewDirectory.Controllers
{
    public class DirectoryController : Controller
    {
        private const string PathToData = @"Data\data-0.json";
        private readonly DataTransfer _data;

        public DirectoryController()
        {
            var dataTransfer = System.IO.File.ReadAllText(Path.GetFullPath(PathToData));
            _data = JsonConvert.DeserializeObject<DataTransfer>(dataTransfer);
        }

        [HttpGet]
        public ActionResult Show()
        {
            ViewBag.Faculties = new SelectList(_data.Faculties, "Id", "Name");

            return View(_data);
        }

        [HttpGet]
        public ActionResult GetLoads(int groupId)
        {
            var dataTransfer = System.IO.File.ReadAllText(Path.GetFullPath(PathToData));
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

        [HttpGet]
        public ActionResult GetGroups(int facultyId)
        {
            var groups = _data.Groups.Where(val => val.FacultyId == facultyId).ToList();
            ViewBag.Groups = new SelectList(groups, "Id", "Name");

            return PartialView();
        }
    }
}