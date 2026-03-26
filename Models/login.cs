using System.ComponentModel.DataAnnotations;

namespace collegemainatanceportal.Models
{
    public class Login
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
