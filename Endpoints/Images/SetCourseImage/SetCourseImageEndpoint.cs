using CourseManagement.Models;
using CourseManagement.Services;
using FastEndpoints;

namespace CourseManagement.Endpoints.Images.AddCourseImage
{
    public class SetCourseImageEndpoint: Endpoint<SetCourseImageRequest>
    {
        public override void Configure()
        {
            Put("courses/{courseId}/images");
            AllowFileUploads();
        }

        private readonly CourseDbContext courseDbContext;
        private readonly IFileService fileService;

        public SetCourseImageEndpoint(CourseDbContext courseDbContext, IFileService fileService)
        {
            this.courseDbContext = courseDbContext;
            this.fileService = fileService;
        }

        public override async Task HandleAsync(SetCourseImageRequest req, CancellationToken ct)
        {
            Course? course = courseDbContext.Courses.Where(x=>x.Id == req.CourseId && x.UserId == req.UserId).FirstOrDefault();
            if (course == null)
            {
                await SendErrorsAsync(400, ct);
                return;
            }
            string imageId = await fileService.UploadFile(req.Image); 
            course.ImageId = imageId;
            courseDbContext.Courses.Update(course);
            courseDbContext.SaveChanges();
            await SendOkAsync(ct);
        }
    }
}
