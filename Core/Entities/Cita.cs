

using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Cita
    {
        [Key]
        public int Cit_codigo { get; set; }
        public DateTime Cit_fecha { get; set; }
        public int Cit_estadoCita { get; set; }
        public int Cit_medico { get; set; }
        public int Cit_datosUsuario { get; set; }
        public EstadoCita ? EstadoCita { get; set; }
        public Medico ? Medico { get; set; }
        public Usuario ? Usuario { get; set; }
    }
}