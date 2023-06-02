using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.CreateCourse
{
    public class CreateCourseEndpoint: Endpoint<CreateCourseRequest, CreateCourseResponse, CreateCourseMapper>
    {
        public override void Configure()
        {
            Post("courses");
            Roles("CREATOR");
        }

        private readonly CourseDbContext courseDbContext;

        public CreateCourseEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(CreateCourseRequest req, CancellationToken ct)
        {
            Course course = Map.ToEntity(req);

            var res = courseDbContext.Courses.Add(course);
            courseDbContext.SaveChanges();

            Response = Map.FromEntity(res.Entity);
            await SendOkAsync(Response);
        }
    }
}
