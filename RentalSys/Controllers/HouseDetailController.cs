using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalSys.Models;

namespace RentalSys.Controllers
{
    public class HouseDetailController : Controller
    {
        private readonly AppDbContext _context;

        public HouseDetailController(AppDbContext context)
        {
            _context = context;
        }

        // GET: HouseDetailsModels
        public async Task<IActionResult> Index()
        {
           
                return View(_context.HouseDetailsModels.ToList());
            
           

        }

        // GET: HouseDetailsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("_AdminSession") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var houseDetailsModel = await _context.HouseDetailsModels
                    .FirstOrDefaultAsync(m => m.HouseID == id);
                if (houseDetailsModel == null)
                {
                    return NotFound();
                }

                return View(houseDetailsModel);

            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }

        }

        // GET: HouseDetailsModels/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("_AdminSession") != null)
            {
                
                return View();

            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }

        }

        // POST: HouseDetailsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HouseID,HouseName,HouseType,HouseRentAmount,HouseAddress")] HouseDetailModel houseDetailsModel)
        {
          

                    

                        _context.HouseDetailsModels.Add(houseDetailsModel);
                        _context.SaveChanges();
                        ViewBag.m = "Record Saved";
                       
                        return View();



               

        }

        // GET: FlightDetailsModels/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("_AdminSession") != null)
            {
                var detail = _context.HouseDetailsModels.Where(model => model.HouseID == id).FirstOrDefault();


                //ViewBag.PlaneList = new SelectList(_context.AeroPlaneModels, "PlaneId", "APlaneName");
                return View(detail);

            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }



        }

        // POST: FlightDetailsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("HouseID,HouseName,HouseType,HouseRentAmount,HouseAddress")] HouseDetailModel houseDetailsModel)
        {
            if (HttpContext.Session.GetString("_AdminSession") != null)
            {
                try
                {
                    var houseDetail = _context.HouseDetailsModels.Where(model => model.HouseID == id).FirstOrDefault();
                    //ViewBag.PlaneList = new SelectList(_context.AeroPlaneModels, "PlaneId", "APlaneName");
                    _context.HouseDetailsModels.Remove(houseDetail);
                    //houseDetailsModel.PlaneId = flightDetail.PlaneId;
                    _context.HouseDetailsModels.Add(houseDetailsModel);
                    _context.SaveChanges();
                    ViewBag.m = "Information Updated";
                    return View();
                }
                catch
                {
                    //ViewBag.PlaneList = new SelectList(_context.AeroPlaneModels, "PlaneId", "APlaneName");
                    return View(houseDetailsModel);
                }

            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }


        }

        // GET: HouseDetailsModels/Delete/5
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("_AdminSession") != null)
            {
                var detail = _context.HouseDetailsModels.Where(model => model.HouseID == id).FirstOrDefault();
                return View(detail);
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("_AdminSession") != null)
            {
                try
                {
                    var flightDetails = _context.HouseDetailsModels.Where(model => model.HouseID == id).FirstOrDefault();
                    _context.HouseDetailsModels.Remove(flightDetails);
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }

        }
    }
}
