using System.Security.Claims;
using System.Text.RegularExpressions;
using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
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

        private readonly IRepository<Course> repository;

        public GetCourseCountEndpoint(IRepository<Course> repository)
        {
            this.repository = repository;
        }

        public async override Task HandleAsync(GetCourseCountRequest req, CancellationToken ct)
        {
            Claim? claim = User.Claims.Where(x => x.Type == "UserId").FirstOrDefault();
            int? userId = claim != null ? int.Parse(claim.Value) : null;

            int count = repository.GetAll()
                            .Where(x => !x.IsDeleted && (x.UserId == (userId ?? -1) || !x.IsHidden))
                            .Where(x => Regex.IsMatch(x.Name.ToLower(), $@"^.*({Regex.Escape(req.Phrase.ToLower())}).*$"))
                            .Count();

            Response = new GetCourseCountResponse { Count = count };
            await SendOkAsync(Response, ct);
        }
    }
}