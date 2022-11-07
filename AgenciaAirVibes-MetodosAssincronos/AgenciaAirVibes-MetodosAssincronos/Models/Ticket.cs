using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaAirVibes_MetodosAssincronos.Models
{
    [Table(name: "passagem")]
    public class Ticket
    {
        public int Id { get; set; }
        public string? NomePas { get; set; }
        public string? Partida { get; set; }
        public string? Destino { get; set; }
        public string? DataIda { get; set; }
        public string? DataVolta { get; set; }
    }
}
