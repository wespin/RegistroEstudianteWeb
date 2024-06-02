using System.ComponentModel.DataAnnotations;

namespace RegistroEstudianteWeb.Web.Models
{
    public class CursoModel
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
    }
}
