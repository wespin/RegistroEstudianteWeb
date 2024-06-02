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
    public class EstudianteService: IEstudianteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EstudianteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Estudiante>> GetAll()
        {
            return await _unitOfWork.EstudianteRepository.GetAllAsync();
        }

        public async Task<Estudiante> GetById(int id)
        {
            return await _unitOfWork.EstudianteRepository.GetByIdAsync(id);
        }



        public async Task<Estudiante> Create(Estudiante newEstudiante)
        {
            EstudianteValidator validator = new();

            var validationResult = await validator.ValidateAsync(newEstudiante);
            if (validationResult.IsValid)
            {
                await _unitOfWork.EstudianteRepository.AddAsync(newEstudiante);
                await _unitOfWork.SaveChanges();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newEstudiante;
        }

        public async Task<Estudiante> Update(int EstudianteToBeUpdatedId, Estudiante newEstudianteValues)
        {
            EstudianteValidator EstudianteValidator = new();

            var validationResult = await EstudianteValidator.ValidateAsync(newEstudianteValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Estudiante EstudianteToBeUpdated = await _unitOfWork.EstudianteRepository.GetByIdAsync(EstudianteToBeUpdatedId);

            if (EstudianteToBeUpdated == null)
                throw new ArgumentException("Invalid Estudiante ID while updating");

            EstudianteToBeUpdated.Nombre = newEstudianteValues.Nombre;
            EstudianteToBeUpdated.Apellido = newEstudianteValues.Apellido;
            EstudianteToBeUpdated.FechaRegistro = newEstudianteValues.FechaRegistro;

            await _unitOfWork.SaveChanges();

            return await _unitOfWork.EstudianteRepository.GetByIdAsync(EstudianteToBeUpdatedId);
        }

        public async Task Delete(int EstudianteId)
        {
            Estudiante Estudiante = await _unitOfWork.EstudianteRepository.GetByIdAsync(EstudianteId);
            _unitOfWork.EstudianteRepository.Remove(Estudiante);
            await _unitOfWork.SaveChanges();
        }
    }
}
