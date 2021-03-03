using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ViewDirectory.Controllers
{
    public class DirectoryController1 : Controller
    {
        // GET: DirectoryController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: DirectoryController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DirectoryController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DirectoryController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DirectoryController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DirectoryController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DirectoryController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DirectoryController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
