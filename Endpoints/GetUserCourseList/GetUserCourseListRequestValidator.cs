using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Endpoints.GetUserCourseList
{
    public class GetUserCourseListRequestValidator: Validator<GetUserCourseListRequest>
    {
        public GetUserCourseListRequestValidator()
        {
            RuleFor(x=>x.UserId).GreaterThanOrEqualTo(1);
        }
    }
}
