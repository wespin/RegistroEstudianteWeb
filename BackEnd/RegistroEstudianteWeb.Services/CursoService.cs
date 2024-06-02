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
    public class CursoService:ICursoService
    {

        private readonly IUnitOfWork _unitOfWork;
        public CursoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Curso>> GetAll()
        {
            return await _unitOfWork.CursoRepository.GetAllAsync();
        }

        public async Task<Curso> GetById(int id)
        {
            return await _unitOfWork.CursoRepository.GetByIdAsync(id);
        }

        public async Task<Curso> Create(Curso newCurso)
        {
            CursoValidator validator = new();

            var validationResult = await validator.ValidateAsync(newCurso);
            if (validationResult.IsValid)
            {
                await _unitOfWork.CursoRepository.AddAsync(newCurso);
                await _unitOfWork.SaveChanges();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newCurso;
        }

        public async Task<Curso> Update(int CursoToBeUpdatedId, Curso newCursoValues)
        {
            CursoValidator CursoValidator = new();

            var validationResult = await CursoValidator.ValidateAsync(newCursoValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Curso CursoToBeUpdated = await _unitOfWork.CursoRepository.GetByIdAsync(CursoToBeUpdatedId);

            if (CursoToBeUpdated == null)
                throw new ArgumentException("Invalid Curso ID while updating");

            CursoToBeUpdated.Nombre = newCursoValues.Nombre;
            CursoToBeUpdated.Creditos = newCursoValues.Creditos;

            await _unitOfWork.SaveChanges();

            return await _unitOfWork.CursoRepository.GetByIdAsync(CursoToBeUpdatedId);
        }

        public async Task Delete(int CursoId)
        {
            Curso Curso = await _unitOfWork.CursoRepository.GetByIdAsync(CursoId);
            _unitOfWork.CursoRepository.Remove(Curso);
            await _unitOfWork.SaveChanges();
        }
    }
}
