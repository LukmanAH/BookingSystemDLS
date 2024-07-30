using BookingSystemDLS.Provider;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemDLS.WEB.Controllers
{
    [Route("Menu")]
    public class MenuWebController : Controller
    {
        
        private readonly MenuProvider _MenuProvider;

        public MenuWebController(MenuProvider menuProvider)
        {
            _MenuProvider = menuProvider;
        }

        public IActionResult Index()
        {
            var menu = _MenuProvider.getNestedMenu();

            return View("Menu-Index", menu);
        }
    }
}
