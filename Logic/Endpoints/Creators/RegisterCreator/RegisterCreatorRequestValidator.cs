using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Logic.Endpoints.Creators.RegisterCreator
{
    public class RegisterCreatorRequestValidator: Validator<RegisterCreatorRequest>
    {
        public RegisterCreatorRequestValidator()
        {
            RuleFor(x=>x.Id).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
