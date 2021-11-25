using System.ComponentModel.DataAnnotations;

namespace Dagnys_bageri.Models
{
    public class LogInModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
