using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Server.Data.Models
{
    [Table("AspNetUsers")]
    public class User : IdentityUser
    {
    }
}
