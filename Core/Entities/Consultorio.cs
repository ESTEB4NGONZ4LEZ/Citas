

using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Consultorio
    {
        [Key]
        public int cons_codigo { get; set; }
        public string ? cons_nombre { get; set; }
        public ICollection<Medico> ? Medicos { get; set; } 
    }
}