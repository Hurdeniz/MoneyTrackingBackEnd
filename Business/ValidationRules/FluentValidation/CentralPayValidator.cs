using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CentralPayValidator : AbstractValidator<CentralPay>
    {
        public CentralPayValidator()
        {
            RuleFor(c => c.Amount).GreaterThan(0).WithMessage("Girdiğiniz Tutar 0 ve 0'dan Küçük Olamaz");
            RuleFor(c => c.Date).NotEmpty().WithMessage("Lütfen Tarih Seçiniz");
        }
    }
}
