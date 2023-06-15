using CourseManagement.Data;
using CourseManagement.Data.Models;
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
            Course? course = courseDbContext.Courses.Where(x=>x.Id == req.CourseId).FirstOrDefault();
            if(course == null || course.ImageId.Length == 0)
            {
                await SendErrorsAsync(400, ct);
                return;
            }
            try
            {
                IFormFile file = fileService.DownloadFile(course.ImageId);

                await SendStreamAsync(file.OpenReadStream(), fileName: file.FileName);
            }
            catch (Exception ex)
            {
                await SendNotFoundAsync(ct);
            }
        }
    }
}
