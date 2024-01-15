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

            ViewData["Types"] = Enum.GetValues(typeof(AircraftType));
            ViewBag.Airbases = new SelectList(_airbaseService.GetAllAirbases(), "GUID", "Name");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Aircraft aircraft)
        {
            if (aircraft != null)
            {
                if (!string.IsNullOrEmpty(aircraft.AirbaseGUID))
                {
                    aircraft.Airbase = _airbaseService.GetAirbaseById(aircraft.AirbaseGUID);
                }

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

            aircraft.AirbaseGUID = aircraft.Airbase?.GUID;

            ViewData["Types"] = Enum.GetValues(typeof(AircraftType));
            ViewBag.Airbases = new SelectList(_airbaseService.GetAllAirbases(), "GUID", "Name");

            return View(aircraft);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Aircraft aircraft)
        {
            if (aircraft != null)
            {
                if (!string.IsNullOrEmpty(aircraft.AirbaseGUID))
                {
                    aircraft.Airbase = _airbaseService.GetAirbaseById(aircraft.AirbaseGUID);
                }

                _aircraftService.CreateOrUpdateAircraft(aircraft);
                return RedirectToAction(nameof(Index));
            }
            return View(aircraft);
        }




        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var aircraft = _aircraftService.GetAircraftById(id);
            if (aircraft == null)
            {
                return NotFound();
            }

            return View(aircraft);
        }

        // POST: Aircraft/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var aircraft = _aircraftService.GetAircraftById(id);
            if (aircraft != null)
            {
                _aircraftService.RemoveAircraft(aircraft.GUID);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}