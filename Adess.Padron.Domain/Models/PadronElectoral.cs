using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adess.Padron.Domain.Models
{
    public class PadronElectoral : AEntity<string>
    {
        public string MunCed { get; set; }
        public string SeqCed { get; set; }
        public string VerCed { get; set; }
        public string Nombres { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string LugarNacimiento { get; set; }
        public string CedNum { get; set; }
        public string CedSeri { get; set; }
        public string CedSexo { get; set; }
        public string CodNacionalidad { get; set; }
        public string EstadoCivil { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string Categoria { get; set; }
        public string Estatus { get; set; }
    }
}
