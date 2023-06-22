using System;
using System.Collections.Generic;

namespace BackendAcademico.Core.Data;

public class Estudiante
{
    public decimal Idestudiante { get; set; }

    public decimal Ci { get; set; }

    public DateTime Fechanacimiento { get; set; }

    public string Nombres { get; set; } = null!;

    public string? Apellidos { get; set; }

    public virtual ICollection<Inscripcion> Inscripcions { get; set; } = new List<Inscripcion>();
}
