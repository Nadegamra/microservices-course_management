using CourseManagement.Data;
using CourseManagement.Data.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Logic.Endpoints.CourseRequirements.GetRequirementList
{
    public class GetRequirementListEndpoint : Endpoint<GetRequirementListRequest, List<GetRequirementListResponse>, GetRequirementListMapper>
    {
        public override void Configure()
        {
            Get("courses/{courseId}/requirements");
            AllowAnonymous();
        }

        private readonly CourseDbContext courseDbContext;

        public GetRequirementListEndpoint(CourseDbContext courseDbContext)
        {
            this.courseDbContext = courseDbContext;
        }

        public override async Task HandleAsync(GetRequirementListRequest req, CancellationToken ct)
        {
            List<CourseRequirement> requirements = courseDbContext.CourseRequirements.Include(x => x.Skill).Where(x => x.CourseId == req.CourseId).ToList();
            Response = Map.FromEntity(requirements);
            await SendOkAsync(Response, ct);
        }
    }
}