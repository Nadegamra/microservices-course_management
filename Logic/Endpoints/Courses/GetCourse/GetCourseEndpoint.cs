using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;
using Infrastructure.Routes;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Logic.Endpoints.Courses.GetCourse
{
    public class GetCourseEndpoint : Endpoint<GetCourseRequest, GetCourseResponse, GetCourseMapper>
    {
        public override void Configure()
        {
            Get("courses/{id}");
            AllowAnonymous();
        }

        private readonly CourseDbContext courseDbContext;

        public GetCourseEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(GetCourseRequest req, CancellationToken ct)
        {
            Course? course = courseDbContext.Courses.Include(x => x.Requirements).Include(x => x.GainedSkills).Include(x => x.Languages).Include(x => x.Subtitles).Where(x => x.Id == req.Id && !x.IsHidden && !x.IsDeleted).FirstOrDefault();
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
