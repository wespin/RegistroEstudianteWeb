using RegistroEstudianteWeb.Core.Entities;
using RegistroEstudianteWeb.Core.Interfaces.Services;
using RegistroEstudianteWeb.Core.Interfaces;
using RegistroEstudianteWeb.Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudianteWeb.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;


        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _unitOfWork.UsuarioRepository.GetAllAsync();
        }

        public async Task<Usuario> GetById(int id)
        {
            return await _unitOfWork.UsuarioRepository.GetByIdAsync(id);
        }

        public async Task<Usuario> Create(Usuario newUsuario)
        {
            UsuarioValidator validator = new();

            var validationResult = await validator.ValidateAsync(newUsuario);
            if (validationResult.IsValid)
            {
                await _unitOfWork.UsuarioRepository.AddAsync(newUsuario);
                await _unitOfWork.SaveChanges();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }



            return newUsuario;
        }

        public async Task<Usuario> Update(int UsuarioToBeUpdatedId, Usuario newUsuarioValues)
        {
            UsuarioValidator UsuarioValidator = new();

            var validationResult = await UsuarioValidator.ValidateAsync(newUsuarioValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Usuario UsuarioToBeUpdated = await _unitOfWork.UsuarioRepository.GetByIdAsync(UsuarioToBeUpdatedId);

            if (UsuarioToBeUpdated == null)
                throw new ArgumentException("Invalid Usuario ID while updating");

            UsuarioToBeUpdated.Id = newUsuarioValues.Id;
            UsuarioToBeUpdated.NombreUsuario = newUsuarioValues.NombreUsuario;
            UsuarioToBeUpdated.PasswordHash = newUsuarioValues.PasswordHash;
            UsuarioToBeUpdated.PasswordSalt = newUsuarioValues.PasswordSalt;

            await _unitOfWork.SaveChanges();

            return await _unitOfWork.UsuarioRepository.GetByIdAsync(UsuarioToBeUpdatedId);
        }

        public async Task Delete(int UsuarioId)
        {
            Usuario Usuario = await _unitOfWork.UsuarioRepository.GetByIdAsync(UsuarioId);
            _unitOfWork.UsuarioRepository.Remove(Usuario);
            await _unitOfWork.SaveChanges();
        }

        public async Task<Usuario> GetByNombreUsuario(string NombreUsuario)
        {
            return await _unitOfWork.UsuarioRepository.GetByNombreUsuario(NombreUsuario);
        }
    }
}
