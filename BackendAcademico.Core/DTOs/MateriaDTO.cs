using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Core.DTOs
{
    public class MateriaDTO
    {
        public decimal IdMateria { get; set; }
        public string? Sigla { get; set; }
        public string? Nombre { get; set; }
    }
}
