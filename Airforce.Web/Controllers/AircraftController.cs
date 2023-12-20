using Microsoft.AspNetCore.Mvc;
using Alesik.Haidov.Airforce.Web.Services;
using Alesik.Haidov.Airforce.Web.Models;

namespace Alesik.Haidov.Airforce.Web.Controllers
{
    public class AircraftController : Controller
    {
        private readonly AircraftService _aircraftService;

        public AircraftController(AircraftService aircraftService)
        {
            _aircraftService = aircraftService;
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

        public IActionResult Create()
        {
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

        public IActionResult Edit(string id)
        {
            var aircraft = _aircraftService.GetAircraftById(id);
            if (aircraft == null)
            {
                return NotFound();
            }
            return View(aircraft);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Aircraft aircraft)
        {
            if (id != aircraft.GUID)
            {
                return NotFound();
            }

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