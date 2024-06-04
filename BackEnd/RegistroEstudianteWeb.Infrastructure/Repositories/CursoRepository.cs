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
    public  class CursoRepository : BaseRepository<Curso>, ICursoRepository
    {
        public CursoRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Curso>> GetAllAsync()
        {
            return await dbSet.Include(x => x.Registros).Include(x => x.Profesores).ToListAsync();
        }
    }
}
