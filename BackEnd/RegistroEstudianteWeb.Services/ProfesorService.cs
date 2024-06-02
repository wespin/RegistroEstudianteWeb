using RegistroEstudianteWeb.Core.Entities;
using RegistroEstudianteWeb.Core.Interfaces;
using RegistroEstudianteWeb.Core.Interfaces.Services;
using RegistroEstudianteWeb.Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudianteWeb.Services
{
    public class ProfesorService: IProfesorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProfesorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Profesor>> GetAll()
        {
            return await _unitOfWork.ProfesorRepository.GetAllAsync();
        }

        public async Task<Profesor> GetById(int id)
        {
            return await _unitOfWork.ProfesorRepository.GetByIdAsync(id);
        }

        public async Task<Profesor> Create(Profesor newProfesor)
        {
            ProfesorValidator validator = new();

            var validationResult = await validator.ValidateAsync(newProfesor);
            if (validationResult.IsValid)
            {
                await _unitOfWork.ProfesorRepository.AddAsync(newProfesor);
                await _unitOfWork.SaveChanges();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newProfesor;
        }

        public async Task<Profesor> Update(int ProfesorToBeUpdatedId, Profesor newProfesorValues)
        {
            ProfesorValidator ProfesorValidator = new();

            var validationResult = await ProfesorValidator.ValidateAsync(newProfesorValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Profesor ProfesorToBeUpdated = await _unitOfWork.ProfesorRepository.GetByIdAsync(ProfesorToBeUpdatedId);

            if (ProfesorToBeUpdated == null)
                throw new ArgumentException("Invalid Profesor ID while updating");

            ProfesorToBeUpdated.Nombre = newProfesorValues.Nombre;
            ProfesorToBeUpdated.Apellido = newProfesorValues.Apellido;
            ProfesorToBeUpdated.FechaContratacion = newProfesorValues.FechaContratacion;

            await _unitOfWork.SaveChanges();

            return await _unitOfWork.ProfesorRepository.GetByIdAsync(ProfesorToBeUpdatedId);
        }

        public async Task Delete(int ProfesorId)
        {
            Profesor Profesor = await _unitOfWork.ProfesorRepository.GetByIdAsync(ProfesorId);
            _unitOfWork.ProfesorRepository.Remove(Profesor);
            await _unitOfWork.SaveChanges();
        }
    }
}
