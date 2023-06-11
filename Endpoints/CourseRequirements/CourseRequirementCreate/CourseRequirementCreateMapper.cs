using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.CourseRequirements.CourseRequirementCreate
{
    public class CourseRequirementCreateMapper: RequestMapper<CourseRequirementCreateRequest, CourseRequirement>
    {
        public override CourseRequirement ToEntity(CourseRequirementCreateRequest r)
        {
            return new CourseRequirement()
            {
                CourseId = r.CourseId,
                CustomDescription = r.CustomDescription,
                SkillId = r.SkillId,
            };
        }
    }
}
