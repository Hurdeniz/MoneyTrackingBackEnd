using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BankValidator : AbstractValidator<Bank>
    {
        public BankValidator()
        {
            RuleFor(b => b.BankName).NotEmpty().WithMessage("Lütfen Banka Adını Giriniz");

        }
    }
}
