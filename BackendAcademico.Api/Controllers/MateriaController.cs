using BackendAcademico.Core.DTOs;
using BackendAcademico.Core.Interfaces;
using BackendAcademico.Infrastructure.Data;
using BackendAcademico.Infrastructure.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace BackendAcademico.Api.Controllers
{
    [Route("api /[controller]")]
    [ApiController]
    public class MateriaController : Controller
    {
        private readonly IInscripcionService _servicio;
        private IInscripcionService servicio;

        public MateriaController(IMateriaService _servicio)
        {
            _servicio = (IMateriaService)servicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<MateriaDTO>>> Listar(Core.Services.RespuestaService<List<Core.Data.Inscripcion>> retorno)
        {
            var retorno = await _servicio.Listar();

            if (retorno.Objeto != null)
                return retorno.Objeto.Select(Mapper.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpGet("{idmateria}")]
        public async Task<ActionResult<MateriaDTO>> BuscarPorId(decimal idmateria)
        {
            var retorno = await _servicio.BuscarPorId(idmateria);

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpPost]
        public async Task<ActionResult<MateriaDTO>> Guardar(MateriaDTO c)
        {
            var retorno = await _servicio.Guardar(c.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpPut]
        public async Task<ActionResult<MateriaDTO>> Actualizar(MateriaDTO c)
        {
            var retorno = await _servicio.Actualizar(c.ToDatabase());
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpDelete("{idmateria}")]
        public async Task<ActionResult<bool>> Eliminar(decimal idmateria)
        {
            var retorno = await _servicio.Eliminar(idmateria);

            if (retorno.Exito)
                return true;
            else
                return StatusCode(retorno.Status, retorno.Error);
        }
    }
}
}
