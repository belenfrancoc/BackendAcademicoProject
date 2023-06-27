using BackendAcademico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Core.Interfaces
{
    public interface IEstudianteRepository
    {
        Task<IEnumerable<Estudiante>> GetEstudiantes();
        Task<Estudiante> GetEstudiante(decimal id);
        Task InsertEstudiante(Estudiante estudiante);
    }
}
