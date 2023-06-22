using BackendAcademico.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Core.Interfaces
{
    public interface IMateriaService
    {
        Task<RespuestaService<List<Materium>>> Listar();
        Task<RespuestaService<Materium>> BuscarPorId(decimal id);
        Task<RespuestaService<Materium>> Guardar(Materium m);
        Task<RespuestaService<Materium>> Actualizar(Materium m);
        Task<RespuestaService<bool>> Eliminar(decimal id);
    }
}
