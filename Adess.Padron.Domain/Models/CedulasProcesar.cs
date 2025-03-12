using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adess.Padron.Domain.Models
{
    public class CedulasProcesar :AEntity<string>
    {
        public bool Estatus { get; set; }
    }
}
