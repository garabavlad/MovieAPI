using APIMovie.ModelViews;
using FluentValidation;

namespace APIMovie.Validators
{
    public class MovieSearchQueryParameterValidator : AbstractValidator<MovieSearchQueryParameter>
    {
        public MovieSearchQueryParameterValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Genres).NotEmpty()
                .When(x => x.Genres.Count > 0);
        }
    }
}
