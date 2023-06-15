using CourseManagement.Data;
using CourseManagement.Services;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Images.GetCourseImage
{
    public class GetCourseImageEndpoint : EndpointExtended<GetCourseImageRequest>
    {
        public override void Configure()
        {
            ConfigureEndpoint("getImage");
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

            await SendStreamAsync(file.OpenReadStream(), fileName: file.FileName);
        }
    }
}
