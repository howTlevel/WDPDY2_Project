using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WDPDY2_Project.Models;

namespace WDPDY2_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Marcell()
        {
            return View();
        }
        public IActionResult Nivi()
        {
            return View();
        }
        public IActionResult Georgi()
        {
            return View();
        }

        public IActionResult Kenz()
        {
            return View();
        }
        public IActionResult Evin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
