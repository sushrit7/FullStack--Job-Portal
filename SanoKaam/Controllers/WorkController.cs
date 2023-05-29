using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SanoKaam.Areas.Identity.Data;
using SanoKaam.Models;
using System.Security.Claims;

namespace SanoKaam.Controllers;


public class WorkController : Controller
{
    private readonly ApplicationDbContext _db;

    public WorkController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        IEnumerable<Job> objCategoryList = _db.Jobs.ToList();
        return View(objCategoryList);

    }

    //GET
    public IActionResult ViewMore(int? id)
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


    [Authorize(Roles = "Find Work")]
    [HttpGet]
    public IActionResult Apply(int? id)

    {
        var LoggedId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        var profileFromDb = _db.Profiles.Where(p => p.UserId == LoggedId)
                                        .Include(p => p.Education)
                                        .Include(p => p.Experience)
                                        .Include(p => p.Skill)
                                        .FirstOrDefault();

        var jobFromDb = _db.Jobs.Find(id);

        ApplyView applyview = new ApplyView
        {
            Profile = profileFromDb,

            Job = jobFromDb,


        };

        return View(applyview);
    }

    [HttpPost]
    public async Task<IActionResult> Apply(ApplyView obj, IFormFile photo)
    {

        if (photo != null && photo.Length > 0)
        {
            using (var ms = new MemoryStream())
            {
                await photo.CopyToAsync(ms);
                obj.Apply.Photo = ms.ToArray();
            }
        }
        else
        {
            obj.Apply.Photo = _db.Profiles.Where(c => c.Id == obj.Profile.Id)
                                    .Select(c => c.Photo)
                                    .FirstOrDefault();
        }
        _db.Applies.Add(obj.Apply);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }


}