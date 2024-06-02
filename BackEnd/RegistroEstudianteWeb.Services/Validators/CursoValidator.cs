using FluentValidation;
using RegistroEstudianteWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudianteWeb.Services.Validators
{
    public class CursoValidator :AbstractValidator<Curso>
    {
        public CursoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty()
                .MaximumLength(50);

            //RuleFor(x => x.Apellido)
            //    .NotEmpty()
            //    .WithMessage("Classroom MUST have a SchoolId");

        }
    }
}
