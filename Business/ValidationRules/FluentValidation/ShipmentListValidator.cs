using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ShipmentListValidator : AbstractValidator<ShipmentList>
    {
        public ShipmentListValidator()
        {
            RuleFor(s => s.UserId).NotEmpty().WithMessage("Lütfen Kullanıcı Giriniz");
            RuleFor(s => s.CustomerCode).NotEmpty().WithMessage("Lütfen Müşteri Kodu Giriniz");
            RuleFor(s => s.CustomerNameSurname).NotEmpty().WithMessage("Lütfen Müşteri Adı Soyadı Giriniz");
            RuleFor(s => s.PromissoryNumber).NotEmpty().WithMessage("Lütfen Senet Numarası Giriniz");
        }
    }
}
