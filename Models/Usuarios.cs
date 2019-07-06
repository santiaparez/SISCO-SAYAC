using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISCO_SAYACv3._5.Models
{
    public class Usuarios
    {
        public int UsuariosId { get; set; }
        [Required]
        public string usuario { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string contrasena { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string correo { get; set; }
        public virtual List<Auditorias> Auditoria { get; set; }
    }
}
