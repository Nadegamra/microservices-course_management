using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.DeleteCourse
{
    public class DeleteCourseEndpoint : Endpoint<DeleteCourseRequest, EmptyResponse>
    {
        public override void Configure()
        {
            Delete("courses/{id}");
            Roles("ADMIN", "CREATOR");
        }

        private readonly CourseDbContext courseDbContext;

        public DeleteCourseEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(DeleteCourseRequest req, CancellationToken ct)
        {
            Course? course = courseDbContext.Courses.Where(x => x.Id == req.Id).FirstOrDefault();
            if (course == null || course.UserId != req.UserId)
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            course.IsDeleted = true;
            courseDbContext.Courses.Update(course);
            courseDbContext.SaveChanges();
            await SendOkAsync(ct);
        }
    }
}
