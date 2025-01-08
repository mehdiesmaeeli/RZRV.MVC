using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RZRV.APP.Data;
using RZRV.APP.Models;
using RZRV.APP.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RZRV.APP.ViewComponents
{
    public class ChatViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        // اینجا می‌توانید سرویس‌های مورد نیاز را inject کنید
        public ChatViewComponent(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var users = await _userManager.Users.Where(x => x.Id != currentUserId).ToListAsync();
            // اینجا لاجیک لازم برای دریافت اطلاعات چت را قرار دهید
            var chatViewModel = new ChatViewModel { Users = users, CurrentUserId = currentUserId };

            return View(chatViewModel);
        }
    }
}