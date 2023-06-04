using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Endpoints.Courses.GetUserCourseList
{
    public class GetUserCourseListRequestValidator : Validator<GetUserCourseListRequest>
    {
        public GetUserCourseListRequestValidator()
        {
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1);
        }
    }
}
