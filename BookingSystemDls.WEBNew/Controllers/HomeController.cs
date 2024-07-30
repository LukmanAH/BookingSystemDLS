
using BookingSystemDLS.DataModel.Master.Menu;
using BookingSystemDLS.Provider;
using BookingSystemDLS.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace BookingSystemDLS.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly MenuProvider menuProvider;

        public HomeController(MenuProvider menuProvider)
        {
            this.menuProvider = menuProvider;
        }

        public async Task<IActionResult> Index()
        {
           var menus = menuProvider.getAllMenu();
           
            return View(menus);

        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
