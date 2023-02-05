using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class FutureMoneyValidator :AbstractValidator<FutureMoney>
    {
        public FutureMoneyValidator()
        {
            RuleFor(f => f.UserId).NotEmpty().WithMessage("Lütfen Kullanıcı Giriniz");
            RuleFor(f => f.TypeOfOperation).NotEmpty().WithMessage("Lütfen İşlem Tipi Seçiniz"); ;
            RuleFor(f => f.CustomerCode).NotEmpty().WithMessage("Lütfen Müşteri Kodu Giriniz"); 
            RuleFor(f => f.PromissoryNumber).NotEmpty().WithMessage("Lütfen Senet Numarası Giriniz"); ;
            RuleFor(f => f.TransactionAmount).GreaterThan(0).WithMessage("İşlem Tutarı 0 ve 0'dan Küçük Olamaz");
        }
    }
}
