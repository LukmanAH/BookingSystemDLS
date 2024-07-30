using BookingSystemDLS.Provider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemDLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private LocationProvider LocationProvider;
        public LocationController(LocationProvider LocationProvider)
        {
            this.LocationProvider = LocationProvider;
        }

        [HttpGet("/lov")]
        public ActionResult getLov()
        {
            try
            {
                return Ok(LocationProvider.getLOV());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
