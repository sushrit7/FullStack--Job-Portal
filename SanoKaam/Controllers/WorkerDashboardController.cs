 using Microsoft.AspNetCore.Mvc;
using SanoKaam.Areas.Identity.Data;
using System.Security.Claims;

namespace SanoKaam.Controllers
{
    public class WorkerDashboardController : Controller
    {
        private readonly ApplicationDbContext _db;

        public WorkerDashboardController(ApplicationDbContext db)
        {
            _db = db;
        }



        public IActionResult Index()

        {
            var loggedId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Id = loggedId;

             var appliedJobs = _db.Applies
                               .Where(a => a.UserId == loggedId)
                               .ToList();

            return View(appliedJobs);
        }

        public IActionResult AppliedCompany(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var workFromDb = _db.Jobs.Find(id);

            if (workFromDb == null)
            {
                return NotFound();
            }

            return View(workFromDb);
        }
    }
}
