using RegistroEstudianteWeb.Core.Entities;

namespace RegistroEstudianteWeb.Web.Models
{
    public class ProfesorModel
    {
        public int ProfesorId { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaContratacion { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
