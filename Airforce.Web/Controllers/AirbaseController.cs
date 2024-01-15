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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Airbase airbase)
        {
            if (!string.IsNullOrWhiteSpace(airbase.Name) & !string.IsNullOrWhiteSpace(airbase.Location))
            {
                _airbaseService.CreateOrUpdateAirbase(airbase);
                return RedirectToAction(nameof(Index));
            }
            return View(airbase);
        }

        [HttpGet]
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
        public IActionResult Edit(Airbase airbase)
        {
            if (!ModelState.IsValid)
            {
                return View(airbase);
            }

            _airbaseService.CreateOrUpdateAirbase(airbase);
            return RedirectToAction(nameof(Index));
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
            var aircraft = _airbaseService.GetAirbaseById(id);
            if (aircraft != null)
            {
                _airbaseService.RemoveAirbase(aircraft.GUID);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}