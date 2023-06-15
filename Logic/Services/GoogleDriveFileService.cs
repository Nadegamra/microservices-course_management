using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MimeTypes;

namespace CourseManagement.Services
{
    public class GoogleDriveFileService : IFileService
    {
        public IFormFile DownloadFile(string fileId)
        {
            string[] scopes = new string[] { DriveService.Scope.DriveFile };

            var stream = new FileStream("key.json", FileMode.Open, FileAccess.Read);

            var credential = GoogleCredential.FromStream(stream);
            credential = credential.CreateScoped(scopes);

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "OLP",
            });

            var metadata = service.Files.Get(fileId).Execute();
            var name = metadata.Name;

            var memoryStream = new MemoryStream();
            var request = service.Files.Get(fileId);
            request.Fields = "Name";
            request.Download(memoryStream);

            FormFile formFile = new FormFile(
                baseStream: memoryStream,
                baseStreamOffset: 0,
                length: memoryStream.Length,
                name: $"${name}.${MimeTypeMap.GetExtension(metadata.MimeType)}",
                fileName: $"{name}.{MimeTypeMap.GetExtension(metadata.MimeType)}")
            {
                Headers = new HeaderDictionary()
            };
            formFile.ContentType = metadata.MimeType;
            return formFile;
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            string[] scopes = new string[] { DriveService.Scope.DriveFile };

            var stream = new FileStream("key.json", FileMode.Open, FileAccess.Read);

            var credential = GoogleCredential.FromStream(stream);
            credential = credential.CreateScoped(scopes);

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "OLP",
            });

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = file.Name,
            };

            var request = service.Files.Create(fileMetadata, file.OpenReadStream(), file.ContentType);
            request.Fields = "id";
            var progress = request.Upload();

            var response = request.ResponseBody;
            return response.Id;
        }
    }
}
