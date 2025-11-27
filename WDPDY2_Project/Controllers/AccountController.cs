using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WDPDY2_Project.Models;

namespace WDPDY2_Project.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }

    }
}
