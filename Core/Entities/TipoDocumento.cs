
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class TipoDocumento
    {
        [Key]
        public int Tipdoc_id { get; set; }
        public string ? Tipdoc_nombre { get; set; }
        public string ? Tipdoc_abreviatura { get; set; }
        public ICollection<Usuario> ? Usuarios { get; set; }
    }
}