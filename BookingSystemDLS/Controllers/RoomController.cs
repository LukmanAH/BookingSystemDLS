using BookingSystemDLS.DataModel.Master.BookingCode;
using BookingSystemDLS.DataModel.Master.Room;
using BookingSystemDLS.Provider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemDLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private RoomProvider RoomProvider;
        public RoomController(RoomProvider RoomProvider)
        {
            this.RoomProvider = RoomProvider;
        }

        [HttpGet]
        public ActionResult getAll()
        {
            try
            {   
                return Ok(RoomProvider.getAll());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult getSingle(int id)
        {
            try
            {
                return Ok(RoomProvider.getSingle(id));
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult upsert(UpsertRoomVM model)
        {
            try
            {
                if (model.Id == 0)
                {
                    RoomProvider.insert(model);
                }
                else
                {
                    RoomProvider.update(model);
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
                RoomProvider.delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

    }
}
