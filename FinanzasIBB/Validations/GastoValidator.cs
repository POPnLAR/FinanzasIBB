using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanzasIBB.Models;
using FluentValidation;

namespace FinanzasIBB.Validations
{
    public class GastoValidator : AbstractValidator<Gasto>
    {
        public class LoginValidator : AbstractValidator<Gasto>
        {
            public LoginValidator()
            {
                
            }
        }
    }
}
