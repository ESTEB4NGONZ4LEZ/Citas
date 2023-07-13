

using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Usuario
    {
        [Key]
        public int Usu_id { get; set; }
        public string ?  usu_nombre { get; set; }
        public string ? Usu_segdo_nombre { get; set; }
        public string ? Usu_primer_apellido_usuar { get; set; }
        public string ? Usu_segdo_apellido_usuar { get; set; }
        public string ? Usu_telefono { get; set; }
        public string ? Usu_direccion { get; set; }
        public string ? Usu_email { get; set; }
        public int usu_tipodoc { get; set; }
        public int usu_genero { get; set; }
        public int usu_acudiente { get; set; }
        public TipoDocumento ? Tipo_documento { get; set; }
        public Genero ?  Genero { get ; set; }
        public Acudiente ? Acudiente { get; set; }
        public ICollection<Cita> ? Citas { get; set; }
    }
}