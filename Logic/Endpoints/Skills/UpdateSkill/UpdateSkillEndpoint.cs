using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Skills.UpdateSkill
{
    public class UpdateSkillEndpoint : Endpoint<UpdateSkillRequest, UpdateSkillResponse, UpdateSkillMapper>
    {
        public override void Configure()
        {
            Put("skills/{id}");
            Roles("ADMIN");
        }

        private readonly IRepository<Skill> repository;

        public UpdateSkillEndpoint(IRepository<Skill> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(UpdateSkillRequest req, CancellationToken ct)
        {
            Skill? skill = repository.Get(req.Id);
            if (skill == null)
            {
                await SendErrorsAsync(400, ct);
                return;
            }
            if (skill.Name != req.Name && repository.GetAll().Where(x => x.Name == req.Name).Any())
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            skill = Map.UpdateEntity(req, skill);
            var res = repository.Update(skill);

            Response = Map.FromEntity(res);
            await SendOkAsync(Response, ct);
        }
    }
}
