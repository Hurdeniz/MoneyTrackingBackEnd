using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<UserForAddDto>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("Lütfen E-Posta Giriniz");
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("Lütfen Kullanıcı Adını Giriniz");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Lütfen Kullanıcı Soyadını Giriniz");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Lütfen Kullanıcı Şifresini Giriniz");
            RuleFor(u => u.OperationClaimId).NotEmpty().WithMessage("Lütfen Kullanıcı Yetkisini Giriniz");
        }
    }
}
