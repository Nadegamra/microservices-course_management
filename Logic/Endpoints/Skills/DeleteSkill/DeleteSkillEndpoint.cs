using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.Skills.DeleteSkill
{
    public class DeleteSkillEndpoint : Endpoint<DeleteSkillRequest>
    {
        public override void Configure()
        {
            Delete("skills/{id}");
            Roles("ADMIN");
        }

        private readonly IRepository<Skill> repository;

        public DeleteSkillEndpoint(IRepository<Skill> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleAsync(DeleteSkillRequest req, CancellationToken ct)
        {
            Skill? skill = repository.Get(req.Id);
            if (skill == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            repository.Delete(skill);
            await SendNoContentAsync(ct);
        }
    }
}
