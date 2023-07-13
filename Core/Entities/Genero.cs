

using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Genero
    {
        [Key]
        public int Gen_id { get; set; }
        public string ? Gen_nombre { get; set; }
        public string ? Gen_abreviatura { get; set; }
        public ICollection<Usuario> ? Usuarios { get; set; }
    }
}