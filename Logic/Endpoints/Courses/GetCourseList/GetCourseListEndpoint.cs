using System.Security.Claims;
using System.Text.RegularExpressions;
using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.GetCourseList
{
    public class GetCourseListEndpoint : Endpoint<GetCourseListRequest, List<GetCourseListResponse>, GetCourseListMapper>
    {
        public override void Configure()
        {
            Get("courses");
            AllowAnonymous();
        }

        private readonly IRepository<Course> repository;

        public GetCourseListEndpoint(IRepository<Course> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(GetCourseListRequest req, CancellationToken ct)
        {
            Claim? claim = User.Claims.Where(x => x.Type == "UserId").First();
            int? userId = claim != null ? int.Parse(claim.Value) : null;
            Course[] courses = repository.GetAll()
                    .Take(req.Take).Skip(req.Skip)
                    .Where(x => !x.IsDeleted && (x.UserId == userId || !x.IsHidden))
                    .Where(x => Regex.IsMatch(x.Name.ToLower(), $@"^.*({Regex.Escape(req.Phrase.ToLower())}).*$"))
                    .ToArray();

            Response = Map.FromEntity(courses);
            await SendOkAsync(Response, ct);
        }
    }
}
