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
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Usuario> GetByNombreUsuario(string nombreUsuario)
        {
            var usuario = await dbSet.SingleOrDefaultAsync(x => x.NombreUsuario == nombreUsuario);
            return usuario;
        }
    }
}
