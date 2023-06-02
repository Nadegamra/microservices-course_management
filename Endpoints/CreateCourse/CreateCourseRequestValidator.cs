using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Endpoints.CreateCourse
{
    public class CreateCourseRequestValidator : Validator<CreateCourseRequest>
    {
        public CreateCourseRequestValidator()
        {
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.CoursePrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.LengthInDays).GreaterThanOrEqualTo(1);
            RuleFor(x => x.CertificatePrice).GreaterThanOrEqualTo(0);
        }
    }
}
