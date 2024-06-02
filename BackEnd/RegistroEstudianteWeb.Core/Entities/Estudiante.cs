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
    public class Estudiante
    {
        public int EstudianteId { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string FullName
        {
            get
            {
                return Apellido + ", " + Nombre;
            }
        }
        [JsonIgnore]
        public virtual ICollection<Registro> Registros { get; set; }

    }
}
