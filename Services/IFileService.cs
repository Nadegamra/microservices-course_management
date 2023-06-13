namespace CourseManagement.Services
{
    public interface IFileService
    {
        public Task<string> UploadFile(IFormFile file);

        public IFormFile DownloadFile(string fileId);
    }
}
