using System.Text.RegularExpressions;
using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Logic.Endpoints.Courses.GetCourseList
{
    public class GetCourseListEndpoint : Endpoint<GetCourseListRequest, GetCourseListResponse, GetCourseListMapper>
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

        public override async Task HandleAsync(GetCourseListRequest req, CancellationToken ct)
        {
            Course[] courses = courseDbContext.Courses
                .Include(x => x.Requirements).Include(x => x.GainedSkills)
                .Include(x => x.Languages).Include(x => x.Subtitles)
                .Take(req.Take).Skip(req.Skip)
                .Where(x => !x.IsHidden && !x.IsDeleted)
                .Where(x => Regex.IsMatch(x.Name.ToLower(), $@"^.*({Regex.Escape(req.Phrase.ToLower())}).*$")).ToArray();
            Response = Map.FromEntity(courses);
            await SendOkAsync(Response, ct);
        }
    }
}
