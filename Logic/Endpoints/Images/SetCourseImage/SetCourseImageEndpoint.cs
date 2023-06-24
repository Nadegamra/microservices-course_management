using CourseManagement.Data;
using CourseManagement.Data.Models;
using CourseManagement.Services;
using Infrastructure.Routes;

namespace CourseManagement.Logic.Endpoints.Images.AddCourseImage
{
    public class SetCourseImageEndpoint : EndpointExtended<SetCourseImageRequest>
    {
        public override void Configure()
        {
            ConfigureEndpoint("setImage");
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
            Course? course = courseDbContext.Courses.Where(x => x.Id == req.CourseId && x.UserId == req.UserId).FirstOrDefault();
            string imageId;
            if (course == null)
            {
                await SendErrorsAsync(400, ct);
                return;
            }
            if (course.ImageId.Length == 0)
            {
                imageId = await fileService.UploadFile(req.Image);

                course.ImageId = imageId;
                courseDbContext.Courses.Update(course);
                courseDbContext.SaveChanges();
            }
            else
            {
                var task1 = fileService.UploadFile(req.Image);
                var task2 = fileService.DeleteFile(course.ImageId);

                course.ImageId = await task1;
                courseDbContext.Courses.Update(course);
                courseDbContext.SaveChanges();

                await task2;
            }
            await SendOkAsync(ct);
        }
    }
}