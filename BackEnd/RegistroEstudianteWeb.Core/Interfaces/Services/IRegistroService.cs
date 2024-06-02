using RegistroEstudianteWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudianteWeb.Core.Interfaces.Services
{
    public interface IRegistroService
    {
        Task<IEnumerable<Registro>> GetAll();
        Task<Registro> GetById(int id);
        Task<Registro> Create(Registro nuevoRegistro);
        Task<Registro> Update(int RegistroToBeUpdatedId, Registro newRegistroValues);
        Task Delete(int id);
    }
}
