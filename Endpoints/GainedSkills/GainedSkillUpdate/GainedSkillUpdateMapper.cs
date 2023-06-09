using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.GainedSkills.GainedSkillUpdate
{
    public class GainedSkillUpdateMapper: Mapper<GainedSkillUpdateRequest, GainedSkillUpdateResponse, GainedSkill>
    {
        public override GainedSkillUpdateResponse FromEntity(GainedSkill e)
        {
            return new GainedSkillUpdateResponse()
            {
                Id = e.Id,
                CourseId = e.CourseId,
                SkillId = e.SkillId,
                CustomDescription = e.CustomDescription,
            };
        }
        public override GainedSkill UpdateEntity(GainedSkillUpdateRequest r, GainedSkill e)
        {
            e.CustomDescription = r.CustomDescription;
            return e;
        }
    }
}
