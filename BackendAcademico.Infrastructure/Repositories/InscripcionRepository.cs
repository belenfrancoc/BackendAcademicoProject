using BackendAcademico.Core.Interfaces;
using BackendAcademico.Infrastructure.Data;
using BackendAcademico.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendAcademico.Infrastructure.Repositories
{
    public class InscripcionRepository : IInscripcionRepository
    {
        private readonly ModelContext _context;

        public InscripcionRepository(ModelContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Inscripcion>> GetInscripcions()
        {
            var inscripcions = await _context.Inscripcion.ToListAsync();
            return inscripcions;
  

        }
    }
    
       



    
}
