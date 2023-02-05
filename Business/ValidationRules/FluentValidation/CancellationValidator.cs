using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    internal class CancellationValidator : AbstractValidator<Cancellation>
    {
        public CancellationValidator()
        {
            RuleFor(c => c.UserId).NotEmpty().WithMessage("Lütfen Kullanıcı Giriniz");
            RuleFor(c => c.CustomerCode).NotEmpty().WithMessage("Lütfen Müşteri Kodu Giriniz");
            RuleFor(c => c.CustomerNameSurname).NotEmpty().WithMessage("Lütfen Müşteri Adı Soyadı Giriniz");
            RuleFor(c => c.PromissoryNumber).NotEmpty().WithMessage("Lütfen Senet Numarası Giriniz");
            RuleFor(c => c.TransactionAmount).GreaterThan(0).WithMessage("İşlem Tutarı 0 ve 0'dan Küçük Olamaz");
            RuleFor(c => c.CancellationAmount).GreaterThan(0).WithMessage("İptal Tutarı 0 ve 0'dan Küçük Olamaz");
            RuleFor(c => c.Date).NotEmpty().WithMessage("Lütfen İptal Tarihi Giriniz");
        }
    }
}
