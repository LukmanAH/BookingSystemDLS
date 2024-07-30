using BookingSystemDLS.DataModel.Master.BookingCode;
using BookingSystemDLS.Provider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BookingSystemDLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingCodeController : ControllerBase
    {
        private BookingCodeProvider BCProvider;
        public BookingCodeController(BookingCodeProvider BCProvider)
        {
            this.BCProvider = BCProvider;
        }

        [HttpGet]
        public ActionResult getAll() 
        {
            try 
            {
            return Ok(BCProvider.getAll());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult getSingle(int id) {
            try 
            { 
                return Ok(BCProvider.getSingle(id));
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        
        [HttpPost]
        public ActionResult upsert(UpsertBCVM model)
        {
            try
            {
                if (model.Id == 0)
                {
                    BCProvider.insert(model);
                }
                else
                {
                    BCProvider.update(model);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                BCProvider.delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
