using EasyHR.DemoFormApp.Entities.DTOs;
using FluentValidation;

namespace EasyHR.DemoFormApp.Business.Validation
{
    public class FormCreateDtoValidator : AbstractValidator<FormCreateDto>
    {
        public FormCreateDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Ad boş geçilemez.")
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Soyad boş geçilemez.")
                .MaximumLength(100);

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .LessThan(DateTime.UtcNow).WithMessage("Doğum tarihi bugünden küçük olmalı.");
        }
    }
}
