using System;
using System.Collections.Generic;

namespace ESTUDIANTECRUD.Models
{
    public partial class Estudiante
    {
        public int IdEstudiante { get; set; }
        public string? NombreEstudiante { get; set; }
        public string? Apellido { get; set; }
        public string? CedulaEstudiante { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? IdMateria { get; set; }

        public virtual Materium? oMateria { get; set; }
    }
}
