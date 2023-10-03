using System.Text.RegularExpressions;
using CourseManagement.Data;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.GetCourseCount
{
    public class GetCourseCountEndpoint : Endpoint<GetCourseCountRequest, GetCourseCountResponse>
    {
        public override void Configure()
        {
            Get("courses/count");
            AllowAnonymous();
        }

        private readonly CourseDbContext courseDbContext;

        public GetCourseCountEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public async override Task HandleAsync(GetCourseCountRequest req, CancellationToken ct)
        {
            int count = courseDbContext.Courses
                .Where(x => !x.IsHidden && !x.IsDeleted)
                .Where(x => Regex.IsMatch(x.Name.ToLower(), $@"^.*({Regex.Escape(req.Phrase.ToLower())}).*$")).Count();
            Response = new GetCourseCountResponse { Count = count };
            await SendOkAsync(Response, ct);
        }
    }
}