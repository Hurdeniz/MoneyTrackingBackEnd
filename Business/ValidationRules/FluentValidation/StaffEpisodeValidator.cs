using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class StaffEpisodeValidator : AbstractValidator<StaffEpisode>
    {
        public StaffEpisodeValidator()
        {
            RuleFor(e => e.StaffEpisodeName).NotEmpty().WithMessage("Lütfen Bölüm Adını Giriniz");
        }    
    }
}
