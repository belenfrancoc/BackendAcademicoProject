using BackendAcademico.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackendAcademico.Api.Controllers
{
    [Route("api /[controller]")]
    [ApiController]
    public class EstudianteController : Controller
    {
        [HttpGet]
        public IActionResult GetEstudiantes()
        {
            var estudiantes = new EstudianteRepository().GetEstudiantes();   
            return Ok(null);
        }
    }
}
