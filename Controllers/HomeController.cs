using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API_DOTNET.Models;
using System.Diagnostics;
using System.Linq;

namespace REST_API_DOTNET.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        CompContext db;
        public HomeController(CompContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Computers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // Просмотр подробных сведений о книге
        public ActionResult Details(int id)
        {
            Computer comp = db.Computers.Find(id);
            if (comp != null)
            {
                return PartialView("Details", comp);
            }
            return View("Index");
        }
        // Добавление
        public ActionResult Create()
        {
            return PartialView("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Computer comp)
        {
            db.Computers.Add(comp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // Редактирование
        public ActionResult Edit(int id)
        {
            Computer comp = db.Computers.Find(id);
            if (comp != null)
            {
                return PartialView("Edit", comp);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Computer comp)
        {
            db.Entry(comp).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // Удаление
        public ActionResult Delete(int id)
        {
            Computer comp = db.Computers.Find(id);
            if (comp != null)
            {
                return PartialView("Delete", comp);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteRecord(int id)
        {
            Computer comp = db.Computers.Find(id);

            if (comp != null)
            {
                db.Computers.Remove(comp);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
