using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.CreateCourse
{
    public class CreateCourseEndpoint : EndpointExtended<CreateCourseRequest, CreateCourseResponse, CreateCourseMapper>
    {
        public override void Configure()
        {
            ConfigureEndpoint("createCourse");
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
