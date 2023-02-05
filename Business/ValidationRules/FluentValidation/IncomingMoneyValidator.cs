using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class IncomingMoneyValidator :AbstractValidator<IncomingMoney>
    {
        public IncomingMoneyValidator()
        {
            RuleFor(i => i.FutureMoneyId).NotEmpty().WithMessage("Lütfen Elden Gelecek Giriniz");
            RuleFor(i => i.IncomingAmount).NotEmpty().WithMessage("Lütfen Gelen Tutar Giriniz");
        }
    }
}
