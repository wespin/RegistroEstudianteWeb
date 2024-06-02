using RegistroEstudianteWeb.Core.Entities;
using RegistroEstudianteWeb.Core.Interfaces.Repositories;
using RegistroEstudianteWeb.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudianteWeb.Infrastructure.Repositories
{
    public class EstudianteRepository : BaseRepository<Estudiante>, IEstudianteRepository
    {
        public EstudianteRepository(AppDbContext context) : base(context)
        {

        }
    }
}
