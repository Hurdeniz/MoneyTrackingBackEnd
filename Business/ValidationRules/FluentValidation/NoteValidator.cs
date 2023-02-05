using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class NoteValidator :AbstractValidator<Note>
    {
        public NoteValidator()
        {
            RuleFor(n=>n.UserId).NotEmpty().WithMessage("Lütfen Kullanıcı Giriniz");
            RuleFor(n => n.Description).NotEmpty().WithMessage("Lütfen Açıklama Giriniz");

        }
    }
}
