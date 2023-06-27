using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BackendAcademico.Core.Entities;

public partial class Inscripcion
{

    public Inscripcion() 
    {
        Estudiantes = new HashSet<Estudiante>();
    }
    public decimal Idinscripcion { get; set; }

    public decimal Idmateria { get; set; }

    public decimal Idestudiante { get; set; }

    public string? Descripcion { get; set; }
    public object? IdestudianteNavigation { get; set; }
    public object? IdmateriaNavigation { get; set; }

    public virtual ICollection<Estudiante> Estudiantes { get; set; }   
    
}
