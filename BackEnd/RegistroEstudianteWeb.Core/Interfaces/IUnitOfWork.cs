using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroEstudianteWeb.Core.Interfaces.Repositories;

namespace RegistroEstudianteWeb.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICursoRepository CursoRepository { get; }
        IEstudianteRepository EstudianteRepository { get; }
        IProfesorRepository ProfesorRepository { get; }
        IRegistroRepository RegistroRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }

        Task SaveChanges();
    }
}
