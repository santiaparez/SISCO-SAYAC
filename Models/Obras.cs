using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SISCO_SAYACv3._5.Models
{
    public class Obras
    {
        public int ObrasId { get; set; }
        [StringLength(60, MinimumLength = 2)]
        [Required]
        [Display(Name = "Nombre obra:")]
        public string nombre_obra { get; set; }
        [Required]
        [Display(Name = "Tipo obra:")]
        public string tipo_obra { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 5)]
        [Display(Name = "Dirreción obra:")]
        public string direccion_obra { get; set; }
        [Required]
        [Display(Name = "Identificacion del contrato:")]
        public int ContratosId { get; set; }       
        public Contratos Contratos { get; set; }
    }
}
