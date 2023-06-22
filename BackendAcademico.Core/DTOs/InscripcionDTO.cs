using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Core.DTOs
{
    public class InscripcionDTO
    {
        public decimal Idinscripcion { get; set; }
        public decimal IdMateria { get; set; }
        public decimal IdEstudiante { get; set; }

        public string? Descripcion { get; set; }
    }
}
