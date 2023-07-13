

using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Medico
    {
        [Key]
        public int Med_nroMatriculaProsional { get; set; }
        public string ? Med_nombreCompleto { get; set; }
        public int ? Med_consultorio { get; set; }
        public int ? Med_especialidad { get; set; }
        public Consultorio ? Consultorio { get; set; }
        public Especialidad ? Especialidad { get; set; }
        public ICollection<Cita> ? Citas { get; set; }
    }
}