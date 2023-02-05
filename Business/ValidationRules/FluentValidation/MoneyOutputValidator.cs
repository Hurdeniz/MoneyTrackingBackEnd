using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class MoneyOutputValidator :AbstractValidator<MoneyOutput>
    {
        public MoneyOutputValidator()
        {
            RuleFor(m => m.UserId).NotEmpty().WithMessage("Lütfen Kullanıcı Seçiniz");
            RuleFor(m => m.TotalAmount).GreaterThan(0).WithMessage("Girdiğiniz Tutar 0 ve 0'dan Küçük Olamaz");
            RuleFor(m => m.Date).NotEmpty().WithMessage("Lütfen Tarih Seçiniz");


        }
    }
}
