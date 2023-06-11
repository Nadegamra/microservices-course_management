using CourseManagement.Models;
using FastEndpoints;

namespace CourseManagement.Endpoints.CourseRequirements.CourseRequirementUpdate
{
    public class CourseRequirementUpdateMapper: Mapper<CourseRequirementUpdateRequest, EmptyResponse, CourseRequirement>
    {
        public override CourseRequirement UpdateEntity(CourseRequirementUpdateRequest r, CourseRequirement e)
        {
            e.CustomDescription = r.CustomDescription;
            return e;
        }
    }
}
