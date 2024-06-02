using RegistroEstudianteWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudianteWeb.Core.Interfaces.Services
{
    public interface ICursoService
    {
        Task<IEnumerable<Curso>> GetAll();
        Task<Curso> GetById(int id);
        Task<Curso> Create(Curso nuevoCurso);
        Task<Curso> Update(int CursoToBeUpdatedId, Curso newCursoValues);
        Task Delete(int id);
    }
}
