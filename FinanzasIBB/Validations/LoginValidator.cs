using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanzasIBB.Models;
using FluentValidation;

namespace FinanzasIBB.Validations
{
    public class LoginValidator : AbstractValidator<Usuario>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email Obligatorio")
                .EmailAddress().WithMessage("Formato Email Incorrecto");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password Obligatorio")
                .MinimumLength(6).WithMessage("El Password Debe Contener Minimo 6 Caracteres");
        }
    }
}
