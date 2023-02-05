using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class MonetaryDeficitValidator :AbstractValidator<MonetaryDeficit>
    {
        public MonetaryDeficitValidator()
        {
            RuleFor(m => m.NameSurname).NotEmpty().WithMessage("Adı Soyadı Giriniz");
            RuleFor(m =>m.Amount).GreaterThan(0).WithMessage("Girdiğiniz Tutar 0 ve 0'dan Küçük Olamaz");
        }
    }
}
