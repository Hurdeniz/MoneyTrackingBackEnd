using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerPayValidator : AbstractValidator<CustomerPay>
    {
        public CustomerPayValidator()
        {
            RuleFor(c => c.CustomerName).NotEmpty().WithMessage("Lütfen Firma Adını Giriniz"); 
            RuleFor(c => c.Amount).GreaterThan(0).WithMessage("Girdiğiniz Tutar 0 ve 0'dan Küçük Olamaz");
            RuleFor(c => c.Date).NotEmpty().WithMessage("Lütfen Tarih Seçiniz");
        }
    }
}
