using System;
using System.Collections.Generic;

namespace BackendAcademico.Core.Entities;

public class Inscripcion
{
    public decimal Idinscripcion { get; set; }

    public decimal Idmateria { get; set; }

    public decimal Idestudiante { get; set; }

    public string Descripcion { get; set; }
    public object IdestudianteNavigation { get; set; }
    public object IdmateriaNavigation { get; set; }
}
