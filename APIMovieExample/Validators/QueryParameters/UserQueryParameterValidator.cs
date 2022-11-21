using APIMovie.ModelViews;
using FluentValidation;

namespace APIMovie.Validators
{
    public class UserQueryParameterValidator : AbstractValidator<UserQueryParameter>
    {
        public UserQueryParameterValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}
