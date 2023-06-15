using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Logic.Endpoints.Courses.GetUserCourse
{
    public class GetUserCourseRequestValidator : Validator<GetUserCourseRequest>
    {
        public GetUserCourseRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1);

        }
    }
}
