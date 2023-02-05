using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class StaffValidator :AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(s=>s.IdentityNumber).NotEmpty().WithMessage("Lütfen T.C. Kimlik No Giriniz");
            RuleFor(s=>s.NameSurname).NotEmpty().WithMessage("Lütfen Adı Soyadı Giriniz");
            RuleFor(s=>s.StaffEpisodeId).NotEmpty().WithMessage("Lütfen Bölüm Seçiniz");
            RuleFor(s=>s.StaffTaskId).NotEmpty().WithMessage("Lütfen Görev Seçiniz");
          
        }
    }
}
