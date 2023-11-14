using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Skills.GetSkillCount
{
    public class GetSkillCountEndpoint : Endpoint<EmptyRequest, GetSkillCountResponse>
    {
        public override void Configure()
        {
            Get("skills/count");
            AllowAnonymous();
        }

        private readonly IRepository<Skill> repository;

        public GetSkillCountEndpoint(IRepository<Skill> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
        {
            int count = repository.GetAll().Count();
            Response = new GetSkillCountResponse { Count = count };
            await SendOkAsync(Response, ct);
        }
    }
}