using BackendAcademico.Core.Entities;
using BackendAcademico.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendAcademico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaRepository _materiaRepository;

        public MateriaController(IMateriaRepository materiaRepository)
        {
            _materiaRepository = materiaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMaterias()
        {
            var materias = await _materiaRepository.GetMaterias();
            return Ok(materias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMateria(decimal id)
        {
            var materia = await _materiaRepository.GetMateria(id);
            return Ok(materia);
        }

        [HttpPost]
        public async Task<IActionResult> PostMateria(Materium materia)
        {
            await _materiaRepository.InsertMateria(materia);
            return Ok(materia);
        }
    }

}
