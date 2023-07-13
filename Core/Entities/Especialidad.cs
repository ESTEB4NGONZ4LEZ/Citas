

using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Especialidad
    {
        [Key]
        public int Esp_id { get; set; }
        public int Esp_nombre { get; set; }
        public ICollection<Medico> ? Medicos { get; set; }
    }
}