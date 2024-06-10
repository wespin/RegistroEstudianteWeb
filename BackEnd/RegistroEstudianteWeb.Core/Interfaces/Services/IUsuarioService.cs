using RegistroEstudianteWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudianteWeb.Core.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> GetById(int id);
        Task<Usuario> Create(Usuario nuevoUsuario);
        Task<Usuario> Update(int UsuarioToBeUpdatedId, Usuario newUsuarioValues);
        Task Delete(int id);
        Task<Usuario> GetByNombreUsuario(string nombreUsuario);
    }
}
