using System.ComponentModel.DataAnnotations;

namespace BookStore.Server.Features.Identity.Models
{
    public class LoginRequestModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
