using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Logic.Endpoints.Courses.GetCourseList
{
    public class GetCourseListEndpoint : EndpointExtended<EmptyRequest, GetCourseListResponse[], GetCourseListMapper>
    {
        public override void Configure()
        {
            ConfigureEndpoint("courseList");
        }

        private readonly CourseDbContext courseDbContext;

        public GetCourseListEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
        {
            Course[] courses = courseDbContext.Courses.Include(x => x.Requirements).Include(x => x.GainedSkills).Include(x => x.Languages).Include(x => x.Subtitles).Where(x => !x.IsHidden && !x.IsDeleted).ToArray();
            Response = Map.FromEntity(courses);
            await SendOkAsync(Response, ct);
        }
    }
}
