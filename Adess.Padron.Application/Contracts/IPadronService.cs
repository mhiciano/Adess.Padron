using Adess.Padron.Domain;
using Adess.Padron.Domain.Models;

namespace Adess.Padron.Application.Contracts
{
    public interface IPadronService
    {
        Task<Persona> GetPadronInfo(string cedula);

        Task<OperationResult<PadronResponse>> Procesar();
    }
}
