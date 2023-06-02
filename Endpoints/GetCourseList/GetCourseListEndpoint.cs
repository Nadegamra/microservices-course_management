using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.GetCourseList
{
    public class GetCourseListEndpoint: EndpointWithoutRequest<GetCourseListResponse[], GetCourseListMapper>
    {
        public override void Configure()
        {
            Get("courses");
            AllowAnonymous();
        }

        private readonly CourseDbContext courseDbContext;

        public GetCourseListEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            Course[] courses = courseDbContext.Courses.Where(x => !x.IsHidden && !x.IsDeleted).ToArray();
            Response = Map.FromEntity(courses);
            await SendOkAsync(Response, ct);
        }
    }
}
