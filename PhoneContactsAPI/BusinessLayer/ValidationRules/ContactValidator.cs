using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.ContactName).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.ContactName).MaximumLength(50).WithMessage("İsim 50 karakterden uzun olamaz");
            RuleFor(x => x.ContactName).MinimumLength(2).WithMessage("İsim 2 karakterden kısa olamaz");
            RuleFor(x => x.ContactEmail).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x => x.ContactPhone).NotEmpty().WithMessage("Telefon numarası boş geçilemez");
        }
    }
}
