namespace RZRV.APP.Services
{
    public interface IFileUploadService
    {
        Task<string> UploadUserAvatar(IFormFile file, string userId);
        void DeleteUserAvatar(string fileName);

        // Additional useful methods
        Task<bool> ValidateFile(IFormFile file);
        Task<string> GetFileUrl(string fileName);
        Task<byte[]> GetFileBytes(string fileName);
        Task<bool> FileExists(string fileName);
    }

}
