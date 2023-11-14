using CourseManagement.Data.Models;
using CourseManagement.Data.Repositories;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.GainedSkills.GainedSkillDelete
{
    public class GainedSkillDeleteEndpoint : Endpoint<GainedSkillDeleteRequest>
    {
        public override void Configure()
        {
            Delete("courses/{courseId}/gained/{id}");
            Roles("ADMIN", "CREATOR");
        }

        private readonly IRepository<Course> courseRepository;
        private readonly IRepository<GainedSkill> gainedSkillsRepository;

        public GainedSkillDeleteEndpoint(IRepository<Course> courseRepository, IRepository<GainedSkill> gainedSkillsRepository)
        {
            this.courseRepository = courseRepository;
            this.gainedSkillsRepository = gainedSkillsRepository;
        }

        public override async Task HandleAsync(GainedSkillDeleteRequest req, CancellationToken ct)
        {
            GainedSkill? skill = gainedSkillsRepository.Get(req.Id);
            if (skill == null || !courseRepository.GetAll().Where(x => x.Id == skill.CourseId && x.UserId == req.UserId).Any())
            {
                await SendErrorsAsync(400, ct);
                return;
            }

            gainedSkillsRepository.Delete(skill);
            await SendOkAsync(ct);
        }
    }
}
