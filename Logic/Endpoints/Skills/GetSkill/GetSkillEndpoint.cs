using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Skills.GetSkill
{
    public class GetSkillEndpoint : Endpoint<GetSkillRequest, GetSkillResponse, GetSkillMapper>
    {
        public override void Configure()
        {
            Get("skills/{id}");
            AllowAnonymous();
        }

        private readonly IRepository<Skill> repository;

        public GetSkillEndpoint(IRepository<Skill> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(GetSkillRequest req, CancellationToken ct)
        {
            Skill? skill = repository.Get(req.Id);
            if (skill == null)
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            Response = Map.FromEntity(skill);
            await SendOkAsync(Response, ct);
        }
    }
}
