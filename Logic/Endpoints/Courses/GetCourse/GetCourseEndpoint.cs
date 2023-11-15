using System.Security.Claims;
using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Courses.GetCourse
{
    public class GetCourseEndpoint : Endpoint<GetCourseRequest, GetCourseResponse, GetCourseMapper>
    {
        public override void Configure()
        {
            Get("courses/{id}");
            AllowAnonymous();
        }

        private readonly IRepository<Course> repository;

        public GetCourseEndpoint(IRepository<Course> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(GetCourseRequest req, CancellationToken ct)
        {
            Claim? claim = User.Claims.Where(x => x.Type == "UserId").FirstOrDefault();
            int? userId = claim != null ? int.Parse(claim.Value) : null;
            Course? course = repository.GetAll()
                            .Where(x => x.Id == req.Id && !x.IsDeleted && (x.UserId == (userId ?? -1) || !x.IsHidden))
                            .FirstOrDefault();

            if (course == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            Response = Map.FromEntity(course);
            await SendOkAsync(Response, ct);
        }
    }
}
