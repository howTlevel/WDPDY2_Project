using Microsoft.AspNetCore.Mvc;

namespace WDPDY2_Project.Models
{
    // RegisterModel.cs
    public class RegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

}