using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using ViewDirectory.Models;

namespace ViewDirectory.Controllers
{
    public class BidsController : Controller
    {
        [HttpGet]
        public ActionResult Show()
        {
            var teacherBids = System.IO.File.ReadAllText(Path.GetFullPath(@"Data\data-2.json"));
            var result = JsonConvert.DeserializeObject<TeacherBids[]>(teacherBids);

            return View(result);
        }
    }
}