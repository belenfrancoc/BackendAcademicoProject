using BackendAcademico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Infrastructure.Repositories
{
    public class EstudianteRepository : IEstudiante
    {
        public IEnumerable<Estudiante> GetEstudiantes()
        {
            var estudiantes = Enumerable.Range(1, 10).Select(x => new Estudiante
            {
                IdEstudiante = x,
                CiEstudiante = x,
                NombreEstudiante = $"Nombre {x}",
                ApellidoEstudiante = $"Apellido {x}",
                Fecha = DateTime.Now
            });
            return estudiantes;

        }
         
    }

}
