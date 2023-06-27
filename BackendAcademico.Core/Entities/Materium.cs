using System;
using System.Collections.Generic;

namespace BackendAcademico.Core.Entities;

public class Materium
{
    public decimal Idmateria { get; set; }

    public string Sigla { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Inscripcion> Inscripcions { get; set; } = new List<Inscripcion>();
}
