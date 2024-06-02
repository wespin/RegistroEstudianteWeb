using RegistroEstudianteWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudianteWeb.Core.Interfaces.Services
{
    public interface IEstudianteService
    {
        Task<IEnumerable<Estudiante>> GetAll();
        Task<Estudiante> GetById(int id);
        Task<Estudiante> Create(Estudiante nuevoEstudiante);
        Task<Estudiante> Update(int estudianteToBeUpdatedId, Estudiante newEstudianteValues);
        Task Delete(int id);
    }
}
