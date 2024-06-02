using RegistroEstudianteWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudianteWeb.Core.Interfaces.Services
{
    public interface IProfesorService
    {        
        Task<IEnumerable<Profesor>> GetAll();
        Task<Profesor> GetById(int id);
        Task<Profesor> Create(Profesor nuevoProfesor);
        Task<Profesor> Update(int ProfesorToBeUpdatedId, Profesor newProfesorValues);
        Task Delete(int id);
    }
}
