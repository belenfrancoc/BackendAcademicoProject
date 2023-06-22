using BackendAcademico.Core.Data;
using BackendAcademico.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAcademico.Core.Services
{
    public class InscripcionService : IInscripcionService
    {
        public ModelContext _context;

        public InscripcionService(ModelContext context)
        {
            _context = context;
        }

         public async Task<RespuestaService<Inscripcion>> Actualizar(Inscripcion i)
        {
            var res = new RespuestaService<Inscripcion>();
            var ins = await _context.Inscripcion.FirstOrDefaultAsync(x => x.Id == i.Id);

            if (ins == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                ins.Descripcion = i.Descripcion;

                try
                {
                    _context.Categoria.Update(ins);
                    await _context.SaveChangesAsync();

                    res.Objeto = ins;
                }
                catch (DbUpdateException ex)
                {
                    res.AgregarInternalServerError(ex.Message);
                }
            }

            return res;

        }

        public async Task<RespuestaService<Inscripcion>> BuscarPorId(decimal id)
        {
            var res = new RespuestaService<Inscripcion>();
            var cat = await _context.Categoria.FirstOrDefaultAsync(x => x.Id == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
                res.Objeto = cat;

            return res;

        }

        public async Task<RespuestaService<bool>> Eliminar(decimal id)
        {
            var res = new RespuestaService<bool>();
            var ins = await _context.Categoria.FirstOrDefaultAsync(x => x.Id == id);

            if (ins == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                try
                {
                    _context.Inscripcion.Remove(ins);
                    await _context.SaveChangesAsync();
                    res.Exito = true;
                }
                catch (DbUpdateException ex)
                {
                    res.AgregarInternalServerError(ex.Message);
                }
            }

            return res;

        }

        public async Task<RespuestaService<Inscripcion>> Guardar(Inscripcion i)
        {
            var res = new RespuestaService<Inscripcion>();

            try
            {
                await _context.Inscripcion.AddAsync(i);
                await _context.SaveChangesAsync();
                i.Id = await _context.Inscripcion.MaxAsync(u => u.Id);

                res.Objeto = i;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;


        }

        public async Task<RespuestaService<List<Inscripcion>>> Listar()
        {
            var res = new RespuestaService<List<Inscripcion>>();
            var lista = await _context.Inscripcion.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }

       
    }
}
