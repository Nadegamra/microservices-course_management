using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Endpoints.DeleteCourse
{
    public class DeleteCourseRequestValidator: Validator<DeleteCourseRequest>
    {
        public DeleteCourseRequestValidator()
        {
            RuleFor(x=>x.UserId).GreaterThanOrEqualTo(1);
            RuleFor(x=>x.Id).GreaterThanOrEqualTo(1);
        }
    }
}
