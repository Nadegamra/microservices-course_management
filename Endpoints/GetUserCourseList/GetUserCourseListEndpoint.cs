using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.GetUserCourseList
{
    public class GetUserCourseListEndpoint: Endpoint<GetUserCourseListRequest, GetUserCourseListResponse[], GetUserCourseListMapper>
    {
        public override void Configure()
        {
            base.Configure();
        }

        private readonly CourseDbContext courseDbContext;

        public GetUserCourseListEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(GetUserCourseListRequest req, CancellationToken ct)
        {
            Course[] courses = courseDbContext.Courses.Where(x => x.UserId == req.UserId && !x.IsDeleted).ToArray();
            Response = Map.FromEntity(courses);
            await SendOkAsync(Response, ct);
        }
    }
}
