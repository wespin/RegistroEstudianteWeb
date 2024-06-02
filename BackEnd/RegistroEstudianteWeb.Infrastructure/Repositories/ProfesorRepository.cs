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
    public class ProfesorRepository : BaseRepository<Profesor>, IProfesorRepository
    {
        public ProfesorRepository(AppDbContext context) : base(context)
        {

        }
    }
}
