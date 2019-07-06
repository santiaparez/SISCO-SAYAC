using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISCO_SAYACv3._5.Models
{
    public class Reportes
    {
        public int ReportesId { get; set; }
        [Required]
        [Display(Name = "Nombre reporte:")]
        public string nombre_reportes { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha reporte")]
        public DateTime fecha_reportes { get; set; }
        [StringLength(200, MinimumLength = 2)]
        [Display(Name = "Observación")]
        public string observacion { get; set; }
        [Display(Name = "Id contrato:")]
        [Required]
        public int ContratosId { get; set; }
        public Contratos Contratos { get; set; }
    }
}
