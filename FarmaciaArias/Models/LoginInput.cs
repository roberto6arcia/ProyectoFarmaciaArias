using System.ComponentModel.DataAnnotations;

namespace FarmaciaArias.Models
{
    public class LoginInputModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        
    }
    public class LoginViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }   
}