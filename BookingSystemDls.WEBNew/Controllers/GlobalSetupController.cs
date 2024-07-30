using BookingSystemDLS.DataModel.Master.Room;
using BookingSystemDLS.DataModel.Master.Menu;
using BookingSystemDLS.Provider;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Text.Json;
using BookingSystemDLS.WEB.Models.Room;
using BookingSystemDLS.DataModel.Master.GlobalSetup;

namespace BookingSystemDLS.WEB.Controllers
{
    [Route("GlobalSetup")]
    public class GlobalSetupWebController : Controller
    {
        private readonly GlobalSetupProvider _GlobalSetupProvider;

        public GlobalSetupWebController(GlobalSetupProvider globalSetupProvider)
        {
            _GlobalSetupProvider = globalSetupProvider;
        }

        public IActionResult Index()
        {
            var globalSetup = _GlobalSetupProvider.getAll();

            return View("GlobalSetup-Index", globalSetup);
        }

        [HttpGet("Add")]
        public IActionResult addForm()
        {
            var globalSetup = new GridGlobalSetupVM();

            return View("GlobalSetup-Upsert", globalSetup);
        }


        [HttpGet("Edit/{id}")]
        public IActionResult EditForm(string id) 
        {
            var globalSetup = _GlobalSetupProvider.getSingle(id);

            return View("GlobalSetup-Upsert", globalSetup);
        }


        [HttpPost("Upsert")]
        public IActionResult Upsert(UpsertGlobalSetupVM model)
        {


            _GlobalSetupProvider.update(model);

            return RedirectToAction("Index");
        }


        [HttpPost("Delete")]
        public IActionResult Delete(string code) {
            _GlobalSetupProvider.delete(code);

            return RedirectToAction("Index");
        }
    }
}
