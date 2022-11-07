using AgenciaAirVibes_MetodosAssincronos.Data;
using AgenciaAirVibes_MetodosAssincronos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgenciaAirVibes_MetodosAssincronos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : Controller
    {

        private readonly _DbContext db;

        public TicketController (_DbContext _db)
        {
            db = _db;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> Get()
        {
            return await db.Ticket.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetById(int id)
        {
            var ticket_db = await db.Ticket.FindAsync(id);

            if(ticket_db == null )
            {
                NotFound();
            }

            return Ok(ticket_db);
        }


        [HttpPost]
        public async Task<ActionResult> Post(Ticket ticket)
        {
            if (ticket != null)
            {
                db.Ticket.Add(ticket);
                await db.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Ticket ticket)
        {
            var ticket_db = await db.Ticket.FindAsync(id);
            
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            if (ticket_db == null)
            {
                return NotFound();
            }

            ticket_db.NomePas = ticket.NomePas;
            ticket_db.Partida = ticket.Partida;
            ticket_db.Destino = ticket.Destino;
            ticket_db.DataIda = ticket.DataIda;
            ticket_db.DataVolta = ticket.DataVolta;

            await db.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            var ticket = await db.Ticket.FindAsync(id);
            
            if(ticket == null)
            {
                NotFound();
            }
            db.Ticket.Remove(ticket);
            await db.SaveChangesAsync();

            return Ok();
        }
    }
}
