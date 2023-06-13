using CourseManagement.Services;
using FastEndpoints;

namespace CourseManagement.Endpoints.Images.GetCourseImage
{
    public class GetCourseImageEndpoint: Endpoint<GetCourseImageRequest>
    {
        public override void Configure()
        {
            Get("courses/{courseId}/images/{imageId}");
            AllowAnonymous();
        }

        private readonly CourseDbContext courseDbContext;
        private readonly IFileService fileService;

        public GetCourseImageEndpoint(CourseDbContext courseDbContext, IFileService fileService)
        {
            this.courseDbContext = courseDbContext;
            this.fileService = fileService;
        }

        public override async Task HandleAsync(GetCourseImageRequest req, CancellationToken ct)
        {
            IFormFile file = fileService.DownloadFile(req.ImageId);

            await SendStreamAsync(file.OpenReadStream(),fileName: file.FileName);
        }
    }
}
