using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Workers.Models;

namespace Workers.Controllers
{
    public class PrestadorsController : ApiController
    {
        private WorkersContext db = new WorkersContext();

        // GET: api/Prestadors
        public IQueryable<PrestadorDTO> GetPrestadors()
        {
            var prestadors = from b in db.Prestadors
                             select new PrestadorDTO()
                             {
                                 Id = b.Id,
                                 Nome = b.Nome,
                                 Sobrenome = b.Sobrenome,
                                 Cpf = b.Cpf
                             };
            return prestadors;

        }

        // GET: api/Prestadors/5
        [ResponseType(typeof(PrestadorDetailDTO))]
        public async Task<IHttpActionResult> GetPrestador(int id)
        {
            var prestador = await db.Prestadors.Include(b => b.Categoria).Select(b =>
        new PrestadorDetailDTO()
        {
            Id = b.Id,
            Nome = b.Nome,
            Sobrenome = b.Sobrenome,
            Email = b.Email,
            Cpf = b.Cpf,
            Rg = b.Rg,
            Categoria = b.Categoria.Nome,
            Nascimento = b.Nascimento
        }).SingleOrDefaultAsync(b => b.Id == id);
            if (prestador == null)
            {
                return NotFound();
            }

            return Ok(prestador);
        }

        // PUT: api/Prestadors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPrestador(int id, Prestador prestador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prestador.Id)
            {
                return BadRequest();
            }

            db.Entry(prestador).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrestadorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Prestadors
        [ResponseType(typeof(PrestadorDTO))]
        public async Task<IHttpActionResult> PostPrestador(Prestador prestador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prestadors.Add(prestador);
            await db.SaveChangesAsync();

            db.Entry(prestador).Reference(x => x.Categoria).Load();

            var dto = new PrestadorDTO()
            {
                Id = prestador.Id,
                Nome = prestador.Nome,
                Sobrenome = prestador.Sobrenome,
                Cpf = prestador.Cpf
            };

            return CreatedAtRoute("DefaultApi", new { id = prestador.Id }, prestador);
        }

        // DELETE: api/Prestadors/5
        [ResponseType(typeof(Prestador))]
        public async Task<IHttpActionResult> DeletePrestador(int id)
        {
            Prestador prestador = await db.Prestadors.FindAsync(id);
            if (prestador == null)
            {
                return NotFound();
            }

            db.Prestadors.Remove(prestador);
            await db.SaveChangesAsync();

            return Ok(prestador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrestadorExists(int id)
        {
            return db.Prestadors.Count(e => e.Id == id) > 0;
        }
    }
}