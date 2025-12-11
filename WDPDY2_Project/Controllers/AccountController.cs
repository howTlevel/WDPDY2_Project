using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WDPDY2_Project.Models;
using Microsoft.Extensions.Configuration;

using Microsoft.Data.SqlClient;

namespace WDPDY2_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly string _connectionString;

        public AccountController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("", "Passwords do not match.");
                    return View(model);
                }

                string query = "INSERT INTO [Users] (Username, Password) VALUES (@Username, @Password)";

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", model.Username);
                        cmd.Parameters.AddWithValue("@Password", model.Password);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            return RedirectToAction("Login");
                        }
                        catch
                        {
                            ModelState.AddModelError("", "Registration failed. Please try again.");
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                string query = "SELECT COUNT(*) FROM [Users] WHERE Username = @Username AND Password = @Password";

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", model.Username);
                        cmd.Parameters.AddWithValue("@Password", model.Password);

                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            return RedirectToAction("Profile", "Account");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Invalid username or password.");
                        }
                    }
                }
            }
            return View(model);
        }

        public IActionResult Profile()
        {
            return View();
        }

    }
}
