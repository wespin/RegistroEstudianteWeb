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
    public class RegistroService : IRegistroService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RegistroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Registro>> GetAll()
        {
            return await _unitOfWork.RegistroRepository.GetAllAsync();
        }

        public async Task<Registro> GetById(int id)
        {
            return await _unitOfWork.RegistroRepository.GetByIdAsync(id);
        }

        public async Task<Registro> Create(Registro newRegistro)
        {
            RegistroValidator validator = new();

            var validationResult = await validator.ValidateAsync(newRegistro);
            if (validationResult.IsValid)
            {
                await _unitOfWork.RegistroRepository.AddAsync(newRegistro);
                await _unitOfWork.SaveChanges();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newRegistro;
        }

        public async Task<Registro> Update(int RegistroToBeUpdatedId, Registro newRegistroValues)
        {
            RegistroValidator RegistroValidator = new();

            var validationResult = await RegistroValidator.ValidateAsync(newRegistroValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Registro RegistroToBeUpdated = await _unitOfWork.RegistroRepository.GetByIdAsync(RegistroToBeUpdatedId);

            if (RegistroToBeUpdated == null)
                throw new ArgumentException("Invalid Registro ID while updating");

            RegistroToBeUpdated.CursoId = newRegistroValues.CursoId;
            RegistroToBeUpdated.EstudianteId = newRegistroValues.EstudianteId;
            RegistroToBeUpdated.Nota = newRegistroValues.Nota;

            await _unitOfWork.SaveChanges();

            return await _unitOfWork.RegistroRepository.GetByIdAsync(RegistroToBeUpdatedId);
        }

        public async Task Delete(int RegistroId)
        {
            Registro Registro = await _unitOfWork.RegistroRepository.GetByIdAsync(RegistroId);
            _unitOfWork.RegistroRepository.Remove(Registro);
            await _unitOfWork.SaveChanges();
        }
    }
}
