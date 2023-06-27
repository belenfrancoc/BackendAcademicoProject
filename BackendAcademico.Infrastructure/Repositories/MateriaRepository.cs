using BackendAcademico.Core.Entities;
using BackendAcademico.Infrastructure.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Infrastructure.Repositories
{
    public class MateriaRepository
    {
        private readonly ModelContext _context;

        private readonly IDbConnection _connection;

        public MateriaRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public MateriaRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Materium>> GetMaterias()
        {
            var materias = await _connection.QueryAsync<Materium>("ObtenerMaterias", commandType: CommandType.StoredProcedure);
            return materias;
        }

        public async Task<Materium> GetMateria(decimal id)
        {
            var parameters = new { IdMateria = id };
            var materia = await _connection.QueryFirstOrDefaultAsync<Materium>("ObtenerMaterias", parameters, commandType: CommandType.StoredProcedure);
            return materia;
        }

        public async Task InsertMateria(Materium materia)
        {
            var parameters = new
            {
                // Especifica los parámetros necesarios para la inserción
                // por ejemplo: Nombre = materia.Nombre, Descripcion = materia.Descripcion, etc.
            };

            await _connection.ExecuteAsync("ObtenerMaterias", parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
