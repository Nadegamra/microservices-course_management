using CourseManagement.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Endpoints.Courses.GetCourseList
{
    public class GetCourseListEndpoint : EndpointWithoutRequest<GetCourseListResponse[], GetCourseListMapper>
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
            Course[] courses = courseDbContext.Courses.Include(x => x.Requirements).Include(x => x.GainedSkills).Include(x => x.Languages).Include(x => x.Subtitles).Where(x => !x.IsHidden && !x.IsDeleted).ToArray();
            Response = Map.FromEntity(courses);
            await SendOkAsync(Response, ct);
        }
    }
}
