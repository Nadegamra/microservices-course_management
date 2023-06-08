using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.Skills.UpdateSkill
{
    public class UpdateSkillMapper: ResponseMapper<UpdateSkillResponse, Skill>
    {
        public override UpdateSkillResponse FromEntity(Skill e)
        {
            return new UpdateSkillResponse()
            {
                Id = e.Id,
                Description = e.Description,
                Name = e.Name
            };
        }

        public override Skill UpdateEntity(UpdateSkillRequest r, Skill e)
        {
            e.Name = r.Name;
            e.Description = r.Description;
            return e;
        }
    }
}
