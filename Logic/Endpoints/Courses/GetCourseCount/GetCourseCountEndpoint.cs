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
            int userId = -1;
            int count = -1;
            try
            {
                userId = Convert.ToInt32(User.Claims.Where(x => x.Type == "UserId").First().Value);
                courseDbContext.Courses
                    .Take(req.Take).Skip(req.Skip)
                    .Where(x => x.UserId == userId && !x.IsDeleted)
                    .Where(x => Regex.IsMatch(x.Name.ToLower(), $@"^.*({Regex.Escape(req.Phrase.ToLower())}).*$")).Count();
            }
            catch
            {
                count = courseDbContext.Courses
                    .Where(x => !x.IsHidden && !x.IsDeleted)
                    .Where(x => Regex.IsMatch(x.Name.ToLower(), $@"^.*({Regex.Escape(req.Phrase.ToLower())}).*$")).Count();
            }

            Response = new GetCourseCountResponse { Count = count };
            await SendOkAsync(Response, ct);
        }
    }
}