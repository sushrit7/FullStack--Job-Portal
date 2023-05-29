using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SanoKaam.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using SanoKaam.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;

namespace SanoKaam.Controllers
{
    public class ProfessionalProfileController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProfessionalProfileController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            var loginId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);


            
            var checkprofile = _db.Profiles.FirstOrDefault(c => c.UserId == loginId);


            if (checkprofile == null)
            {
                return RedirectToAction("Create", "ProfessionalProfile");
            }

            var profileFromDb = _db.Profiles.Where(c => c.UserId == loginId)
                                            .Include(c => c.Education)
                                            .Include(c => c.Experience)
                                            .Include(c => c.Skill)
                                            .FirstOrDefault();

            return View(profileFromDb);

            //public IActionResult Index()
            // {
            //     var employees = _dbContext.Employees.Include(e => e.Educations).ToList();
            //     return View(employees);
            // }
        }

        [HttpGet]
        public IActionResult Create()
        {

            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid id = new Guid(userId);
            ViewBag.Id = id;

            Profile profile = new()
            {
                Experience = new List<Experience>(),  
                Education = new List<Education>(),
            };
            profile.Experience.Add(new Experience());
            profile.Education.Add(new Education());
            return View(profile);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Profile profile, IFormFile photo)
            {
            
                if (photo != null && photo.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await photo.CopyToAsync(ms);
                        profile.Photo = ms.ToArray();
                    }
                }
                _db.Profiles.Add(profile);
                _db.SaveChanges();

                return RedirectToAction("Index");
           
        }

        public IActionResult GetPhoto(int id)
        {
            var profile = _db.Profiles.FirstOrDefault(p => p.Id == id); // Retrieve the Profile object with the specified ID from the data store
            if (profile != null && profile.Photo != null) // If the Profile object and its Photo property are not null
            {
                return File(profile.Photo, "image/jpeg"); // Return a FileResult that contains the photo data as a JPEG image
            }
            else
            {
                return NotFound(); // Return a 404 Not Found response if the profile or photo is not found
            }
        }

        public IActionResult GetLogo(int id)
        {
            var job = _db.Jobs.FirstOrDefault(p => p.Id == id); // Retrieve the Profile object with the specified ID from the data store
            if (job != null && job.CompanyLogo != null) // If the Profile object and its Photo property are not null
            {
                return File(job.CompanyLogo, "image/jpeg"); // Return a FileResult that contains the photo data as a JPEG image
            }
            else
            {
                return NotFound(); // Return a 404 Not Found response if the profile or photo is not found
            }
        }




        //GET 
        [HttpGet]
        public IActionResult Update()
        {

            var LoggedInId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var profileFromDb = _db.Profiles.Where(c => c.UserId == LoggedInId)
                                            .Include(c => c.Education)
                                            .Include(c => c.Experience)
                                            .Include(c => c.Skill)
                                            .FirstOrDefault();
            ViewBag.Id = LoggedInId;
            return View(profileFromDb);
        }


        [HttpPost]
        public async Task<IActionResult> Update(Profile obj, IFormFile photo)
        {

            if (photo != null && photo.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await photo.CopyToAsync(ms);
                    obj.Photo = ms.ToArray();
                }
            }
            else
            {
                obj.Photo = _db.Profiles.Where(c => c.Id == obj.Id)
                                        .Select(c => c.Photo)
                                        .FirstOrDefault();
            }
            _db.Profiles.Update(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult AddEducation()
        {
            return PartialView("_Education", new Education());
        }
        public IActionResult AddSkill()
        {
            return PartialView("_Skill", new Skill());
        }
        [HttpPost]

        public IActionResult RemoveExperience(int id)
        {
            var experience = _db.Experiences.Find(id);

            try
            {
                _db.Experiences.Remove(experience);
                _db.SaveChanges();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

            
        }
        public IActionResult RemoveSkill(int id)
        {
            var skill = _db.Skills.Find(id);

            try
            {
                _db.Skills.Remove(skill);
                _db.SaveChanges();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }


        }

        public IActionResult RemoveEducation(int id)
        {
            var education = _db.Educations.Find(id);

            try
            {
                _db.Educations.Remove(education);
                _db.SaveChanges();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }


        }

    }
}
