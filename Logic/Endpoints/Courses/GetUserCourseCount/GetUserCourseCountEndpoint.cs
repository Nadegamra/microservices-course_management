using System.Text.RegularExpressions;
using CourseManagement.Data;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.GetUserCourseCount
{
    public class GetUserCourseCountEndpoint : Endpoint<GetUserCourseCountRequest, GetUserCourseCountResponse>
    {
        public override void Configure()
        {
            Get("courses/owned/count");
            Roles("ADMIN", "CREATOR");
        }

        private readonly CourseDbContext courseDbContext;

        public GetUserCourseCountEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(GetUserCourseCountRequest req, CancellationToken ct)
        {
            int count = courseDbContext.Courses
            .Take(req.Take).Skip(req.Skip)
            .Where(x => x.UserId == req.UserId && !x.IsDeleted)
            .Where(x => Regex.IsMatch(x.Name.ToLower(), $@"^.*({Regex.Escape(req.Phrase.ToLower())}).*$")).Count();
            Response = new GetUserCourseCountResponse { Count = count };
            await SendOkAsync(Response, ct);
        }
    }
}