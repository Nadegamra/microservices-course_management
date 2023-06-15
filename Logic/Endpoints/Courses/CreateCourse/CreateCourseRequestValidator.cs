using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Logic.Endpoints.Courses.CreateCourse
{
    public class CreateCourseRequestValidator : Validator<CreateCourseRequest>
    {
        public CreateCourseRequestValidator()
        {
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.LengthInDays).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CertificatePrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.ActivityFormat).IsInEnum();
            RuleFor(x => x.ScheduleType).IsInEnum();
            RuleFor(x => x.Difficulty).IsInEnum();
        }
    }
}
