using FluentValidation;
using RegistroEstudianteWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudianteWeb.Services.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.NombreUsuario)
                    .NotEmpty().WithMessage("El usuario no puede ser vacio")
                    .MaximumLength(8).WithMessage("El maximo caracteres es 8");

            RuleFor(x => x.PasswordHash)
            .NotNull().WithMessage("Debe ingresar un valor en PAssword");
        

        }
    }
}
