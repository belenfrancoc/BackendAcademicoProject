using BackendAcademico.Core.Entities;
using BackendAcademico.Core.Interfaces;
using BackendAcademico.Infrastructure.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BackendAcademico.Infrastructure.Repositories
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly ModelContext _context;
        private readonly IDbConnection _connection;
        public EstudianteRepository(ModelContext context)
        {
            _context = context;
        }
     
        public EstudianteRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Estudiante>> GetEstudiantes()
        {
            var estudiantes = await _connection.QueryAsync<Estudiante>("ObtenerEstudiantes", commandType: CommandType.StoredProcedure);
            return estudiantes;
        }
        /* anterior metodo antes de implementar dapper
        public async Task<IEnumerable<Estudiante>> GetEstudiantes()
        {
            var estudiantes = await _context.Estudiantes.ToListAsync();
            return estudiantes;
        }
        */
        public async Task<Estudiante> GetEstudiante(decimal id)
        {
            var estudiante = await _context.Estudiantes.FirstOrDefaultAsync(x => x.Idestudiante == id);
            return estudiante;
        }

        public async Task InsertEstudiante(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();
        }

    }

}
