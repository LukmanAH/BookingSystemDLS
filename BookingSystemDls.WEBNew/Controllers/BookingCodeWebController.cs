using BookingSystemDLS.DataModel.Master.BookingCode;
using BookingSystemDLS.DataModel.Master.Menu;
using BookingSystemDLS.Provider;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Text.Json;

namespace BookingSystemDLS.WEB.Controllers
{
    [Route("BookingCode")]
    public class BookingCodeWebController : Controller
    {
        private readonly BookingCodeProvider _bookingCodeProvider;

        public BookingCodeWebController(BookingCodeProvider provider)
        {
            _bookingCodeProvider = provider;
        }

        public IActionResult Index() 
        {
            var bookingCodes = _bookingCodeProvider.getAll();

            return View("BookingCode-Index", bookingCodes);
        }

        [HttpGet("Add")]
        public IActionResult addForm()
        {
            var bookingCode = new GridBCVM();
            bookingCode.Id = 0;

            return View("BookingCode-Upsert", bookingCode);
        }


        [HttpGet("Edit/{id}")]
        public IActionResult EditForm(int id) 
        {
            
           var bookingCode = _bookingCodeProvider.getSingle(id);
            

            return View("BookingCode-Upsert", bookingCode);
        } 


        [HttpPost("Upsert")]
        public IActionResult Upsert(UpsertBCVM model)
        { 

            if (model.Id == 0)
            {
                _bookingCodeProvider.insert(model);
            }
            else
            {
                _bookingCodeProvider.update(model);
            }

            return RedirectToAction("Index");
        }


        [HttpPost("Delete")]
        public IActionResult Delete(int id) {
            _bookingCodeProvider.delete(id);

            return RedirectToAction("Index");
        }
    }
}
