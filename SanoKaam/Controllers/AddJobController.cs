using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SanoKaam.Areas.Identity.Data;
using SanoKaam.Models;
using System.Security.Claims;

namespace SanoKaam.Controllers
{
    [Authorize(Roles = "Employ")]
    public class AddJobController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AddJobController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET
        public IActionResult Index()

        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Id = userId;

            return View();
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Index(Job obj, IFormFile CompanyLogo)
        {
            try
            {
                if (CompanyLogo != null && CompanyLogo.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    { 
                        await CompanyLogo.CopyToAsync(ms);
                        obj.CompanyLogo = ms.ToArray();
                    }
                }
                _db.Jobs.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View("Error"); 
            }
        }

    }
}
