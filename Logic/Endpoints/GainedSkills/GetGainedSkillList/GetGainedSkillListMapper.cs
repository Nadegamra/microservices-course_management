using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.GainedSkills.GetGainedSkillList
{
    public class GetGainedSkillListMapper : ResponseMapper<List<GetGainedSkillListResponse>, List<GainedSkill>>
    {
        public override List<GetGainedSkillListResponse> FromEntity(List<GainedSkill> e)
        {
            return e.Select(x => new GetGainedSkillListResponse
            {
                Id = x.Id,
                CourseId = x.CourseId,
                SkillId = x.SkillId,
                Skill = x.Skill,
                CustomDescription = x.CustomDescription
            }).ToList();
        }
    }
}