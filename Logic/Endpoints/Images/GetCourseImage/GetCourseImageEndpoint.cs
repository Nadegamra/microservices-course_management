using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using CourseManagement.Services;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Images.GetCourseImage
{
    public class GetCourseImageEndpoint : Endpoint<GetCourseImageRequest>
    {
        public override void Configure()
        {
            Get("courses/{courseId}/image");
            AllowAnonymous();
            Options(x => x.CacheOutput(p => p.Expire(TimeSpan.FromHours(2))));
        }

        private readonly IRepository<Course> repository;
        private readonly IFileService fileService;

        public GetCourseImageEndpoint(IFileService fileService, IRepository<Course> repository)
        {
            this.fileService = fileService;
            this.repository = repository;
        }

        public override async Task HandleAsync(GetCourseImageRequest req, CancellationToken ct)
        {
            Course? course = repository.Get(req.CourseId);
            if (course == null || course.ImageId.Length == 0)
            {
                await SendErrorsAsync(400, ct);
                return;
            }
            try
            {
                IFormFile file = fileService.DownloadFile(course.ImageId);

                await SendStreamAsync(file.OpenReadStream(), fileName: file.FileName, cancellation: ct);
            }
            catch
            {
                await SendNotFoundAsync(ct);
            }
        }
    }
}
