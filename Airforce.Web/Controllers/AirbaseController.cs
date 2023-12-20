using Microsoft.AspNetCore.Mvc;
using Alesik.Haidov.Airforce.Web.Services;
using Alesik.Haidov.Airforce.Web.Models;
using Alesik.Haidov.Airforce.Web.Models;
using Alesik.Haidov.Airforce.Web.Services;


namespace Alesik.Haidov.Airforce.Web.Controllers
{
    public class AirbaseController : Controller
    {
        private readonly AirbaseService _airbaseService;

        public AirbaseController(AirbaseService airbaseService)
        {
            _airbaseService = airbaseService;
        }

        public IActionResult Index()
        {
            var airbases = _airbaseService.GetAllAirbases();
            return View(airbases);
        }

        public IActionResult Details(string id)
        {
            var airbase = _airbaseService.GetAirbaseById(id);
            if (airbase == null)
            {
                return NotFound();
            }
            return View(airbase);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Airbase airbase)
        {
            if (ModelState.IsValid)
            {
                _airbaseService.CreateOrUpdateAirbase(airbase);
                return RedirectToAction(nameof(Index));
            }
            return View(airbase);
        }

        public IActionResult Edit(string id)
        {
            var airbase = _airbaseService.GetAirbaseById(id);
            if (airbase == null)
            {
                return NotFound();
            }
            return View(airbase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Airbase airbase)
        {
            if (id != airbase.GUID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _airbaseService.CreateOrUpdateAirbase(airbase);
                return RedirectToAction(nameof(Index));
            }
            return View(airbase);
        }

        public IActionResult Delete(string id)
        {
            var airbase = _airbaseService.GetAirbaseById(id);
            if (airbase == null)
            {
                return NotFound();
            }
            return View(airbase);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            _airbaseService.RemoveAirbase(id);
            return RedirectToAction(nameof(Index));
        }
    }
}