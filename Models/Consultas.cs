using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISCO_SAYACv3._5.Models
{
    public class Consultas
    {
        public int ConsultaId { get; set; }
        public string NombreConsulta { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaContratoInferior { get; set; }
        public DateTime FechaContratoSuperior { get; set; }
        public int ContratistasId { get; set; }
        public int ObrasId { get; set; }
        public double PorcentajeAvanceInferior { get; set; }
        public double PorcentajeAvanceSuperior { get; set; }
        public double? MontoInferior { get; set; }
        public double? MontoSuperior { get; set; }
        public bool Activo { get; set; }
        public bool Terminado { get; set; }
    }
}
