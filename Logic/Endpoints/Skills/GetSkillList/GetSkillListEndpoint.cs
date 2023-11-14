using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Skills.GetSkillList
{
    public class GetSkillListEndpoint : Endpoint<GetSkillListRequest, GetSkillListResponse, GetSkillListMapper>
    {
        public override void Configure()
        {
            Get("skills");
            AllowAnonymous();
        }

        private readonly IRepository<Skill> repository;

        public GetSkillListEndpoint(IRepository<Skill> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(GetSkillListRequest req, CancellationToken ct)
        {
            List<Skill> skills = repository.GetAll().Skip(req.Skip).Take(req.Take).ToList();
            Response = Map.FromEntity(skills);
            await SendOkAsync(Response, ct);
        }
    }
}
