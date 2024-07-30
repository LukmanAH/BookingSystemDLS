using BookingSystemDLS.DataModel.Master.Room;
using BookingSystemDLS.DataModel.Master.Menu;
using BookingSystemDLS.Provider;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Text.Json;
using BookingSystemDLS.WEB.Models.Room;

namespace BookingSystemDLS.WEB.Controllers
{
    [Route("Room")]
    public class RoomWebController : Controller
    {
        private readonly RoomProvider _RoomProvider;
        private readonly LocationProvider _LocationProvider;

        public RoomWebController(RoomProvider provider, LocationProvider locationProvider)
        {
            _RoomProvider = provider;
            _LocationProvider = locationProvider;
        }

        public IActionResult Index()
        {
            var Rooms = _RoomProvider.getAll();

            return View("Room-Index", Rooms);
        }

        [HttpGet("Add")]
        public IActionResult addForm()
        {
            var Room = new GridRoomVM();
            var locationLoV = _LocationProvider.getLOV();
            Room.Id = 0;

            var model = new UpsertRoomWebVM();
            model.Room = Room;
            model.LocationLoV = locationLoV;

            return View("Room-Upsert", model);
        }


        [HttpGet("Edit/{id}")]
        public IActionResult EditForm(int id) 
        {
            
           var Room = _RoomProvider.getSingle(id);
           var locationLoV = _LocationProvider.getLOV();
           
            var model = new UpsertRoomWebVM();
            model.Room = Room;
            model.LocationLoV = locationLoV;

            return View("Room-Upsert", model);
        }


        [HttpPost("Upsert")]
        public IActionResult Upsert(UpsertRoomVM model)
        {

            if (model.Id == 0)
            {
                _RoomProvider.insert(model);
            }
            else
            {
                _RoomProvider.update(model);
            }

            return RedirectToAction("Index");
        }


        [HttpPost("Delete")]
        public IActionResult Delete(int id) {
            _RoomProvider.delete(id);

            return RedirectToAction("Index");
        }
    }
}
