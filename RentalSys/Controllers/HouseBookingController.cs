using Microsoft.AspNetCore.Mvc;
using RentalSys.Models;

namespace RentalSys.Controllers
{
    public class HouseBookingController : Controller
    {
        private readonly AppDbContext _context;

        public HouseBookingController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FlightBooking
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("_UserSession") != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return RedirectToAction("UserLogin", "User");
            }

        }

        public ActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("_UserSession") != null)
            {
                ViewBag.htype = _context.HouseDetailsModels.Select(l => l.HouseType).Distinct().ToList();
                
                return View();
            }
            else
            {
                return RedirectToAction("UserLogin", "User");

            }


        }

        [HttpPost]
        public ActionResult Search(string htype)
        {
            if (HttpContext.Session.GetString("_UserSession") != null)
            {
                var details = _context.HouseDetailsModels.Where(l => l.HouseType.Equals(htype)).FirstOrDefault();
                ViewBag.ss = details;
                return View();
            }
            else
            {
                return RedirectToAction("UserLogin", "User");

            }

        }
        // GET: HouseBooking/Details/5

        public ActionResult ViewAllHouses()
        {
            if (HttpContext.Session.GetString("_UserSession") != null)
            {
                return View(_context.HouseDetailsModels.ToList());
            }
            else
            {
                return RedirectToAction("UserLogin", "User");

            }

        }


        public ActionResult BookingHouse(int id)
        {
            if (HttpContext.Session.GetString("_UserSession") != null)
            {
                var detail = _context.HouseDetailsModels.Where(model => model.HouseID == id).FirstOrDefault();
                ViewBag.housedetails = detail;
                return View("Booking");
            }
            else
            {
                return RedirectToAction("UserLogin", "User");

            }


        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Booking([Bind("Bid,bCusName,bCusAddress,bCusEmail,bCusPhoneNum,bCusCnic,HouseID")] HouseBookingModel houseBookingModel)
        {
           
              
                    _context.HouseBookingModels.Add(houseBookingModel);
                     _context.SaveChanges();
                    var detail = _context.HouseDetailsModels.Where(model => model.HouseID == houseBookingModel.HouseId).FirstOrDefault();
                    ViewBag.housedetails = detail;
                    ViewBag.m = "Record Saved";
                    return View();
              



        }

        public ActionResult BookedHouses()
        {
          
                return View(_context.HouseBookingModels.ToList());
         
        }



        public async Task<IActionResult> Details(int? id)
        {
           
                var detail = _context.HouseDetailsModels.Where(model => model.HouseID == id).FirstOrDefault();
                return View(detail);
          

        }

        // GET: HouseBooking/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("_UserSession") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("UserLogin", "User");

            }

        }

        // POST: HouseBooking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Bid,bCusName,bCusAddress,bCusEmail,bCusPhoneNum,bCusCnic,HouseID")] HouseBookingModel houseBookingModel)
        {
            if (HttpContext.Session.GetString("_UserSession") != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(houseBookingModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(houseBookingModel);
            }
            else
            {
                return RedirectToAction("UserLogin", "User");

            }

        }

    }
}
