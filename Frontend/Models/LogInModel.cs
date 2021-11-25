using System.ComponentModel.DataAnnotations;

namespace Dagnys_bageri.Models
{
    public class LogInModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
