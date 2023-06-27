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
            var inscripcions = await _context.Inscripcions.ToListAsync();
            return inscripcions;
        }

        public async Task<Inscripcion> GetInscripcion(decimal id)
        {
            var inscripcion = await _context.Inscripcions.FirstOrDefaultAsync(x=> x.Idinscripcion == id);
            return inscripcion;
        }
        public async Task InsertInscripcion(Inscripcion inscripcion)
        {
            _context.Inscripcions.Add(inscripcion);
            await _context.SaveChangesAsync();
        }


    }
    
       



    
}
