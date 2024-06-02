using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace RegistroEstudianteWeb.Core.Entities
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Registro> Registros { get; set; }
        [JsonIgnore]
        public virtual ICollection<Profesor> Profesores { get; set; }
    }
}
