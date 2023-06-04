using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.GetUserCourse
{
    public class GetUserCourseEndpoint: Endpoint<GetUserCourseRequest, GetUserCourseResponse, GetUserCourseMapper>
    {
        public override void Configure()
        {
            Get("courses/owned/{id}");
        }

        private readonly CourseDbContext courseDbContext;

        public GetUserCourseEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(GetUserCourseRequest req, CancellationToken ct)
        {
            Course? course = courseDbContext.Courses.Where(x => x.Id == req.Id && x.UserId == req.UserId && !x.IsDeleted).FirstOrDefault();
            if (course == null)
            {
                await SendErrorsAsync(400, ct);
                return;
            }
            Response = Map.FromEntity(course);
            await SendOkAsync(Response, ct);
        }
    }
}
