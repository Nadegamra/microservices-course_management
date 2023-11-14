using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseRequirements.GetRequirementList
{
    public class GetRequirementListEndpoint : Endpoint<GetRequirementListRequest, List<GetRequirementListResponse>, GetRequirementListMapper>
    {
        public override void Configure()
        {
            Get("courses/{courseId}/requirements");
            AllowAnonymous();
        }

        private readonly IRepository<CourseRequirement> courseRequirementRepository;

        public GetRequirementListEndpoint(IRepository<CourseRequirement> courseRequirementRepository)
        {
            this.courseRequirementRepository = courseRequirementRepository;
        }

        public override async Task HandleAsync(GetRequirementListRequest req, CancellationToken ct)
        {
            List<CourseRequirement> requirements = courseRequirementRepository.GetAll()
                                                    .Where(x => x.CourseId == req.CourseId)
                                                    .ToList();
            Response = Map.FromEntity(requirements);
            await SendOkAsync(Response, ct);
        }
    }
}