using Microsoft.AspNetCore.Identity;

namespace Profile.Identity.Models
{
    public class AppUser : IdentityUser
    {
        public string Email { get; set; }
    }
}
