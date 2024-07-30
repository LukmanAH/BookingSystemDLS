using BookingSystemDLS.Provider;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemDLS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private MenuProvider menuProvider;
        public MenuController(MenuProvider menuProvider)
        {
            this.menuProvider = menuProvider;
        }

        [HttpGet]
        public ActionResult getAll()
        {
            try
            {
                return Ok(menuProvider.getAllMenu());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
