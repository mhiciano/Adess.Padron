using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adess.Padron.Domain
{
    public class OperationResult<T>
    {
        public T Entity { get; set; }
        public string Message { get; set; }
        public bool Result { get; set; }
    }
}
