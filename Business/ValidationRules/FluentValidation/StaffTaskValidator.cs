using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class StaffTaskValidator : AbstractValidator<StaffTask>
    {
        public StaffTaskValidator()
        {
            RuleFor(t => t.StaffTaskName).NotEmpty().WithMessage("Lütfen Görev Adını Giriniz");
        }
    }
}
