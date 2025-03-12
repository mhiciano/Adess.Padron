using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adess.Padron.Domain.Models
{
    public class PadronResponse
    {
        public int CantidadProcesadas { get; set; }
        public int CantidadNoProcesadas { get; set; }
        public List<string> CedulasNoprocesadas { get; set; } = [];
    }
}
