using RegistroEstudianteWeb.Core.Entities;

namespace RegistroEstudianteWeb.Web.Models
{
    public class EstudianteModel
    {
        public int EstudianteId { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<Registro> Registros { get; set; }
    }
}
