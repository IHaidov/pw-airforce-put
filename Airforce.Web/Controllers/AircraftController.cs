using Microsoft.AspNetCore.Mvc;
using Alesik.Haidov.Airforce.Web.Services;
using Alesik.Haidov.Airforce.Web.Models;
using Alesik.Haidov.Airforce.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Alesik.Haidov.Airforce.Web.Controllers
{
    public class AircraftController : Controller
    {
        private readonly AircraftService _aircraftService;
        private readonly AirbaseService _airbaseService;

        public AircraftController(AircraftService aircraftService, AirbaseService airbaseService)
        {
            _aircraftService = aircraftService;
            _airbaseService = airbaseService;
        }

        public IActionResult Index()
        {
            var aircrafts = _aircraftService.GetAllAircrafts();
            return View(aircrafts);
        }

        public IActionResult Details(string id)
        {
            var aircraft = _aircraftService.GetAircraftById(id);
            if (aircraft == null)
            {
                return NotFound();
            }
            return View(aircraft);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Assuming your airbase service method returns a list of airbases
            var airbases = _airbaseService.GetAllAirbases();

            ViewData["Airbases"] = new SelectList(airbases, "GUID", "Name");
            ViewData["Types"] = new SelectList(Enum.GetValues(typeof(AircraftType)), "Value", "Text");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Aircraft aircraft)
        {
            if (ModelState.IsValid)
            {
                _aircraftService.CreateOrUpdateAircraft(aircraft);
                return RedirectToAction(nameof(Index));
            }
            return View(aircraft);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var aircraft = _aircraftService.GetAircraftById(id);
            if (aircraft == null)
            {
                return NotFound();
            }

            ViewData["Types"] = Enum.GetValues(typeof(AircraftType));

            var airbases = _airbaseService.GetAllAirbases();
            ViewData["Airbases"] = airbases;

            return View(aircraft);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Aircraft aircraft)
        {
            if (ModelState.IsValid)
            {
                _aircraftService.CreateOrUpdateAircraft(aircraft); 
                return RedirectToAction(nameof(Index));
            }
            return View(aircraft);
        }



        public IActionResult Delete(string id)
        {
            var aircraft = _aircraftService.GetAircraftById(id);
            if (aircraft == null)
            {
                return NotFound();
            }
            return View(aircraft);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            _aircraftService.RemoveAircraft(id);
            return RedirectToAction(nameof(Index));
        }
    }
}