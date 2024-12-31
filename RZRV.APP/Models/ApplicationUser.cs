using Microsoft.AspNetCore.Identity;

namespace RZRV.APP.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Phone { get; set; }
    }
}
