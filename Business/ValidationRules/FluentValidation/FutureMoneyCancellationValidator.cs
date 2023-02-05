using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class FutureMoneyCancellationValidator :AbstractValidator<FutureMoneyCancellation>
    {
        public FutureMoneyCancellationValidator()
        {
            RuleFor(f => f.FutureMoneyId).NotEmpty().WithMessage("Lütfen Elden Gelecek Giriniz");
            RuleFor(f => f.FutureMoneyCancellationAmount).GreaterThan(0).WithMessage("Elden Gelecek İptal Tutarı 0 ve 0'dan Küçük Olamaz");
        }
    }
}
