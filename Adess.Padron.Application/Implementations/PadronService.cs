using Adess.Padron.Application.Contracts;
using Adess.Padron.Domain.Models;
using System.Xml.Serialization;
using System.Xml;
using Microsoft.Extensions.Configuration;
using Adess.Padron.Domain;
using System.IO.Pipes;
using Adess.Padron.Persistance;
using AutoMapper;

namespace Adess.Padron.Application.Implementations
{
    public class PadronService : IPadronService
    {

        private readonly IConfiguration _configuration;

        private readonly IHttpClientService _httpClient;

        private readonly IPadronUnitOfWork _padronUnitOfWork;
        private readonly IMapper _mapper;

        public PadronService(IConfiguration configuration, 
                             IHttpClientService httpClient, 
                             IPadronUnitOfWork padronUnitOfWork,
                             IMapper mapper)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _padronUnitOfWork = padronUnitOfWork;
            _mapper = mapper;
        }

        private readonly string _pathUrl = "idcons/IndividualDataHandler.aspx?ServiceID={0}&ID1={1}&ID2={2}&ID3={3}";

        public async Task<Persona> GetPadronInfo(string numCedula)
        {
            var persona = new Persona();

            var cedula = new Cedula(numCedula);

            try
            {
                var url = BuildRequestUrl(cedula.MunCed, cedula.SeqCed, cedula.VerCed);

                var header = new Dictionary<string, string>
                {
                    { "User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2" }
                };

                var xmlResponse = await _httpClient.GetAsync(url,HttpMethod.Get, header);

                persona = DeserializeXml<Persona>(xmlResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la información: {ex.Message}");
            }

            return persona;
        }

        private string BuildRequestUrl(string munCed, string seqCed, string verCed)
        {
            string baseUrl = _configuration["padron:baseUrl"];
            string serviceId = _configuration["padron:service"];
            return string.Format(baseUrl + _pathUrl, serviceId, munCed, seqCed, verCed);
        }

        private static T DeserializeXml<T>(string xml)
        {
            try
            {
                var objDoc = new XmlDocument();

                objDoc.LoadXml(xml);

                string newXml = objDoc.DocumentElement!.InnerXml;

                var serializer = new XmlSerializer(typeof(T));
                using var stringReader = new StringReader($"<Root>{newXml}</Root>");
                return (T)serializer.Deserialize(stringReader);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al deserializar XML: {ex.Message}");
                return default;
            }
        }

        public async Task<OperationResult<PadronResponse>> Procesar()
        {
            var cedulas = await GetCedulaParaProcesar();
            
            var result = new OperationResult<PadronResponse>();

            var padronResponse = new PadronResponse();

            foreach (var item in cedulas)
            {
                var persona = await GetPadronInfo(item.Id);

                if(persona.nombres != null)
                {

                    try
                    {
                        var personaPadron = _mapper.Map<PadronElectoral>(persona);
                        personaPadron.Id = item.Id;
                        await _padronUnitOfWork.RepositoryFor<PadronElectoral, string>().AddAsync(personaPadron);

                        await _padronUnitOfWork.SaveChangesAsync();

                        item.Estatus = true;

                        _padronUnitOfWork.RepositoryFor<CedulasProcesar, string>().Update(item);

                        _padronUnitOfWork.SaveChanges();

                        padronResponse.CantidadProcesadas++;
                    }
                    catch (Exception ex)
                    {
                        padronResponse.CantidadNoProcesadas++;

                        padronResponse.CedulasNoprocesadas.Add(item.Id);
                    }
                }
            }

            result.Entity = padronResponse;

            result.Result = true;

            result.Message = $"Se procesaron un total de {padronResponse.CantidadProcesadas} cedulas y no se pudieron procesar {padronResponse.CantidadNoProcesadas}";

            return result;
        }

        private async Task<List<CedulasProcesar>> GetCedulaParaProcesar()
        {
            return await _padronUnitOfWork.RepositoryFor<CedulasProcesar, string>().FilterByAsync(x => !x.Estatus);
        }
    }
}
