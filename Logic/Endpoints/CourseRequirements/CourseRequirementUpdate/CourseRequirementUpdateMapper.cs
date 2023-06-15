using CourseManagement.Data.Models;
using FastEndpoints;

namespace CourseManagement.Logic.Endpoints.CourseRequirements.CourseRequirementUpdate
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
