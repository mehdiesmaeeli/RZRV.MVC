using Microsoft.AspNetCore.Identity;

namespace RZRV.APP.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string AvatarPath { get; set; }
    }
}
