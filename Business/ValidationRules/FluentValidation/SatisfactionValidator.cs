using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SatisfactionValidator : AbstractValidator<Satisfaction>
    {
        public SatisfactionValidator()
        {
            RuleFor(s => s.CustomerCode).NotEmpty().WithMessage("Lütfen Müşteri Kodu Giriniz");
            RuleFor(s => s.CustomerNameSurname).NotEmpty().WithMessage("Lütfen Müşteri Adı Soyadı Giriniz");
            RuleFor(s => s.PromissoryNumber).NotEmpty().WithMessage("Lütfen Senet Numarası Giriniz");
            RuleFor(s => s.Phone).NotEmpty().WithMessage("Lütfen Telefon Numarası Giriniz");
            RuleFor(s => s.Result).NotEmpty().WithMessage("Lütfen Sonuç Giriniz");
        }
    }
}
