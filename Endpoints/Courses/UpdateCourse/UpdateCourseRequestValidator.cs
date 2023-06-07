using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Endpoints.Courses.UpdateCourse
{
    public class UpdateCourseRequestValidator : Validator<UpdateCourseRequest>
    {
        public UpdateCourseRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1);

            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1);

            RuleFor(x => x.CoursePrice).GreaterThanOrEqualTo(0).Custom((price, ctx) =>
            {
                if (price * 100 % 1 > 0)
                {
                    ctx.AddFailure("Price must not have more than 2 decimal places");
                }
            });

            RuleFor(x => x.LengthInDays).GreaterThan(0);

            RuleFor(x => x.CertificatePrice).GreaterThanOrEqualTo(0).Custom((price, ctx) =>
            {
                if (price * 100 % 1 > 0)
                {
                    ctx.AddFailure("Price must not have more than 2 decimal places");
                }
            });
        }
    }
}
