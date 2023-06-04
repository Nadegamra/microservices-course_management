using FastEndpoints;
using FluentValidation;

namespace CourseManagement.Endpoints.Creators.UpdateCreator
{
    public class UpdateCreatorRequestValidator: Validator<UpdateCreatorRequest>
    {
        public UpdateCreatorRequestValidator()
        {
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1);
        }
    }
}
