

using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class EstadoCita
    {
        [Key]
        public int Estcita_id { get; set; }
        public string ? Estcita_nombre { get; set; }
        public ICollection<Cita> ? Citas { get; set; }
    }
}