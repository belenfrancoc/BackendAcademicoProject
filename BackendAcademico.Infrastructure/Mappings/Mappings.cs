using BackendAcademico.Core.Data;
using BackendAcademico.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Infrastructure.Mappings
{
    public static partial class Mapper
    {
        public static InscripcionDTO ToDTO(this Inscripcion model)  // Convierte de ModelContext a DTO
        {
            return new InscripcionDTO()
            {
                Idinscripcion = model.Idinscripcion,
                IdMateria = model.Idmateria,
                IdEstudiante = model.Idestudiante,
                Descripcion = model.Descripcion,
            };
        }

        public static MateriaDTO ToDTO(this Materium model)  // Convierte de ModelContext a DTO
        {
            return new MateriaDTO()
            {
                IdMateria = model.Idmateria,
                Sigla = model.Sigla,
                Nombre = model.Nombre,
            };
        }
    }

    public static partial class Mapper
    {
        public static Inscripcion ToDatabase(this Inscripcion dto)  // Convierte de DTO a ModelContext
        {
            return new Inscripcion()
            {
                Idinscripcion = dto.Idinscripcion,
                Idestudiante = dto.Idestudiante,
                Idmateria = dto.Idmateria,  
                Descripcion = dto.Descripcion,

            };
        }

        public static Materium ToDatabase(this Materium dto)  // Convierte de DTO a ModelContext
        {
            return new Materium()
            {
                Idmateria = dto.Idmateria,
                Sigla = dto.Sigla,
                Nombre = dto.Nombre,

            };
        }
    }
}
