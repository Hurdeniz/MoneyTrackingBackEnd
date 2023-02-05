using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class MoneyDepositedValidator : AbstractValidator<MoneyDeposited>
    {
        public MoneyDepositedValidator()
        {
            RuleFor(m => m.BankId).NotEmpty().WithMessage("Lütfen Banka Seçiniz"); ;
            RuleFor(c => c.Amount).GreaterThan(0).WithMessage("Girdiğiniz Tutar 0 ve 0'dan Küçük Olamaz");

        }
    }
}
