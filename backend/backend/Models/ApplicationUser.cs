using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int CansOwned { get; set; }
        public int TotalMeters { get; set; }
    }
}
