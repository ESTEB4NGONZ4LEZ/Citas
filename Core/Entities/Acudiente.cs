

using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Acudiente
    {
        [Key]
        public int Acu_codigo { get; set; }
        public string ? Acu_nombreCompleto { get; set; }
        public string ? Acu_telefono { get; set; }
        public string ? Acu_direccion { get; set; }
        public ICollection<Usuario> ? Usuarios { get; set; }
    }
}