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

        [HttpGet]
        public IActionResult GetAvatar(string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "avatars", fileName);

            if (!System.IO.File.Exists(path))
            {
                return File("~/images/default-avatar.png", "image/png");
            }

            var mime = GetMimeType(path);
            var fileStream = System.IO.File.OpenRead(path);
            return File(fileStream, mime);
        }

        private string GetMimeType(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                _ => "application/octet-stream"
            };
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

                return Ok(new { success = true, avatarUrl = Url.Action("GetAvatar", "User", new { fileName = fileName }) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }

}
