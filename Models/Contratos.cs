using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SISCO_SAYACv3._5.Models
{
    public class Contratos
    {
        public int ContratosId { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Fecha inicio:")]
        public DateTime fecha_inicio { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Fecha final:")]
        public DateTime fecha_fin { get; set; }
        [Required]
        [Range(1000, 9999999999999999)]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor del contrato:")]
        public double valor_contrato { get; set; }
        [Required]
        [Display(Name = "Porcentaje de desfase:")]
        // Tener en cuenta que la variable es tiempo_desfase. 
        public double tiempo_desfase { get; set; }
        [Required]
        [Range(0, 100)]
        [Display(Name = "Porcentaje de multa:")]
        public double porcentaje_multa { get; set; }
        [Required]
        [Range(0, 100)]
        [Display(Name = "Porcentaje adicional:")]
        public double porcentaje_adicional { get; set; }
        [StringLength(200, MinimumLength = 2)]
        [Display(Name = "Observaciones:")]
        public string observaciones { get; set; }
        [Required]
        [Display(Name = "Estado:")]
        public string estado { get; set; }
        public List<Reportes> Reporte { get; set; }
        [Required]
        [Display(Name = "Identificacion del contratista:")]
        public int ContratistasId { get; set; }
        public Contratistas Contratistas { get; set; }

        public Obras Obras { get; set; }
        
        

    }
}
