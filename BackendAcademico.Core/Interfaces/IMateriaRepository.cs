using BackendAcademico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Core.Interfaces
{
    public interface IMateriaRepository
    {
        Task<IEnumerable<Materium>> GetMaterias();
        Task<Materium> GetMateria(decimal id);
        Task InsertMateria(Materium materia);


    }
}
