using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using CourseManagement.Services;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Images.AddCourseImage
{
    public class SetCourseImageEndpoint : Endpoint<SetCourseImageRequest>
    {
        public override void Configure()
        {
            Put("courses/{courseId}/image");
            Roles("ADMIN", "CREATOR");
            AllowFileUploads();
        }

        private readonly IRepository<Course> repository;
        private readonly IFileService fileService;

        public SetCourseImageEndpoint(IFileService fileService, IRepository<Course> repository)
        {
            this.fileService = fileService;
            this.repository = repository;
        }

        public override async Task HandleAsync(SetCourseImageRequest req, CancellationToken ct)
        {
            Course? course = repository.GetAll().Where(x => x.Id == req.CourseId && x.UserId == req.UserId).FirstOrDefault();
            string imageId;
            if (course == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            if (course.ImageId.Length == 0)
            {
                imageId = await fileService.UploadFile(req.Image);

                course.ImageId = imageId;
                repository.Update(course);
            }
            else
            {
                var task1 = fileService.UploadFile(req.Image);
                var task2 = fileService.DeleteFile(course.ImageId);

                course.ImageId = await task1;
                repository.Update(course);

                await task2;
            }
            await SendNoContentAsync(ct);
        }
    }
}