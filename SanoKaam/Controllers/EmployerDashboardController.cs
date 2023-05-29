using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SanoKaam.Areas.Identity.Data;
using SanoKaam.Models;
using System.Security.Claims;

namespace SanoKaam.Controllers
{

    public class EmployerDashboardController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmployerDashboardController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Id = userId;

            var applicants = _db.Applies.Where(p => userId.Contains(p.EmployerId)).ToList();

            return View(applicants);
        }


        [HttpGet]
        public IActionResult Applicant(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var applicantFromDb = _db.Applies.Where(p => p.id == id)
                .Include(p => p.Profile.Education)
                .Include(p => p.Profile.Experience)
                .Include(p => p.Profile.Skill)
                .FirstOrDefault();
            if (applicantFromDb == null)
            {
                return NotFound();
            }

            return View(applicantFromDb);
        }

        [HttpPost]

        public IActionResult Applicant(Apply obj)
        {
            obj.Photo = _db.Applies.Where(p => p.id == obj.id)
                .Select(p => p.Photo)
                .FirstOrDefault();
            _db.Applies.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult MyJobs()
        {
            var userid = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.id = userid;

            var myJobs = _db.Jobs.Where(p => userid.Contains(p.EmployerId)).ToList();

            return View(myJobs);
        }

        public IActionResult MyJobDetail(int? id)
        {

            var JobDetail = _db.Jobs.Find(id);


            return View(JobDetail);
        }

        [HttpGet]
        public IActionResult MyJobDetailEdit(int? id)
        {
            var JobDetail = _db.Jobs.Find(id);
            return View(JobDetail);
        }

        [HttpPost]
        public async Task<IActionResult> MyJobDetailEdit(Job job, IFormFile companylogo)
        {
            if (companylogo != null && companylogo.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await companylogo.CopyToAsync(ms);
                    job.CompanyLogo = ms.ToArray();
                }
            }
            else
            {
                job.CompanyLogo = _db.Jobs.Where(c => c.Id == job.Id)
                                        .Select(c => c.CompanyLogo)
                                        .FirstOrDefault();
            }

            _db.Jobs.Update(job);
            _db.SaveChanges();
            return RedirectToAction("MyJobs");
        }

        public IActionResult RemoveJob(int id)
        {
            var job = _db.Jobs.Find(id);

            _db.Jobs.Remove(job);
            _db.SaveChanges();
            return RedirectToAction("MyJobs");
        }
    }


}
