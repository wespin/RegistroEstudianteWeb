using RegistroEstudianteWeb.Core.Entities;

namespace RegistroEstudianteWeb.Web.Models
{
    public class RegistroModel
    {
        public int RegistroId { get; set; }
        public int CursoId { get; set; }
        public int EstudianteId { get; set; }
        public int? Nota { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual Estudiante Estudiante { get; set; }
    }
}
