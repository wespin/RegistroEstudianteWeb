using Microsoft.EntityFrameworkCore;
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
    public class RegistroRepository : BaseRepository<Registro>, IRegistroRepository
    {
        public RegistroRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Registro>> GetAllAsync()
        {
            return await dbSet.Include(x => x.Curso).Include(x => x.Estudiante).ToListAsync();
        }
    }
}
