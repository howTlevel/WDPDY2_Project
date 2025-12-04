using System.ComponentModel.DataAnnotations;

namespace WDPDY2_Project.Models
{
    // LoginModel.cs
    public class LoginModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }

}
