using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SISCO_SAYACv3._5.Models
{
    public class Auditorias
    {
        public int AuditoriasId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha inicio")]
        public DateTime Fecha_Inicio { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Fecha final")]
        public DateTime Fecha_Final { get; set; }
        // Foreign keys
        [Display(Name = "Nombre usuario")]
        public int UsuariosId { get; set; }
        public Usuarios Usuarios { get; set; }
    }
}
