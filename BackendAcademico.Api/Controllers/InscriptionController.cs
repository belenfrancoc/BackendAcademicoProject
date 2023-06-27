using BackendAcademico.Core.DTOs;
using BackendAcademico.Core.Interfaces;
using BackendAcademico.Infrastructure.Data;
using BackendAcademico.Infrastructure.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace BackendAcademico.Api.Controllers
{
    [Route("api /[controller]")]
    [ApiController]
    public class InscriptionController : Controller
    {
        private readonly IInscripcionRepository _inscriptionRepository; 
        
        public InscriptionController(IInscripcionRepository inscripcionRepository)
        {
            _inscriptionRepository = inscripcionRepository; 
        } 


        [HttpGet]
        public async Task<IActionResult> GetInscripcions()
        {
            var inscripcions = await _inscriptionRepository.GetInscripcions();
            return Ok(inscripcions);

       
        }

        [HttpGet("{idinscripcion}")]
        public async Task<ActionResult<InscripcionDTO>> BuscarPorId(decimal idinscripcion)
        {
            var retorno = await _servicio.BuscarPorId(idinscripcion);

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpPost]
        public async Task<ActionResult<InscripcionDTO>> Guardar(InscripcionDTO c)
        {
            var retorno = await _servicio.Guardar(c.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpPut]
        public async Task<ActionResult<InscripcionDTO>> Actualizar(InscripcionDTO c)
        {
            var retorno = await _servicio.Actualizar(c.ToDatabase());
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpDelete("{idinscripcion}")]
        public async Task<ActionResult<bool>> Eliminar(decimal idinscripcion)
        {
            var retorno = await _servicio.Eliminar(idinscripcion);

            if (retorno.Exito)
                return true;
            else
                return StatusCode(retorno.Status, retorno.Error);
        } 
    }
}
