using BackendAcademico.Core.Data;
using BackendAcademico.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Core.Interfaces
{
    public interface IInscripcionService
    {
        Task<RespuestaService<List<Inscripcion>>> Listar();
        Task<RespuestaService<Inscripcion>> BuscarPorId(decimal id);
        Task<RespuestaService<Inscripcion>> Guardar(Inscripcion i);
        Task<RespuestaService<Inscripcion>> Actualizar(Inscripcion i);
        Task<RespuestaService<bool>> Eliminar(decimal id);
    }
}
