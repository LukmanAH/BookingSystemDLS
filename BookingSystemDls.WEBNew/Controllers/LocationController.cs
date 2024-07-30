using BookingSystemDLS.DataModel.Master.Room;
using BookingSystemDLS.DataModel.Master.Menu;
using BookingSystemDLS.Provider;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Text.Json;
using BookingSystemDLS.WEB.Models.Room;
using BookingSystemDLS.DataModel.Master.Location;

namespace BookingSystemDLS.WEB.Controllers
{
    [Route("Location")]
    public class LocationWebController : Controller
    {
        private readonly LocationProvider _LocationProvider;

        public LocationWebController(LocationProvider locationProvider)
        {
            _LocationProvider = locationProvider;
        }

        public IActionResult Index()
        {
            var location = _LocationProvider.getAll();

            return View("Location-Index", location);
        }

        [HttpGet("Add")]
        public IActionResult addForm()
        {
            var location = new GridLocationVM();
            location.Id = 0;

            return View("Location-Upsert", location);
        }


        [HttpGet("Edit/{id}")]
        public IActionResult EditForm(int id) 
        {
            var location = _LocationProvider.getSingle(id);

            return View("Location-Upsert", location);
        }


        [HttpPost("Upsert")]
        public IActionResult Upsert(UpsertLocationVM model)
        {

            if (model.Id == 0)
            {
                _LocationProvider.insert(model);
            }
            else
            {
                _LocationProvider.update(model);
            }

            return RedirectToAction("Index");
        }


        [HttpPost("Delete")]
        public IActionResult Delete(int id) {
            _LocationProvider.delete(id);

            return RedirectToAction("Index");
        }
    }
}
