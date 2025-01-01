namespace RZRV.APP.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
        private readonly long maxFileSize = 5 * 1024 * 1024; // 5MB
        private readonly string uploadDirectory = "wwwroot/uploads/avatars";

        public async Task<string> UploadUserAvatar(IFormFile file, string userId)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("No file uploaded");

            if (file.Length > maxFileSize)
                throw new ArgumentException("File size exceeds limit");

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(extension))
                throw new ArgumentException("Invalid file type");

            var fileName = $"{userId}_{DateTime.UtcNow.Ticks}{extension}";
            var filePath = Path.Combine(uploadDirectory, fileName);

            Directory.CreateDirectory(uploadDirectory);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public void DeleteUserAvatar(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return;

            var filePath = Path.Combine(uploadDirectory, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }


        Task<bool> IFileUploadService.ValidateFile(IFormFile file)
        {
            throw new NotImplementedException();
        }

        Task<string> IFileUploadService.GetFileUrl(string fileName)
        {
            throw new NotImplementedException();
        }

        Task<byte[]> IFileUploadService.GetFileBytes(string fileName)
        {
            throw new NotImplementedException();
        }

        Task<bool> IFileUploadService.FileExists(string fileName)
        {
            throw new NotImplementedException();
        }
    }

}
