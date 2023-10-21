using Microsoft.AspNetCore.Mvc;
using RentalSys.Models;

namespace RentalSys.Controllers
{
    public class AdminController : Controller
    {
        readonly AppDbContext _dbContext;
        //public const string SessionKeyName = "_Name";

        public AdminController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            HttpContext.Session.Remove("_UserSession");

            if (HttpContext.Session.GetString("_AdminSession") != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult AdminLogin(AdminModel admin)
        {

            var model = _dbContext.AdminModels.Where(adObj => adObj.AdName == admin.AdName && adObj.Password == admin.Password).FirstOrDefault();
            if (model != null)
            {
                HttpContext.Session.SetString("_AdminSession", model.AdName);
                string adName = model.AdName;
                ViewBag.an = adName;
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.m = "Wrong userid or password";
                return View();
            }

        }

        public ActionResult Dashboard()
        {
            return View();
        }
    }
}
