using RegistroEstudianteWeb.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RegistroEstudianteWeb.Web.Models
{
    public class CursoModel
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }

        public virtual ICollection<Registro> Registros { get; set; }
        public virtual ICollection<Profesor> Profesores { get; set; }
    }
}
