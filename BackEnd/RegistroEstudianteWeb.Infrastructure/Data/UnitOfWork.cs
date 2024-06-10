using RegistroEstudianteWeb.Core.Interfaces;
using RegistroEstudianteWeb.Core.Interfaces.Repositories;
using RegistroEstudianteWeb.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEstudianteWeb.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ICursoRepository _cursoRepository;
        private IEstudianteRepository _estudianteRepository;
        private IProfesorRepository _profesorRepository;
        private IRegistroRepository _registroRepository;
        private IUsuarioRepository _usuarioRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public ICursoRepository CursoRepository => _cursoRepository ??= new CursoRepository(_context);

        public IEstudianteRepository EstudianteRepository => _estudianteRepository ??= new EstudianteRepository(_context);

        public IProfesorRepository ProfesorRepository => _profesorRepository ??= new ProfesorRepository(_context);

        public IRegistroRepository RegistroRepository => _registroRepository ??= new RegistroRepository(_context);

        public IUsuarioRepository UsuarioRepository => _usuarioRepository ??= new UsuarioRepository(_context);

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
