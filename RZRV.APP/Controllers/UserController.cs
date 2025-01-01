using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RZRV.APP.Models;
using RZRV.APP.Services;
using RZRV.APP.ViewModel;

namespace RZRV.APP.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFileUploadService _fileUploadService;

        public UserController(UserManager<ApplicationUser> userManager, IFileUploadService fileUploadService)
        {
            _userManager = userManager;
            _fileUploadService = fileUploadService;
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            var viewModel = new UserProfileViewModel
            {
                Phone = user.UserName,
                AvatarPath = user.AvatarPath
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UploadAvatar(IFormFile avatar)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                if (user.AvatarPath != null)
                {
                    _fileUploadService.DeleteUserAvatar(user.AvatarPath);
                }

                var fileName = await _fileUploadService.UploadUserAvatar(avatar, user.Id);
                user.AvatarPath = fileName;

                await _userManager.UpdateAsync(user);

                return Ok(new { success = true, avatarUrl = $"/uploads/avatars/{fileName}" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }

}
