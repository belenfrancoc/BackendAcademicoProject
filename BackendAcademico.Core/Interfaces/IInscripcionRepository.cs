using BackendAcademico.Core.Entities;

namespace BackendAcademico.Core.Interfaces
{
    public interface IInscripcionRepository
    {
        Task<IEnumerable<Inscripcion>> GetInscripcions();

        Task<Inscripcion> GetInscripcion(decimal id);

        Task InsertInscripcion(Inscripcion inscripcion);
    }
}
