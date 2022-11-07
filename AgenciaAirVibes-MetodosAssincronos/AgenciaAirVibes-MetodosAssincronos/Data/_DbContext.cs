using AgenciaAirVibes_MetodosAssincronos.Models;
using Microsoft.EntityFrameworkCore;

namespace AgenciaAirVibes_MetodosAssincronos.Data
{
    public class _DbContext : DbContext
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Ticket> Ticket { get; set; }
    }
}
