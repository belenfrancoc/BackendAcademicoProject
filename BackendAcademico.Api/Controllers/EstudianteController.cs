using BackendAcademico.Core.Entities;
using BackendAcademico.Core.Interfaces;
using BackendAcademico.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackendAcademico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteRepository _estudianteRepository;
        private readonly Random _random;

        public EstudianteController(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
            _random = new Random();
        }

        private readonly string[] _randomNombres = new string[]
        {
            "Juan", "Maria", "Rodrigo", "Jose", "Marco", "Osvaldo", "Juana", "Rocio", "Lucia", "Mariel",
            "Tito", "Andres", "Roxana", "Leticia", "Ruth", "Mario", "Miriam", "Ruben", "Daniel", "Omar", "Carlos"
        };

        private readonly string[] _randomApellidos = new string[]
        {
            "Carvajal", "Lopez", "Conde", "Roque", "Rocha", "Martinez", "Lucana", "Arce", "Quintana", "Rodriguez",
            "Alvarez", "Quispe", "Mamani", "Rojas", "Vaca", "Barba", "Soria", "Gonzales", "Palacios", "Reyes"
        };

        [HttpPost]
        public async Task<IActionResult> RegistrarEstudiantes()
        {
            // Verificar si ya existen registros de estudiantes
            var estudiantesExistentes = await _estudianteRepository.GetEstudiantes();
            if (estudiantesExistentes.Any())
            {
                return BadRequest("Ya se han registrado estudiantes");
            }

            for (int i = 0; i < 10; i++)
            {
                string ci = GenerarCI();
                string nombre = ObtenerNombreAleatorio();
                string apellido = ObtenerApellidoAleatorio();
                DateTime fechaNacimiento = GenerarFechaNacimientoAleatoria();

                decimal ciDecimal;
                if (!decimal.TryParse(ci, out ciDecimal))
                {
                    return BadRequest("Error en la generación del CI");
                }

                var estudiante = new Estudiante
                {
                    Ci = ciDecimal,
                    Nombres = nombre,
                    Apellidos = apellido,
                    Fechanacimiento = fechaNacimiento
                };

                await _estudianteRepository.InsertEstudiante(estudiante);
            }

            return Ok("Estudiantes registrados exitosamente");
        }

        private string GenerarCI()
        {
            const int ciLength = 7;
            const string ciChars = "0123456789";
            return new string(Enumerable.Range(0, ciLength)
                .Select(_ => ciChars[_random.Next(ciChars.Length)]).ToArray());
        }

        private string ObtenerNombreAleatorio()
        {
            return _randomNombres[_random.Next(_randomNombres.Length)];
        }

        private string ObtenerApellidoAleatorio()
        {
            return _randomApellidos[_random.Next(_randomApellidos.Length)];
        }

        private DateTime GenerarFechaNacimientoAleatoria()
        {
            var startDate = new DateTime(1984, 1, 1);
            var endDate = new DateTime(2000, 12, 31);
            int range = (endDate - startDate).Days;
            return startDate.AddDays(_random.Next(range));
        }
    }
}

