using Adess.Padron.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adess.Padron.Application.Contracts
{
    public interface IPadronService
    {
        Task<Persona> GetPadronInfo(string cedula);
    }
}
