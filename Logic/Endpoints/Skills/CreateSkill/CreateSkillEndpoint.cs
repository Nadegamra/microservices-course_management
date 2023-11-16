using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Skills.CreateSkill
{
    public class CreateSkillEndpoint : Endpoint<CreateSkillRequest, CreateSkillResponse, CreateSkillMapper>
    {
        public override void Configure()
        {
            Post("skills");
            Roles("ADMIN");
        }

        private readonly IRepository<Skill> repository;

        public CreateSkillEndpoint(IRepository<Skill> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(CreateSkillRequest req, CancellationToken ct)
        {
            bool alreadyExists = repository.GetAll().Where(x => x.Name == req.Name).Any();
            if (alreadyExists)
            {
                await SendErrorsAsync(409, ct);
            }

            Skill skill = Map.ToEntity(req);

            var res = repository.Add(skill);

            Response = Map.FromEntity(res);
            await SendOkAsync(Response, ct);
        }
    }
}
