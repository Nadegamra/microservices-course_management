using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.GainedSkills.GainedSkillCreate
{
    public class GainedSkillCreateMapper: Mapper<GainedSkillCreateRequest, GainedSkillCreateResponse, GainedSkill>
    {
        public override GainedSkillCreateResponse FromEntity(GainedSkill e)
        {
            return new GainedSkillCreateResponse()
            {
                Id = e.Id,
                CourseId = e.CourseId,
                CustomDescription = e.CustomDescription,
                SkillId = e.SkillId,
            };
        }
        public override GainedSkill ToEntity(GainedSkillCreateRequest r)
        {
            return new GainedSkill()
            {
                CourseId = r.CourseId,
                CustomDescription = r.CustomDescription,
                SkillId = r.SkillId,
            };
        }
    }
}
