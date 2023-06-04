using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Endpoints.GetUserCourse
{
    public class GetUserCourseRequestValidator: Validator<GetUserCourseRequest>
    {
        public GetUserCourseRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1);

        }
    }
}
