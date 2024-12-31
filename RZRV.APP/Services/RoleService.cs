using Microsoft.AspNetCore.Identity;
using RZRV.APP.AppConfig;

namespace RZRV.APP.Services
{
    public class RoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task EnsureRolesCreated()
        {
            string[] roles = { SystemRoles.Admin, SystemRoles.Store, SystemRoles.Provider };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }

}
