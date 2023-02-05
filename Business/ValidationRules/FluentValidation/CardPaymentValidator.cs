using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CardPaymentValidator : AbstractValidator<CardPayment>
    {
        public CardPaymentValidator()
        {
            RuleFor(c=>c.UserId).NotEmpty().WithMessage("Lütfen Kullanıcı Giriniz");
            RuleFor(c=>c.BankId).NotEmpty().WithMessage("Lütfen Banka Seçiniz"); ;
            RuleFor(c=>c.Amount).GreaterThan(0).WithMessage("Girdiğiniz Tutar 0 ve 0'dan Küçük Olamaz");
            RuleFor(c => c.Date).NotEmpty().WithMessage("Lütfen Kayıt Tarihi Seçiniz"); ;
        }
    }
}
