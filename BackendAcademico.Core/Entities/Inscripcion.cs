using System;
using System.Collections.Generic;

namespace BackendAcademico.Core.Data;

public class Inscripcion
{
    public decimal Idinscripcion { get; set; }

    public decimal Idmateria { get; set; }

    public decimal Idestudiante { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual Estudiante IdestudianteNavigation { get; set; } = null!;

    public virtual Materium IdmateriaNavigation { get; set; } = null!;
}
