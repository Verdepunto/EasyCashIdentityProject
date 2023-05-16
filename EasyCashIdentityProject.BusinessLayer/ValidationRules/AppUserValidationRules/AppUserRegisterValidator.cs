using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanını boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyadı alanını boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanını boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanını boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanını boş geçilemez");
            RuleFor(x => x.Confirmpassword).NotEmpty().WithMessage("Şifre tekrar alanını boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("En fazla 30 karakter girişi yapın");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("En az 2 karakter girin");
            RuleFor(x => x.Confirmpassword).Equal(y => y.Password).WithMessage("Parolanız eşleşmiyor");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir eposta girin");
        }
    }
}
