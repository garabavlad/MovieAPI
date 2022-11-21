using APIMovie.ModelViews;
using FluentValidation;

namespace APIMovie.Validators
{
    public class ReviewUpdateRequestValidator : AbstractValidator<ReviewUpdateRequest>
    {
        public ReviewUpdateRequestValidator()
        {
            RuleFor(r => r.Username).NotNull().NotEmpty();
            RuleFor(r => r.MovieId).GreaterThan(0);
            RuleFor(r => r.Rating).InclusiveBetween(1, 5);
        }
    }
}
