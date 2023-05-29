using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SanoKaam.Areas.Identity.Data;

namespace SanoKaam.Controllers
{
    public class HireController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HireController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            var profilestodisplay = _db.Profiles
                .Include(p => p.Education)
                .Include(p => p.Experience)
                .Include(p => p.Skill)
                .ToList();

            return View(profilestodisplay);
        }
    }
}
