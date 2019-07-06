using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SISCO_SAYACv3._5.Models
{
    public class Contratistas
    {
        public int ContratistasId { get; set; }
        [Display(Name = "Tipo documento")]
        [Required]
        public string tipo_documento { get; set; }
        [Display(Name = "Numero documento")]
        [Required]
        public int numero_identificacion { get; set; }
        [Display(Name = "Primer nombre")]
        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string primer_nombre { get; set; }
        [Display(Name = "Segundo nombre")]
        [StringLength(60, MinimumLength = 2)]
        public string segundo_nombre { get; set; }
        [Display(Name = "Primer apellido")]
        [StringLength(60, MinimumLength = 2)]
        public string primer_apellido { get; set; }
        [Display(Name = "Segundo apellido")]
        [StringLength(60, MinimumLength = 2)]
        public string segundo_apellido { get; set; }
        [Display(Name = "Telefono")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string telefono { get; set; }
        [Display(Name = "Direccion")]
        [StringLength(60, MinimumLength = 4)]
        [Required]
        public string direccion { get; set; }
        [Display(Name = "Correo electronico")]
        [DataType(DataType.EmailAddress)]
        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string correo_electronico { get; set; }

        public List<Obras> Obra {get;set;}
        public List<Contratos> Contrato { get; set; }

    }
}
