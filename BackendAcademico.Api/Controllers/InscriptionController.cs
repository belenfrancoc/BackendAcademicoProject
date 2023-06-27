using BackendAcademico.Core.Entities;
using BackendAcademico.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dapper;

namespace BackendAcademico.Api.Controllers
{
    [Route("api /[controller]")]
    [ApiController]
    public class InscriptionController : Controller
    {
        private readonly IInscripcionRepository _inscripcionRepository; 
        
        public InscriptionController(IInscripcionRepository inscripcionRepository)
        {
            _inscripcionRepository = inscripcionRepository; 
        }

        [HttpGet]
        public async Task<IActionResult> GetInscripcions()
        {
            var inscripcions = await _inscripcionRepository.GetInscripcions();
            return Ok(inscripcions);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInscripcion(decimal id)
        {
            var inscripcion = await _inscripcionRepository.GetInscripcion(id);

            return Ok(inscripcion);
        }

       [HttpPost]
         public async Task<IActionResult> Post(Inscripcion inscripcion)
         {
            await _inscripcionRepository.InsertInscripcion(inscripcion);

            return Ok(inscripcion);
        }
        
         
    }
}
