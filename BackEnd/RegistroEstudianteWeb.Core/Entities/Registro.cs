using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RegistroEstudianteWeb.Core.Entities
{
    public class Registro
    {
            public int RegistroId { get; set; }
            public int CursoId { get; set; }
            public int EstudianteId { get; set; }
            public int? Nota { get; set; }
        [JsonIgnore]
        public virtual Curso Curso { get; set; }

        [JsonIgnore]
        public virtual Estudiante Estudiante { get; set; }

    }
}
