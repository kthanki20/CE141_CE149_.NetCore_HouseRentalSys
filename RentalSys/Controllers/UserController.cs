using Microsoft.AspNetCore.Mvc;
using RentalSys.Models;

namespace RentalSys.Controllers
{
    public class UserController : Controller
    {
        readonly AppDbContext _dbContext;
        //public const string SessionKeyName = "_Name";

        public UserController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserLogin()
        {
            HttpContext.Session.Remove("_AdminSession");
            if (HttpContext.Session.GetString("_UserSession") != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();

            }


        }

        [HttpPost]
        public IActionResult UserLogin(UserModel admin)
        {
            var model = _dbContext.UserModels.Where(adObj => adObj.Username == admin.Username && adObj.Password == admin.Password).FirstOrDefault();
            if (model != null)
            {
                HttpContext.Session.SetString("_UserSession", model.Username);
                string adName = model.Username;
                ViewBag.an = adName;
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.m = "Wrong userid or password";
                return View();
            }

        }
        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserRegister([Bind("UserId,FirstName,LastName,Email,Username,Password,Age,PhoneNo,CNIC")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                _dbContext.UserModels.Add(userModel);
                await _dbContext.SaveChangesAsync();
                ViewBag.m = "Registration was Successful";
                return RedirectToAction("UserLogin");
            }
            return View(userModel);
        }
    }
}
